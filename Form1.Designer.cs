using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace _409_PDF_Generator
{
    partial class Form1
    {
        private IContainer components = null;

        private TabControl tabControlGroups;
        private TabPage tabRideTrack;
        private TabPage tabStation;
        private TabPage tabLSM;
        private TabPage tabShotgunGate;
        private TabPage tabTrain;
        private TabPage tabOther;

        private CheckedListBox checkedListBox_RideTrack;
        private CheckedListBox checkedListBox_Station;
        private CheckedListBox checkedListBox_LSM;
        private CheckedListBox checkedListBox_ShotgunGate;
        private CheckedListBox checkedListBox_Train;
        private CheckedListBox checkedListBox_Other;

        private Button btnRefresh;
        private Button btnOpenSelected;
        private Button btnPrintSelected;
        private Label lblRootFolder;
        private NumericUpDown numericUpDownCopies;
        private Label lblCopies;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlGroups = new System.Windows.Forms.TabControl();
            this.tabRideTrack = new System.Windows.Forms.TabPage();
            this.tabStation = new System.Windows.Forms.TabPage();
            this.tabLSM = new System.Windows.Forms.TabPage();
            this.tabShotgunGate = new System.Windows.Forms.TabPage();
            this.tabTrain = new System.Windows.Forms.TabPage();
            this.tabOther = new System.Windows.Forms.TabPage();

            this.checkedListBox_RideTrack = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_Station = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_LSM = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ShotgunGate = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_Train = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_Other = new System.Windows.Forms.CheckedListBox();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenSelected = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.lblRootFolder = new System.Windows.Forms.Label();
            this.numericUpDownCopies = new System.Windows.Forms.NumericUpDown();
            this.lblCopies = new System.Windows.Forms.Label();

            ((ISupportInitialize)(this.numericUpDownCopies)).BeginInit();
            this.tabControlGroups.SuspendLayout();
            this.tabRideTrack.SuspendLayout();
            this.tabStation.SuspendLayout();
            this.tabLSM.SuspendLayout();
            this.tabShotgunGate.SuspendLayout();
            this.tabTrain.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlGroups
            // 
            this.tabControlGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                   | System.Windows.Forms.AnchorStyles.Left)
                                                                                  | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGroups.Controls.Add(this.tabRideTrack);
            this.tabControlGroups.Controls.Add(this.tabStation);
            this.tabControlGroups.Controls.Add(this.tabLSM);
            this.tabControlGroups.Controls.Add(this.tabShotgunGate);
            this.tabControlGroups.Controls.Add(this.tabTrain);
            this.tabControlGroups.Controls.Add(this.tabOther);
            this.tabControlGroups.Location = new System.Drawing.Point(12, 46);
            this.tabControlGroups.Name = "tabControlGroups";
            this.tabControlGroups.SelectedIndex = 0;
            this.tabControlGroups.Size = new System.Drawing.Size(1254, 590);
            this.tabControlGroups.TabIndex = 0;

            // 
            // tabRideTrack
            // 
            this.tabRideTrack.Controls.Add(this.checkedListBox_RideTrack);
            this.tabRideTrack.Location = new System.Drawing.Point(4, 29);
            this.tabRideTrack.Name = "tabRideTrack";
            this.tabRideTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tabRideTrack.Size = new System.Drawing.Size(1246, 557);
            this.tabRideTrack.TabIndex = 0;
            this.tabRideTrack.Text = "Ride Track";
            this.tabRideTrack.UseVisualStyleBackColor = true;

            // 
            // tabStation
            // 
            this.tabStation.Controls.Add(this.checkedListBox_Station);
            this.tabStation.Location = new System.Drawing.Point(4, 29);
            this.tabStation.Name = "tabStation";
            this.tabStation.Padding = new System.Windows.Forms.Padding(3);
            this.tabStation.Size = new System.Drawing.Size(1246, 557);
            this.tabStation.TabIndex = 1;
            this.tabStation.Text = "Station";
            this.tabStation.UseVisualStyleBackColor = true;

            // 
            // tabLSM
            // 
            this.tabLSM.Controls.Add(this.checkedListBox_LSM);
            this.tabLSM.Location = new System.Drawing.Point(4, 29);
            this.tabLSM.Name = "tabLSM";
            this.tabLSM.Padding = new System.Windows.Forms.Padding(3);
            this.tabLSM.Size = new System.Drawing.Size(1246, 557);
            this.tabLSM.TabIndex = 2;
            this.tabLSM.Text = "LSM";
            this.tabLSM.UseVisualStyleBackColor = true;

            // 
            // tabShotgunGate
            // 
            this.tabShotgunGate.Controls.Add(this.checkedListBox_ShotgunGate);
            this.tabShotgunGate.Location = new System.Drawing.Point(4, 29);
            this.tabShotgunGate.Name = "tabShotgunGate";
            this.tabShotgunGate.Padding = new System.Windows.Forms.Padding(3);
            this.tabShotgunGate.Size = new System.Drawing.Size(1246, 557);
            this.tabShotgunGate.TabIndex = 3;
            this.tabShotgunGate.Text = "Shotgun Gate";
            this.tabShotgunGate.UseVisualStyleBackColor = true;

            // 
            // tabTrain
            // 
            this.tabTrain.Controls.Add(this.checkedListBox_Train);
            this.tabTrain.Location = new System.Drawing.Point(4, 29);
            this.tabTrain.Name = "tabTrain";
            this.tabTrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrain.Size = new System.Drawing.Size(1246, 557);
            this.tabTrain.TabIndex = 4;
            this.tabTrain.Text = "Train";
            this.tabTrain.UseVisualStyleBackColor = true;

            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.checkedListBox_Other);
            this.tabOther.Location = new System.Drawing.Point(4, 29);
            this.tabOther.Name = "tabOther";
            this.tabOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabOther.Size = new System.Drawing.Size(1246, 557);
            this.tabOther.TabIndex = 5;
            this.tabOther.Text = "Other";
            this.tabOther.UseVisualStyleBackColor = true;

            // 
            // checkedListBox_RideTrack
            // 
            this.checkedListBox_RideTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_RideTrack.FormattingEnabled = true;
            this.checkedListBox_RideTrack.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_RideTrack.Name = "checkedListBox_RideTrack";
            this.checkedListBox_RideTrack.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_RideTrack.TabIndex = 0;
            this.checkedListBox_RideTrack.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // checkedListBox_Station
            // 
            this.checkedListBox_Station.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Station.FormattingEnabled = true;
            this.checkedListBox_Station.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_Station.Name = "checkedListBox_Station";
            this.checkedListBox_Station.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_Station.TabIndex = 0;
            this.checkedListBox_Station.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // checkedListBox_LSM
            // 
            this.checkedListBox_LSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_LSM.FormattingEnabled = true;
            this.checkedListBox_LSM.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_LSM.Name = "checkedListBox_LSM";
            this.checkedListBox_LSM.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_LSM.TabIndex = 0;
            this.checkedListBox_LSM.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // checkedListBox_ShotgunGate
            // 
            this.checkedListBox_ShotgunGate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_ShotgunGate.FormattingEnabled = true;
            this.checkedListBox_ShotgunGate.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_ShotgunGate.Name = "checkedListBox_ShotgunGate";
            this.checkedListBox_ShotgunGate.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_ShotgunGate.TabIndex = 0;
            this.checkedListBox_ShotgunGate.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // checkedListBox_Train
            // 
            this.checkedListBox_Train.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Train.FormattingEnabled = true;
            this.checkedListBox_Train.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_Train.Name = "checkedListBox_Train";
            this.checkedListBox_Train.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_Train.TabIndex = 0;
            this.checkedListBox_Train.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // checkedListBox_Other
            // 
            this.checkedListBox_Other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Other.FormattingEnabled = true;
            this.checkedListBox_Other.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox_Other.Name = "checkedListBox_Other";
            this.checkedListBox_Other.Size = new System.Drawing.Size(1240, 551);
            this.checkedListBox_Other.TabIndex = 0;
            this.checkedListBox_Other.DoubleClick += new System.EventHandler(this.checkedListBox_DoubleClick);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(912, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSelected.Location = new System.Drawing.Point(1014, 8);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(110, 32);
            this.btnOpenSelected.TabIndex = 2;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);

            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSelected.Location = new System.Drawing.Point(1130, 8);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(136, 32);
            this.btnPrintSelected.TabIndex = 3;
            this.btnPrintSelected.Text = "Print Selected";
            this.btnPrintSelected.UseVisualStyleBackColor = true;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);

            // 
            // lblRootFolder
            // 
            this.lblRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRootFolder.AutoEllipsis = true;
            this.lblRootFolder.Location = new System.Drawing.Point(12, 12);
            this.lblRootFolder.Name = "lblRootFolder";
            this.lblRootFolder.Size = new System.Drawing.Size(660, 23);
            this.lblRootFolder.TabIndex = 4;
            this.lblRootFolder.Text = "Root folder:";

            // 
            // numericUpDownCopies
            // 
            this.numericUpDownCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCopies.Location = new System.Drawing.Point(812, 12);
            this.numericUpDownCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCopies.Name = "numericUpDownCopies";
            this.numericUpDownCopies.Size = new System.Drawing.Size(80, 26);
            this.numericUpDownCopies.TabIndex = 5;
            this.numericUpDownCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // 
            // lblCopies
            // 
            this.lblCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopies.AutoSize = true;
            this.lblCopies.Location = new System.Drawing.Point(754, 14);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(60, 20);
            this.lblCopies.TabIndex = 6;
            this.lblCopies.Text = "Copies:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1278, 648);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.numericUpDownCopies);
            this.Controls.Add(this.lblRootFolder);
            this.Controls.Add(this.btnPrintSelected);
            this.Controls.Add(this.btnOpenSelected);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControlGroups);
            this.Name = "Form1";
            this.Text = "PDF Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((ISupportInitialize)(this.numericUpDownCopies)).EndInit();
            this.tabControlGroups.ResumeLayout(false);
            this.tabRideTrack.ResumeLayout(false);
            this.tabStation.ResumeLayout(false);
            this.tabLSM.ResumeLayout(false);
            this.tabShotgunGate.ResumeLayout(false);
            this.tabTrain.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}