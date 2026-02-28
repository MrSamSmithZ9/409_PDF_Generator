using _409_PDF_Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Path = System.IO.Path;

namespace _409_PDF_Generator
{
    public partial class Form1 : Form
    {
        private string rootFolder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Use application base directory as the "root folder"
            rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            lblRootFolder.Text = "Root folder: " + rootFolder;
            RefreshPdfList();
        }

        private void RefreshPdfList()
        {
            // Clear all lists
            checkedListBox_RideTrack.Items.Clear();
            checkedListBox_Station.Items.Clear();
            checkedListBox_LSM.Items.Clear();
            checkedListBox_ShotgunGate.Items.Clear();
            checkedListBox_Train.Items.Clear();
            checkedListBox_Other.Items.Clear();

            try
            {
                // Recursive scan to include subfolders
                var files = Directory.GetFiles(rootFolder, "*.pdf", SearchOption.AllDirectories)
                                     .OrderBy(f => Path.GetFileName(f))
                                     .ToArray();

                foreach (var f in files)
                {
                    // Extract month/year from the PDF content (best effort).
                    string monthYear = "Unknown";
                    try
                    {
                        monthYear = ExtractMonthYearFromPdf(f) ?? "Unknown";
                    }
                    catch
                    {
                        monthYear = "Unknown";
                    }

                    // detect hodr token in filename (D, M01, W01, Y, Q, etc.)
                    var hodrToken = GethodrTokenFromFilename(Path.GetFileName(f));

                    var pdfItem = new PdfItem(Path.GetFileName(f), f, monthYear, hodrToken);
                    var group = ClassifyPdfByFilename(f);

                    switch (group)
                    {
                        case PdfGroup.RideTrack:
                            checkedListBox_RideTrack.Items.Add(pdfItem);
                            break;
                        case PdfGroup.Station:
                            checkedListBox_Station.Items.Add(pdfItem);
                            break;
                        case PdfGroup.LSM:
                            checkedListBox_LSM.Items.Add(pdfItem);
                            break;
                        case PdfGroup.ShotgunGate:
                            checkedListBox_ShotgunGate.Items.Add(pdfItem);
                            break;
                        case PdfGroup.Train:
                            checkedListBox_Train.Items.Add(pdfItem);
                            break;
                        default:
                            checkedListBox_Other.Items.Add(pdfItem);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPdfList();
        }

        // Collect checked file paths from all group lists
        private IEnumerable<string> GetCheckedFilePaths()
        {
            foreach (var obj in checkedListBox_RideTrack.CheckedItems)
                if (obj is PdfItem p1) yield return p1.FullPath;

            foreach (var obj in checkedListBox_Station.CheckedItems)
                if (obj is PdfItem p2) yield return p2.FullPath;

            foreach (var obj in checkedListBox_LSM.CheckedItems)
                if (obj is PdfItem p3) yield return p3.FullPath;

            foreach (var obj in checkedListBox_ShotgunGate.CheckedItems)
                if (obj is PdfItem p4) yield return p4.FullPath;

            foreach (var obj in checkedListBox_Train.CheckedItems)
                if (obj is PdfItem p5) yield return p5.FullPath;

            foreach (var obj in checkedListBox_Other.CheckedItems)
                if (obj is PdfItem p6) yield return p6.FullPath;
        }

        private void btnOpenSelected_Click(object sender, EventArgs e)
        {
            var selected = GetCheckedFilePaths().ToList();
            if (!selected.Any())
            {
                MessageBox.Show("No PDFs selected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var path in selected)
            {
                try
                {
                    Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open '{path}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Print selected PDFs (uses shell print, repeated per copy)
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            var selected = GetCheckedFilePaths().ToList();
            if (!selected.Any())
            {
                MessageBox.Show("No PDFs selected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int copies = 1;
            try
            {
                copies = (int)numericUpDownCopies.Value;
                if (copies < 1) copies = 1;
            }
            catch
            {
                copies = 1;
            }

            var confirm = MessageBox.Show($"Print {copies} copy(ies) of {selected.Count} file(s)?", "Confirm Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            btnPrintSelected.Enabled = false;
            btnOpenSelected.Enabled = false;
            btnRefresh.Enabled = false;

            try
            {
                foreach (var path in selected)
                {
                    for (int i = 0; i < copies; i++)
                    {
                        try
                        {
                            var psi = new ProcessStartInfo
                            {
                                FileName = path,
                                Verb = "print",
                                UseShellExecute = true,
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            try
                            {
                                Process.Start(psi);
                            }
                            catch (Win32Exception)
                            {
                                // ignore handler-specific errors and continue
                            }

                            // small delay so the viewer can hand off the job to the spooler
                            Thread.Sleep(700);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Could not print '{path}': {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                MessageBox.Show("Print commands sent. Verify your printer queue for job status.", "Print Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btnPrintSelected.Enabled = true;
                btnOpenSelected.Enabled = true;
                btnRefresh.Enabled = true;
                Cursor.Current = oldCursor;
            }
        }

        // Generic double-click handler for any checked list box
        private void checkedListBox_DoubleClick(object sender, EventArgs e)
        {
            var clb = sender as CheckedListBox;
            if (clb == null) return;

            var sel = clb.SelectedItem as PdfItem;
            if (sel == null) return;

            try
            {
                Process.Start(sel.FullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open '{sel.FullPath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Owner-draw handler: draws checkbox + colored text based on hodr token
        private void checkedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var clb = sender as CheckedListBox;
            if (clb == null || e.Index < 0) return;

            var item = clb.Items[e.Index] as PdfItem;
            string text = item?.ToString() ?? clb.Items[e.Index].ToString();

            // Determine color from hodr token
            Color foreColor = clb.ForeColor;
            if (item != null && !string.IsNullOrEmpty(item.hodrToken))
            {
                switch (item.hodrToken.ToUpperInvariant())
                {
                    case "D":
                        foreColor = Color.Green;
                        break;
                    case "M01":
                        foreColor = Color.Blue;
                        break;
                    case "W01":
                        foreColor = Color.Orange;
                        break;
                    case "Y":
                        foreColor = Color.Red;
                        break;
                    case "Q":
                        foreColor = Color.HotPink;
                        break;
                }
            }

            e.DrawBackground();

            bool isChecked = clb.GetItemChecked(e.Index);

            // Draw checkbox
            int cbSize = 14;
            var cbRect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + (e.Bounds.Height - cbSize) / 2, cbSize, cbSize);
            CheckBoxState cbState = isChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            try
            {
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(cbRect.X, cbRect.Y), cbState);
            }
            catch
            {
                // fallback simple rectangle
                using (var pen = new Pen(Color.Black))
                    e.Graphics.DrawRectangle(pen, cbRect);
            }

            // Draw text
            var textRect = new Rectangle(cbRect.Right + 4, e.Bounds.Y, e.Bounds.Width - cbRect.Width - 6, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, text, e.Font, textRect, foreColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }

        // detect token immediately following "hodr" in the filename (case-insensitive)
        // returns normalized token (uppercase), e.g. "D", "M01", "W01", "Y", "Q" or null if none
        private string GethodrTokenFromFilename(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return null;
            var name = Path.GetFileNameWithoutExtension(filename).ToLowerInvariant();

            // check for known tokens immediately after "hodr"
            // pattern: hodr possibly followed by punctuation/spaces, then token
            var m = Regex.Match(name, @"hodr[_\-\s]*?(?<tok>(m01|w01|d|y|q))", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            if (m.Success)
                return m.Groups["tok"].Value.ToUpperInvariant();
            else
            {
                Debug.WriteLine("No hodr token found in filename: " + filename);
            }

                // last-resort: if filename contains "hodr" and token appears anywhere after it, try finding the token substring index-wise
                var idx = name.IndexOf("hodr", StringComparison.InvariantCultureIgnoreCase);
            if (idx >= 0)
            {
                Debug.WriteLine("Running hodr Failsafe for filename: " + filename);
                var tail = name.Substring(idx + 5); // after "hodr"
                // look for the known tokens at start of tail
                var known = new[] { "m01", "w01", "d", "y", "q" };
                foreach (var k in known)
                {
                    if (tail.StartsWith(k, StringComparison.InvariantCultureIgnoreCase))
                        return k.ToUpperInvariant();
                }
            }

            return null;
        }

        // Classify based strictly on filename (no folder/path tokens).
        // Shotgun detection is checked before Station to ensure shotgun files are not misclassified as Station.
        private PdfGroup ClassifyPdfByFilename(string fullPath)
        {
            var name = System.IO.Path.GetFileNameWithoutExtension(fullPath) ?? "";
            var normalized = name.ToLowerInvariant();

            // Ensure shotgun is checked first so filenames containing "shotgun" won't fall into Station
            if (MatchesAny(normalized, "shotgun gate", "shotgun", "shot-gun", "shot gun", "shotgun_gate", "sg_gate", "sg"))
                return PdfGroup.ShotgunGate;

            // Check in order of specificity to avoid accidental overlaps.
            if (MatchesAny(normalized, "ride track", "ridetrack", "ride-track", "ride", "track"))
                return PdfGroup.RideTrack;

            if (MatchesAny(normalized, "station", "sta", "stn"))
                return PdfGroup.Station;

            if (MatchesAny(normalized, "lsm"))
                return PdfGroup.LSM;

            if (MatchesAny(normalized, "train", "trn"))
                return PdfGroup.Train;

            return PdfGroup.Other;
        }

        // Whole-word / token matching helper for filename classification
        private bool MatchesAny(string filenameLower, params string[] tokens)
        {
            foreach (var token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token)) continue;
                // allow tokens that include spaces or punctuation; use Regex word boundaries
                var pattern = @"\b" + Regex.Escape(token.ToLowerInvariant()) + @"\b";
                if (Regex.IsMatch(filenameLower, pattern, RegexOptions.CultureInvariant))
                    return true;
            }
            return false;
        }

        // Attempt to extract a Month + Year from PDF text content (best-effort).
        // Uses iText 7 for text extraction (iText7 packages required).
        private string ExtractMonthYearFromPdf(string pdfPath)
        {
            if (!File.Exists(pdfPath)) return null;

            StringBuilder sb = new StringBuilder();
            try
            {
                using (var reader = new PdfReader(pdfPath))
                using (var pdfDoc = new PdfDocument(reader))
                {
                    int numberOfPages = pdfDoc.GetNumberOfPages();
                    for (int i = 1; i <= numberOfPages; i++)
                    {
                        var page = pdfDoc.GetPage(i);
                        string pageText = PdfTextExtractor.GetTextFromPage(page);
                        if (!string.IsNullOrWhiteSpace(pageText))
                            sb.AppendLine(pageText);
                    }
                }

                string allText = sb.ToString();
                if (string.IsNullOrWhiteSpace(allText)) return null;

                // Normalize whitespace and lower-case for matching
                string normalized = Regex.Replace(allText, @"\s+", " ").Trim();

                // Month names and abbreviations
                string months = "January|February|March|April|May|June|July|August|September|October|November|December|Jan|Feb|Mar|Apr|Jun|Jul|Aug|Sep|Sept|Oct|Nov|Dec";
                // Pattern: Month [sep] Year (e.g. January 2026 or Jan-2026)
                var pattern = @"\b(" + months + @")\b[\s\-\.,/]*\b((?:19|20)\d{2})\b";
                var m = Regex.Match(normalized, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                if (m.Success)
                {
                    string monthToken = m.Groups[1].Value;
                    string yearToken = m.Groups[2].Value;
                    string monthName = NormalizeMonthName(monthToken);
                    if (!string.IsNullOrEmpty(monthName))
                        return monthName + " " + yearToken;
                }

                // Try reversed: Year [sep] Month
                var pattern2 = @"\b((?:19|20)\d{2})\b[\s\-\.,/]*\b(" + months + @")\b";
                var m2 = Regex.Match(normalized, pattern2, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                if (m2.Success)
                {
                    string yearToken = m2.Groups[1].Value;
                    string monthToken = m2.Groups[2].Value;
                    string monthName = NormalizeMonthName(monthToken);
                    if (!string.IsNullOrEmpty(monthName))
                        return monthName + " " + yearToken;
                }

                // As fallback, look for any month name and any 4-digit year anywhere (closest year to that month)
                var monthMatches = Regex.Matches(normalized, @"\b(" + months + @")\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                var yearMatches = Regex.Matches(normalized, @"\b((?:19|20)\d{2})\b", RegexOptions.CultureInvariant);

                if (monthMatches.Count > 0 && yearMatches.Count > 0)
                {
                    // pick first month and nearest year by index
                    var firstMonth = monthMatches[0];
                    int monthIndex = firstMonth.Index;
                    // find closest year
                    Match bestYear = null;
                    int bestDist = int.MaxValue;
                    foreach (Match yr in yearMatches)
                    {
                        int dist = Math.Abs(yr.Index - monthIndex);
                        if (dist < bestDist)
                        {
                            bestDist = dist;
                            bestYear = yr;
                        }
                    }
                    if (bestYear != null)
                    {
                        string monthName = NormalizeMonthName(firstMonth.Value);
                        return monthName + " " + bestYear.Value;
                    }
                }
            }
            catch
            {
                // Extraction failed — return null so caller uses "Unknown"
            }

            return null;
        }

        private string NormalizeMonthName(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            token = token.Trim();
            // Try parse using DateTime parse formats for month names
            string[] formats = new[] { "MMMM", "MMM" };
            DateTime dt;
            if (DateTime.TryParseExact(token, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month);
            }

            // Manual map for unusual abbreviations (e.g., "Sept")
            var lower = token.ToLowerInvariant();
            switch (lower)
            {
                case "sept":
                    return "September";
                default:
                    // last resort: capitalize token
                    return char.ToUpper(token[0]) + token.Substring(1).ToLowerInvariant();
            }
        }

        // Small helper to store display name, full path and detected month/year in the list
        private class PdfItem
        {
            public string Name { get; }
            public string FullPath { get; }
            public string MonthYear { get; }
            public string hodrToken { get; }

            public PdfItem(string name, string fullPath, string monthYear, string hodrToken)
            {
                Name = name;
                FullPath = fullPath;
                MonthYear = string.IsNullOrWhiteSpace(monthYear) ? "Unknown" : monthYear;
                hodrToken = string.IsNullOrWhiteSpace(hodrToken) ? null : hodrToken.ToUpperInvariant();
            }

            public override string ToString()
            {
                return $"{Name} ({MonthYear})";
            }
        }

        private enum PdfGroup
        {
            RideTrack,
            Station,
            LSM,
            ShotgunGate,
            Train,
            Other
        }
    }
}