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
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Utils;
using Path = System.IO.Path;

namespace _409_PDF_Generator
{
    public partial class Form1 : Form
    {
        private string rootFolder;
        private List<string> generatedPDFs = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Attach single-click handler so a single click immediately sends the item to the print queue.
            // Include the new Daily list
            listBox_RideTrack.Click += listBox_ItemClick;
            listBox_Daily.Click += listBox_ItemClick; // NEW
            listBox_Station.Click += listBox_ItemClick;
            listBox_LSM.Click += listBox_ItemClick;
            listBox_ShotgunGate.Click += listBox_ItemClick;
            listBox_Train.Click += listBox_ItemClick;
            listBox_Other.Click += listBox_ItemClick;
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
            listBox_RideTrack.Items.Clear();
            listBox_Daily.Items.Clear();
            listBox_Station.Items.Clear();
            listBox_LSM.Items.Clear();
            listBox_ShotgunGate.Items.Clear();
            listBox_Train.Items.Clear();
            listBox_Other.Items.Clear();
            listBoxPrintQueue.Items.Clear();

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

                    // detect HODR token in filename (D, M01, W01, Y, Q, etc.)
                    var hodrToken = GetHodrTokenFromFilename(Path.GetFileName(f));

                    var pdfItem = new PdfItem(Path.GetFileName(f), f, monthYear, hodrToken);
                    var group = ClassifyPdfByFilename(f);

                    // if HodrToken == "D" add to Daily tab
                    if (string.Equals(pdfItem.HodrToken, "D", StringComparison.InvariantCultureIgnoreCase))
                    {
                        listBox_Daily.Items.Add(pdfItem);
                    }

                    switch (group)
                    {
                        case PdfGroup.RideTrack:
                            listBox_RideTrack.Items.Add(pdfItem);
                            break;
                        case PdfGroup.Station:
                            listBox_Station.Items.Add(pdfItem);
                            break;
                        case PdfGroup.LSM:
                            listBox_LSM.Items.Add(pdfItem);
                            break;
                        case PdfGroup.ShotgunGate:
                            listBox_ShotgunGate.Items.Add(pdfItem);
                            break;
                        case PdfGroup.Train:
                            listBox_Train.Items.Add(pdfItem);
                            break;
                        default:
                            listBox_Other.Items.Add(pdfItem);
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

        // Collect selected file paths from all group lists (include Daily)
        private IEnumerable<string> GetSelectedFilePaths()
        {
            foreach (var obj in listBox_RideTrack.SelectedItems)
                if (obj is PdfItem p1) yield return p1.FullPath;

            foreach (var obj in listBox_Daily.SelectedItems)
                if (obj is PdfItem pDaily) yield return pDaily.FullPath;

            foreach (var obj in listBox_Station.SelectedItems)
                if (obj is PdfItem p2) yield return p2.FullPath;

            foreach (var obj in listBox_LSM.SelectedItems)
                if (obj is PdfItem p3) yield return p3.FullPath;

            foreach (var obj in listBox_ShotgunGate.SelectedItems)
                if (obj is PdfItem p4) yield return p4.FullPath;

            foreach (var obj in listBox_Train.SelectedItems)
                if (obj is PdfItem p5) yield return p5.FullPath;

            foreach (var obj in listBox_Other.SelectedItems)
                if (obj is PdfItem p6) yield return p6.FullPath;
        }

        private void btnOpenSelected_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedFilePaths().ToList();
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

        // Add selected items from all groups to the print queue (include Daily)
        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            var added = 0;
            void addFromList(ListBox lb)
            {
                // cast to array to avoid modifying collection while iterating
                foreach (var obj in lb.SelectedItems.Cast<object>().ToArray())
                {
                    if (!(obj is PdfItem pi)) continue;
                    if (AddPdfToQueue(pi))
                        added++;
                }

                // optional: clear selection after adding
                lb.ClearSelected();
            }

            addFromList(listBox_RideTrack);
            addFromList(listBox_Daily);
            addFromList(listBox_Station);
            addFromList(listBox_LSM);
            addFromList(listBox_ShotgunGate);
            addFromList(listBox_Train);
            addFromList(listBox_Other);

            if (added > 0)
                MessageBox.Show($"Added {added} item(s) to the print queue.", "Queue Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No selected items to add or items already exist in queue.", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Removes all items currently shown in the Daily tab from the print queue.
        private void btnRemoveDailyFromQueue_Click(object sender, EventArgs e)
        {
            var sel = listBoxPrintQueue.Items.Cast<object>().OfType<PdfItem>().ToArray();
            if (sel.Length == 0)
            {
                MessageBox.Show("No items in the print queue.", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Keep track of how many were removed
            int removedCount = 0;

            // Remove using snapshot copy to allow removing in loop
            foreach (var item in sel.ToArray())
            {
                // If item is in Daily list (by filename match), remove from queue
                bool isDaily = listBox_Daily.Items.Cast<object>()
                    .OfType<PdfItem>()
                    .Any(dailyItem => string.Equals(Path.GetFileName(dailyItem.FullPath), Path.GetFileName(item.FullPath), StringComparison.InvariantCultureIgnoreCase));

                if (isDaily)
                {
                    listBoxPrintQueue.Items.Remove(item);
                    removedCount++;
                }
            }

            if (removedCount > 0)
                MessageBox.Show($"Removed {removedCount} Daily item(s) from the print queue.", "Queue Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Daily items were removed (they may not be in the queue).", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearQueue_Click(object sender, EventArgs e)
        {
            if (listBoxPrintQueue.Items.Count == 0) return;
            var r = MessageBox.Show("Clear all items from the print queue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                listBoxPrintQueue.Items.Clear();
            }
        }

        // NEW: Instead of printing, merge queue into a single PDF and OPEN the merged PDF in the default viewer.
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            var queueItems = listBoxPrintQueue.Items.Cast<object>().OfType<PdfItem>().ToList();
            if (!queueItems.Any())
            {
                MessageBox.Show("Print queue is empty. Add items to the queue before proceeding.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Merge {queueItems.Count} file(s) into a single PDF and open it?", "Confirm Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            btnPrintSelected.Enabled = false;
            btnOpenSelected.Enabled = false;
            btnClearQueue.Enabled = false;

            string mergedPath = null;
            try
            {
                var inputPaths = queueItems.Select(x => x.FullPath).ToList();
                mergedPath = MergeQueueToPdf(inputPaths);
                if (mergedPath == null)
                {
                    MessageBox.Show("Failed to create merged PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = mergedPath,
                        UseShellExecute = true

                    });
                    generatedPDFs.Add(mergedPath);
                    listBoxPrintQueue.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open merged PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            finally
            {
                btnPrintSelected.Enabled = true;
                btnOpenSelected.Enabled = true;
                btnClearQueue.Enabled = true;
                Cursor.Current = oldCursor;
            }
        }

        // Merge provided PDF paths into a single PDF located in the user's temp folder.
        // Returns the merged file path on success or null on failure.
        private string MergeQueueToPdf(IEnumerable<string> pdfPaths)
        {
            var list = pdfPaths?.Where(p => !string.IsNullOrWhiteSpace(p) && File.Exists(p)).ToList();
            if (list == null || list.Count == 0) return null;

            string outFile = Path.Combine(Path.GetTempPath(), $"409_PDF_Merged_{DateTime.UtcNow:yyyyMMdd_HHmmss}.pdf");

            try
            {
                // Ensure previous file removed if exists
                if (File.Exists(outFile)) File.Delete(outFile);

                // Create writer for the destination file
                using (var writer = new PdfWriter(outFile))
                using (var pdfDest = new PdfDocument(writer))
                {
                    var merger = new PdfMerger(pdfDest);
                    bool runSingle = true;

                    foreach (var src in list)
                    {
                        try
                        {
                            //-- Add Single --
                            using (var reader = new PdfReader(src))
                            {
                                reader.SetUnethicalReading(true); // allow merging of protected PDFs if necessary                     
                                using (var pdfSrc = new PdfDocument(reader))
                                {
                                    merger.Merge(pdfSrc, 1, pdfSrc.GetNumberOfPages());
                                }
                            }

                            //-- Process Duplicates ---
                            if (src.Contains("BOGIE"))
                            {
                                runSingle = false;
                                var duplicates = PrepareDuplicatePaths(src, (int)(bogieNumber_box.Value-1)*(int)(trainNumber_box.Value), out var createdTemps);
                                duplicateMerge(merger, duplicates);
                            }
                            if (src.Contains("RESTRAINT"))
                            {
                                runSingle = false;
                                var duplicates = PrepareDuplicatePaths(src, (int)(bogieNumber_box.Value - 1) * (int)(trainNumber_box.Value), out var createdTemps);
                                duplicateMerge(merger, duplicates);
                            }
                            if (src.Contains("TRAIN CABIN"))
                            {
                                runSingle = false;
                                var duplicates = PrepareDuplicatePaths(src, (int)trainNumber_box.Value - 1, out var createdTemps);
                                duplicateMerge(merger, duplicates);
                            }
                            if (src.Contains("SWITCHES"))
                            {
                                runSingle = false;
                                var duplicates = PrepareDuplicatePaths(src, (int)switchNumber_box.Value - 1, out var createdTemps);
                                duplicateMerge(merger, duplicates);
                            }
                            if (src.Contains("2 OR 4"))
                            {
                                runSingle = false;
                                var duplicates = PrepareDuplicatePaths(src, 2, out var createdTemps);
                                duplicateMerge(merger, duplicates);
                            }
                        }
                        catch (Exception ex)
                        {
                            // If a specific source fails, continue with others but log/display
                            Debug.WriteLine($"Failed to merge '{src}': {ex.Message}");
                        }
                    }
                    // pdfDest and writer are disposed/closed by using
                }

                // verify output exists and has content
                if (File.Exists(outFile) && new FileInfo(outFile).Length > 0)
                    return outFile;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MergeQueueToPdf error: " + ex.Message);
            }

            return null;
        }

        private void duplicateMerge(PdfMerger pm, List<string> dupes)
        {
            foreach (var src in dupes)
            {
                try
                {

                    using (var reader = new PdfReader(src))
                    {
                        reader.SetUnethicalReading(true); // allow merging of protected PDFs if necessary                     
                        using (var pdfSrc = new PdfDocument(reader))
                        {
                            pm.Merge(pdfSrc, 1, pdfSrc.GetNumberOfPages());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If a specific source fails, continue with others but log/display
                    Debug.WriteLine($"Failed to merge '{src}': {ex.Message}");
                }
            }
            CleanupTempCopies(dupes);
        }

        private List<string> PrepareDuplicatePaths(string original, int copiesPerFile, out List<string> tempCopies)
        {
            // Returns a list containing each original path plus (copiesPerFile-1) temp copies for each original.
            // tempCopies will contain only the created temp copy paths for cleanup.
            tempCopies = new List<string>();
            var result = new List<string>();

            if (original == null) return result;

            if (string.IsNullOrWhiteSpace(original) || !File.Exists(original)) return result;

            // Always include the original
            result.Add(original);

            // Create extra copies if requested
            for (int i = 1; i < copiesPerFile; i++)
            {
                try
                {
                    // unique temp filename
                    string temp = Path.Combine(Path.GetTempPath(), $"{Path.GetFileNameWithoutExtension(original)}_copy_{Guid.NewGuid():N}{Path.GetExtension(original)}");
                    File.Copy(original, temp, overwrite: true);
                    tempCopies.Add(temp);
                    result.Add(temp);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to create temp copy of '{original}': {ex.Message}");
                    // continue — still merge whatever we have
                }
            }
            

            return result;
        }

        private void CleanupTempCopies(List<string> tempCopies)
        {
            if (tempCopies == null || tempCopies.Count == 0) return;
            foreach (var t in tempCopies)
            {
                try
                {
                    if (File.Exists(t)) File.Delete(t);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to delete temp copy '{t}': {ex.Message}");
                }
            }
        }

        // Open double-clicked item in any group list
        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            var lb = sender as ListBox;
            if (lb == null) return;

            var sel = lb.SelectedItem as PdfItem;
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

        // Add single-clicked item to print queue immediately
        private void listBox_ItemClick(object sender, EventArgs e)
        {
            var lb = sender as ListBox;
            if (lb == null) return;

            // use SelectedItem (click changes selection)
            var sel = lb.SelectedItem as PdfItem;
            if (sel == null) return;

            AddPdfToQueue(sel);
        }

        // Adds PdfItem to listBoxPrintQueue if not already present. Returns true if added.
        private bool AddPdfToQueue(PdfItem pdf)
        {
            if (pdf == null) return false;

            bool exists = listBoxPrintQueue.Items.Cast<object>()
                .OfType<PdfItem>()
                .Any(x => string.Equals(x.FullPath, pdf.FullPath, StringComparison.InvariantCultureIgnoreCase));

            if (exists) return false;

            listBoxPrintQueue.Items.Add(pdf);
            // show new item
            listBoxPrintQueue.SelectedIndex = listBoxPrintQueue.Items.Count - 1;
            return true;
        }

        // Open double-clicked item in print queue
        private void listBoxPrintQueue_DoubleClick(object sender, EventArgs e)
        {
            var sel = listBoxPrintQueue.SelectedItem as PdfItem;
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

        // MouseDown on print queue: select the item under the mouse when right-clicking,
        // store index so context menu handler can remove the correct item.
        private int _printQueueRightClickIndex = -1;
        private void listBoxPrintQueue_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is ListBox lb)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int idx = lb.IndexFromPoint(e.Location);
                    _printQueueRightClickIndex = idx;
                    if (idx >= 0 && idx < lb.Items.Count)
                    {
                        // make sure the item under the mouse is selected so removal acts on selection
                        lb.SelectedIndex = idx;
                    }
                    else
                    {
                        lb.ClearSelected();
                    }
                }
                else
                {
                    _printQueueRightClickIndex = -1;
                }
            }
        }

        // Context menu 'Remove from Queue' click handler
        private void toolStripMenuItemRemoveFromQueue_Click(object sender, EventArgs e)
        {
            // Prefer to remove the selected items (user may have multi-selected),
            // but if none are selected and a right-click target index exists, remove that item.
            var sel = listBoxPrintQueue.SelectedItems.Cast<object>().OfType<PdfItem>().ToArray();

            if (sel.Length == 0 && _printQueueRightClickIndex >= 0 && _printQueueRightClickIndex < listBoxPrintQueue.Items.Count)
            {
                listBoxPrintQueue.Items.RemoveAt(_printQueueRightClickIndex);
            }
            else if (sel.Length > 0)
            {
                foreach (var item in sel)
                    listBoxPrintQueue.Items.Remove(item);
            }

            // reset right-click index
            _printQueueRightClickIndex = -1;
        }

        // detect token immediately following "HODR" in the filename (case-insensitive)
        // returns normalized token (uppercase), e.g. "D", "M01", "W01", "Y", "Q" or null if none
        private string GetHodrTokenFromFilename(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return null;
            var name = Path.GetFileNameWithoutExtension(filename).ToLowerInvariant();

            // check for known tokens immediately after "hodr"
            // pattern: hodr possibly followed by punctuation/spaces, then token
            var m = Regex.Match(name, @"hodr[_\-\s]*?(?<tok>(m01|w01|d|y|q))", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            if (m.Success)
                return m.Groups["tok"].Value.ToUpperInvariant();

            // last-resort: if filename contains "hodr" and token appears anywhere after it, try finding the token substring index-wise
            var idx = name.IndexOf("hodr", StringComparison.InvariantCultureIgnoreCase);
            if (idx >= 0)
            {
                var tail = name.Substring(idx + 4); // after "hodr"
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
            public string HodrToken { get; }

            public PdfItem(string name, string fullPath, string monthYear, string hodrToken)
            {
                Name = name;
                FullPath = fullPath;
                MonthYear = string.IsNullOrWhiteSpace(monthYear) ? "Unknown" : monthYear;
                HodrToken = string.IsNullOrWhiteSpace(hodrToken) ? null : hodrToken.ToUpperInvariant();
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

        // Adds all items currently shown in the Daily tab to the print queue.
        private void btnAddDailyToQueue_Click(object sender, EventArgs e)
        {
            if (listBox_Daily.Items.Count == 0)
            {
                MessageBox.Show("No Daily PDFs found to add.", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int added = 0;
            foreach (var obj in listBox_Daily.Items.Cast<object>().OfType<PdfItem>())
            {
                if (AddPdfToQueue(obj))
                    added++;
            }

            if (added > 0)
                MessageBox.Show($"Added {added} Daily item(s) to the print queue.", "Queue Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Daily items were added (they may already exist in the queue).", "Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanupTempCopies(generatedPDFs);
        }
    }
}