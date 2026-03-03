using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace _409_PDF_Generator
{
    partial class Form1
    {
        private IContainer components = null;

        private TabControl tabControlGroups;
        private TabPage tabRideTrack;
        private TabPage tabDaily; // NEW
        private TabPage tabWeekly; // NEW
        private TabPage tabMonthly; // NEW
        private TabPage tabStation;
        private TabPage tabLSM;
        private TabPage tabShotgunGate;
        private TabPage tabTrain;
        private TabPage tabOther;

        // Switched from CheckedListBox -> ListBox (no checkboxes)
        private ListBox listBox_RideTrack;
        private ListBox listBox_Daily; // NEW
        private ListBox listBox_Weekly; // NEW
        private ListBox listBox_Monthly; // NEW
        private ListBox listBox_Station;
        private ListBox listBox_LSM;
        private ListBox listBox_ShotgunGate;
        private ListBox listBox_Train;
        private ListBox listBox_Other;
        private Button btnOpenSelected;
        private Button btnPrintSelected;
        private Label lblRootFolder;

        // Print queue controls
        private Label lblQueue;
        private ListBox listBoxPrintQueue;
        private Button btnClearQueue;

        // Context menu for print queue (right-click removal)
        private ContextMenuStrip contextMenuQueue;
        private ToolStripMenuItem toolStripMenuItemRemoveFromQueue;

        // NEW: button to add all Daily PDFs to queue
        private Button btnAddDailyToQueue;

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
            this.components = new System.ComponentModel.Container();
            this.tabControlGroups = new System.Windows.Forms.TabControl();
            this.tabDaily = new System.Windows.Forms.TabPage();
            this.listBox_Daily = new System.Windows.Forms.ListBox();
            this.tabWeekly = new System.Windows.Forms.TabPage();
            this.listBox_Weekly = new System.Windows.Forms.ListBox();
            this.tabMonthly = new System.Windows.Forms.TabPage();
            this.listBox_Monthly = new System.Windows.Forms.ListBox();
            this.tabRideTrack = new System.Windows.Forms.TabPage();
            this.listBox_RideTrack = new System.Windows.Forms.ListBox();
            this.tabStation = new System.Windows.Forms.TabPage();
            this.listBox_Station = new System.Windows.Forms.ListBox();
            this.tabLSM = new System.Windows.Forms.TabPage();
            this.listBox_LSM = new System.Windows.Forms.ListBox();
            this.tabShotgunGate = new System.Windows.Forms.TabPage();
            this.listBox_ShotgunGate = new System.Windows.Forms.ListBox();
            this.tabTrain = new System.Windows.Forms.TabPage();
            this.listBox_Train = new System.Windows.Forms.ListBox();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.listBox_Other = new System.Windows.Forms.ListBox();
            this.btnOpenSelected = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.lblRootFolder = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.listBoxPrintQueue = new System.Windows.Forms.ListBox();
            this.contextMenuQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRemoveFromQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.btnAddDailyToQueue = new System.Windows.Forms.Button();
            this.trainNumber_box = new System.Windows.Forms.NumericUpDown();
            this.bogieNumber_label = new System.Windows.Forms.Label();
            this.bogieNumber_box = new System.Windows.Forms.NumericUpDown();
            this.chassisNumber_label = new System.Windows.Forms.Label();
            this.chassisNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.couplingNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.seatNumber = new System.Windows.Forms.NumericUpDown();
            this.cabinNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.waitingNumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.exitNumber = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.stationNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.unloadNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.loadNumber = new System.Windows.Forms.NumericUpDown();
            this.tabControlGroups.SuspendLayout();
            this.tabDaily.SuspendLayout();
            this.tabWeekly.SuspendLayout();
            this.tabMonthly.SuspendLayout();
            this.tabRideTrack.SuspendLayout();
            this.tabStation.SuspendLayout();
            this.tabLSM.SuspendLayout();
            this.tabShotgunGate.SuspendLayout();
            this.tabTrain.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.contextMenuQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bogieNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chassisNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.couplingNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinNumber)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloadNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGroups
            // 
            this.tabControlGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGroups.Controls.Add(this.tabDaily);
            this.tabControlGroups.Controls.Add(this.tabWeekly);
            this.tabControlGroups.Controls.Add(this.tabMonthly);
            this.tabControlGroups.Controls.Add(this.tabRideTrack);
            this.tabControlGroups.Controls.Add(this.tabStation);
            this.tabControlGroups.Controls.Add(this.tabLSM);
            this.tabControlGroups.Controls.Add(this.tabShotgunGate);
            this.tabControlGroups.Controls.Add(this.tabTrain);
            this.tabControlGroups.Controls.Add(this.tabOther);
            this.tabControlGroups.Location = new System.Drawing.Point(16, 42);
            this.tabControlGroups.Name = "tabControlGroups";
            this.tabControlGroups.SelectedIndex = 0;
            this.tabControlGroups.Size = new System.Drawing.Size(524, 207);
            this.tabControlGroups.TabIndex = 0;
            // 
            // tabDaily
            // 
            this.tabDaily.Controls.Add(this.listBox_Daily);
            this.tabDaily.Location = new System.Drawing.Point(4, 22);
            this.tabDaily.Name = "tabDaily";
            this.tabDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaily.Size = new System.Drawing.Size(516, 181);
            this.tabDaily.TabIndex = 1;
            this.tabDaily.Text = "Daily";
            this.tabDaily.UseVisualStyleBackColor = true;
            // 
            // listBox_Daily
            // 
            this.listBox_Daily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Daily.FormattingEnabled = true;
            this.listBox_Daily.Location = new System.Drawing.Point(3, 3);
            this.listBox_Daily.Name = "listBox_Daily";
            this.listBox_Daily.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Daily.Size = new System.Drawing.Size(510, 175);
            this.listBox_Daily.TabIndex = 0;
            this.listBox_Daily.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Daily.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabWeekly
            // 
            this.tabWeekly.Controls.Add(this.listBox_Weekly);
            this.tabWeekly.Location = new System.Drawing.Point(4, 22);
            this.tabWeekly.Name = "tabWeekly";
            this.tabWeekly.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeekly.Size = new System.Drawing.Size(516, 181);
            this.tabWeekly.TabIndex = 2;
            this.tabWeekly.Text = "Weekly";
            this.tabWeekly.UseVisualStyleBackColor = true;
            // 
            // listBox_Weekly
            // 
            this.listBox_Weekly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Weekly.FormattingEnabled = true;
            this.listBox_Weekly.Location = new System.Drawing.Point(3, 3);
            this.listBox_Weekly.Name = "listBox_Weekly";
            this.listBox_Weekly.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Weekly.Size = new System.Drawing.Size(510, 175);
            this.listBox_Weekly.TabIndex = 0;
            this.listBox_Weekly.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Weekly.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabMonthly
            // 
            this.tabMonthly.Controls.Add(this.listBox_Monthly);
            this.tabMonthly.Location = new System.Drawing.Point(4, 22);
            this.tabMonthly.Name = "tabMonthly";
            this.tabMonthly.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonthly.Size = new System.Drawing.Size(516, 181);
            this.tabMonthly.TabIndex = 3;
            this.tabMonthly.Text = "Monthly";
            this.tabMonthly.UseVisualStyleBackColor = true;
            // 
            // listBox_Monthly
            // 
            this.listBox_Monthly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Monthly.FormattingEnabled = true;
            this.listBox_Monthly.Location = new System.Drawing.Point(3, 3);
            this.listBox_Monthly.Name = "listBox_Monthly";
            this.listBox_Monthly.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Monthly.Size = new System.Drawing.Size(510, 175);
            this.listBox_Monthly.TabIndex = 0;
            this.listBox_Monthly.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Monthly.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabRideTrack
            // 
            this.tabRideTrack.Controls.Add(this.listBox_RideTrack);
            this.tabRideTrack.Location = new System.Drawing.Point(4, 22);
            this.tabRideTrack.Name = "tabRideTrack";
            this.tabRideTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tabRideTrack.Size = new System.Drawing.Size(516, 181);
            this.tabRideTrack.TabIndex = 0;
            this.tabRideTrack.Text = "Ride Track";
            this.tabRideTrack.UseVisualStyleBackColor = true;
            // 
            // listBox_RideTrack
            // 
            this.listBox_RideTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_RideTrack.FormattingEnabled = true;
            this.listBox_RideTrack.Location = new System.Drawing.Point(3, 3);
            this.listBox_RideTrack.Name = "listBox_RideTrack";
            this.listBox_RideTrack.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_RideTrack.Size = new System.Drawing.Size(510, 175);
            this.listBox_RideTrack.TabIndex = 0;
            this.listBox_RideTrack.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_RideTrack.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabStation
            // 
            this.tabStation.Controls.Add(this.listBox_Station);
            this.tabStation.Location = new System.Drawing.Point(4, 22);
            this.tabStation.Name = "tabStation";
            this.tabStation.Padding = new System.Windows.Forms.Padding(3);
            this.tabStation.Size = new System.Drawing.Size(516, 181);
            this.tabStation.TabIndex = 4;
            this.tabStation.Text = "Station";
            this.tabStation.UseVisualStyleBackColor = true;
            // 
            // listBox_Station
            // 
            this.listBox_Station.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Station.FormattingEnabled = true;
            this.listBox_Station.Location = new System.Drawing.Point(3, 3);
            this.listBox_Station.Name = "listBox_Station";
            this.listBox_Station.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Station.Size = new System.Drawing.Size(510, 175);
            this.listBox_Station.TabIndex = 0;
            this.listBox_Station.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Station.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabLSM
            // 
            this.tabLSM.Controls.Add(this.listBox_LSM);
            this.tabLSM.Location = new System.Drawing.Point(4, 22);
            this.tabLSM.Name = "tabLSM";
            this.tabLSM.Padding = new System.Windows.Forms.Padding(3);
            this.tabLSM.Size = new System.Drawing.Size(516, 181);
            this.tabLSM.TabIndex = 5;
            this.tabLSM.Text = "LSM";
            this.tabLSM.UseVisualStyleBackColor = true;
            // 
            // listBox_LSM
            // 
            this.listBox_LSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_LSM.FormattingEnabled = true;
            this.listBox_LSM.Location = new System.Drawing.Point(3, 3);
            this.listBox_LSM.Name = "listBox_LSM";
            this.listBox_LSM.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_LSM.Size = new System.Drawing.Size(510, 175);
            this.listBox_LSM.TabIndex = 0;
            this.listBox_LSM.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_LSM.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabShotgunGate
            // 
            this.tabShotgunGate.Controls.Add(this.listBox_ShotgunGate);
            this.tabShotgunGate.Location = new System.Drawing.Point(4, 22);
            this.tabShotgunGate.Name = "tabShotgunGate";
            this.tabShotgunGate.Padding = new System.Windows.Forms.Padding(3);
            this.tabShotgunGate.Size = new System.Drawing.Size(516, 181);
            this.tabShotgunGate.TabIndex = 6;
            this.tabShotgunGate.Text = "Shotgun Gate";
            this.tabShotgunGate.UseVisualStyleBackColor = true;
            // 
            // listBox_ShotgunGate
            // 
            this.listBox_ShotgunGate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_ShotgunGate.FormattingEnabled = true;
            this.listBox_ShotgunGate.Location = new System.Drawing.Point(3, 3);
            this.listBox_ShotgunGate.Name = "listBox_ShotgunGate";
            this.listBox_ShotgunGate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_ShotgunGate.Size = new System.Drawing.Size(510, 175);
            this.listBox_ShotgunGate.TabIndex = 0;
            this.listBox_ShotgunGate.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_ShotgunGate.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabTrain
            // 
            this.tabTrain.Controls.Add(this.listBox_Train);
            this.tabTrain.Location = new System.Drawing.Point(4, 22);
            this.tabTrain.Name = "tabTrain";
            this.tabTrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrain.Size = new System.Drawing.Size(516, 181);
            this.tabTrain.TabIndex = 7;
            this.tabTrain.Text = "Train";
            this.tabTrain.UseVisualStyleBackColor = true;
            // 
            // listBox_Train
            // 
            this.listBox_Train.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Train.FormattingEnabled = true;
            this.listBox_Train.Location = new System.Drawing.Point(3, 3);
            this.listBox_Train.Name = "listBox_Train";
            this.listBox_Train.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Train.Size = new System.Drawing.Size(510, 175);
            this.listBox_Train.TabIndex = 0;
            this.listBox_Train.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Train.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.listBox_Other);
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Name = "tabOther";
            this.tabOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabOther.Size = new System.Drawing.Size(516, 181);
            this.tabOther.TabIndex = 8;
            this.tabOther.Text = "Other";
            this.tabOther.UseVisualStyleBackColor = true;
            // 
            // listBox_Other
            // 
            this.listBox_Other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Other.FormattingEnabled = true;
            this.listBox_Other.Location = new System.Drawing.Point(3, 3);
            this.listBox_Other.Name = "listBox_Other";
            this.listBox_Other.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Other.Size = new System.Drawing.Size(510, 175);
            this.listBox_Other.TabIndex = 0;
            this.listBox_Other.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Other.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSelected.Location = new System.Drawing.Point(564, 240);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(88, 30);
            this.btnOpenSelected.TabIndex = 2;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSelected.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSelected.Location = new System.Drawing.Point(658, 240);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(187, 30);
            this.btnPrintSelected.TabIndex = 3;
            this.btnPrintSelected.Text = "Print ALL";
            this.btnPrintSelected.UseVisualStyleBackColor = true;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // lblRootFolder
            // 
            this.lblRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRootFolder.AutoEllipsis = true;
            this.lblRootFolder.Location = new System.Drawing.Point(20, 414);
            this.lblRootFolder.Name = "lblRootFolder";
            this.lblRootFolder.Size = new System.Drawing.Size(429, 23);
            this.lblRootFolder.TabIndex = 4;
            this.lblRootFolder.Text = "Scan folder:";
            // 
            // lblQueue
            // 
            this.lblQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueue.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueue.Location = new System.Drawing.Point(695, 22);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(150, 23);
            this.lblQueue.TabIndex = 7;
            this.lblQueue.Text = "Print List";
            // 
            // listBoxPrintQueue
            // 
            this.listBoxPrintQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPrintQueue.ContextMenuStrip = this.contextMenuQueue;
            this.listBoxPrintQueue.FormattingEnabled = true;
            this.listBoxPrintQueue.HorizontalScrollbar = true;
            this.listBoxPrintQueue.Location = new System.Drawing.Point(564, 61);
            this.listBoxPrintQueue.Name = "listBoxPrintQueue";
            this.listBoxPrintQueue.Size = new System.Drawing.Size(370, 173);
            this.listBoxPrintQueue.TabIndex = 8;
            this.listBoxPrintQueue.DoubleClick += new System.EventHandler(this.listBoxPrintQueue_DoubleClick);
            this.listBoxPrintQueue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxPrintQueue_MouseDown);
            // 
            // contextMenuQueue
            // 
            this.contextMenuQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRemoveFromQueue});
            this.contextMenuQueue.Name = "contextMenuQueue";
            this.contextMenuQueue.Size = new System.Drawing.Size(185, 26);
            // 
            // toolStripMenuItemRemoveFromQueue
            // 
            this.toolStripMenuItemRemoveFromQueue.Name = "toolStripMenuItemRemoveFromQueue";
            this.toolStripMenuItemRemoveFromQueue.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemRemoveFromQueue.Text = "Remove from Queue";
            this.toolStripMenuItemRemoveFromQueue.Click += new System.EventHandler(this.toolStripMenuItemRemoveFromQueue_Click);
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearQueue.Location = new System.Drawing.Point(851, 240);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(83, 30);
            this.btnClearQueue.TabIndex = 11;
            this.btnClearQueue.Text = "Clear";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // btnAddDailyToQueue
            // 
            this.btnAddDailyToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDailyToQueue.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDailyToQueue.Location = new System.Drawing.Point(564, 24);
            this.btnAddDailyToQueue.Name = "btnAddDailyToQueue";
            this.btnAddDailyToQueue.Size = new System.Drawing.Size(125, 31);
            this.btnAddDailyToQueue.TabIndex = 2;
            this.btnAddDailyToQueue.Text = "Add ALL Daily";
            this.btnAddDailyToQueue.UseVisualStyleBackColor = true;
            this.btnAddDailyToQueue.Click += new System.EventHandler(this.btnAddDailyToQueue_Click);
            // 
            // trainNumber_box
            // 
            this.trainNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trainNumber_box.Location = new System.Drawing.Point(127, 20);
            this.trainNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainNumber_box.Name = "trainNumber_box";
            this.trainNumber_box.Size = new System.Drawing.Size(34, 23);
            this.trainNumber_box.TabIndex = 14;
            this.trainNumber_box.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bogieNumber_label
            // 
            this.bogieNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bogieNumber_label.AutoSize = true;
            this.bogieNumber_label.Location = new System.Drawing.Point(15, 51);
            this.bogieNumber_label.Name = "bogieNumber_label";
            this.bogieNumber_label.Size = new System.Drawing.Size(106, 17);
            this.bogieNumber_label.TabIndex = 17;
            this.bogieNumber_label.Text = "Bogie per Train";
            // 
            // bogieNumber_box
            // 
            this.bogieNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bogieNumber_box.Location = new System.Drawing.Point(127, 49);
            this.bogieNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bogieNumber_box.Name = "bogieNumber_box";
            this.bogieNumber_box.Size = new System.Drawing.Size(34, 23);
            this.bogieNumber_box.TabIndex = 16;
            this.bogieNumber_box.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // chassisNumber_label
            // 
            this.chassisNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chassisNumber_label.AutoSize = true;
            this.chassisNumber_label.Location = new System.Drawing.Point(2, 81);
            this.chassisNumber_label.Name = "chassisNumber_label";
            this.chassisNumber_label.Size = new System.Drawing.Size(119, 17);
            this.chassisNumber_label.TabIndex = 21;
            this.chassisNumber_label.Text = "Chassis per Train";
            // 
            // chassisNumber
            // 
            this.chassisNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chassisNumber.Location = new System.Drawing.Point(127, 79);
            this.chassisNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chassisNumber.Name = "chassisNumber";
            this.chassisNumber.Size = new System.Drawing.Size(34, 23);
            this.chassisNumber.TabIndex = 20;
            this.chassisNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Checklist Selection";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.couplingNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.seatNumber);
            this.groupBox1.Controls.Add(this.cabinNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bogieNumber_label);
            this.groupBox1.Controls.Add(this.bogieNumber_box);
            this.groupBox1.Controls.Add(this.chassisNumber_label);
            this.groupBox1.Controls.Add(this.trainNumber_box);
            this.groupBox1.Controls.Add(this.chassisNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 117);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Train Multipliers";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Seat per Train";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Couplings";
            // 
            // couplingNumber
            // 
            this.couplingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.couplingNumber.Location = new System.Drawing.Point(299, 46);
            this.couplingNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.couplingNumber.Name = "couplingNumber";
            this.couplingNumber.Size = new System.Drawing.Size(34, 23);
            this.couplingNumber.TabIndex = 24;
            this.couplingNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Cabins";
            // 
            // seatNumber
            // 
            this.seatNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seatNumber.Location = new System.Drawing.Point(299, 17);
            this.seatNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seatNumber.Name = "seatNumber";
            this.seatNumber.Size = new System.Drawing.Size(34, 23);
            this.seatNumber.TabIndex = 23;
            this.seatNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // cabinNumber
            // 
            this.cabinNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cabinNumber.Location = new System.Drawing.Point(299, 76);
            this.cabinNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cabinNumber.Name = "cabinNumber";
            this.cabinNumber.Size = new System.Drawing.Size(34, 23);
            this.cabinNumber.TabIndex = 26;
            this.cabinNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Active Trains";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.waitingNumber);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.exitNumber);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.stationNumber);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(405, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 117);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Station Multipliers";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Station Waiting";
            // 
            // waitingNumber
            // 
            this.waitingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waitingNumber.Location = new System.Drawing.Point(130, 78);
            this.waitingNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waitingNumber.Name = "waitingNumber";
            this.waitingNumber.Size = new System.Drawing.Size(34, 23);
            this.waitingNumber.TabIndex = 22;
            this.waitingNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.waitingNumber.ValueChanged += this.waitingNumber_ValueChanged;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Station Exit";
            // 
            // exitNumber
            // 
            this.exitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitNumber.Location = new System.Drawing.Point(130, 49);
            this.exitNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exitNumber.Name = "exitNumber";
            this.exitNumber.Size = new System.Drawing.Size(34, 23);
            this.exitNumber.TabIndex = 20;
            this.exitNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Station";
            // 
            // stationNumber
            // 
            this.stationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stationNumber.Location = new System.Drawing.Point(130, 20);
            this.stationNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stationNumber.Name = "stationNumber";
            this.stationNumber.Size = new System.Drawing.Size(34, 23);
            this.stationNumber.TabIndex = 18;
            this.stationNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.stationNumber.ValueChanged += stationNumber_ValueChanged;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.unloadNumber);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.loadNumber);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(608, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 80);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shotgun Multipliers";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Unload";
            // 
            // unloadNumber
            // 
            this.unloadNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unloadNumber.Location = new System.Drawing.Point(142, 46);
            this.unloadNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.unloadNumber.Name = "unloadNumber";
            this.unloadNumber.Size = new System.Drawing.Size(34, 23);
            this.unloadNumber.TabIndex = 20;
            this.unloadNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.unloadNumber.ValueChanged += UnloadNumber_ValueChanged;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(80, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Load";
            // 
            // loadNumber
            // 
            this.loadNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadNumber.Location = new System.Drawing.Point(142, 17);
            this.loadNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loadNumber.Name = "loadNumber";
            this.loadNumber.Size = new System.Drawing.Size(34, 23);
            this.loadNumber.TabIndex = 18;
            this.loadNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.loadNumber.ValueChanged += LoadNumber_ValueChanged;
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(969, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearQueue);
            this.Controls.Add(this.listBoxPrintQueue);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblRootFolder);
            this.Controls.Add(this.btnPrintSelected);
            this.Controls.Add(this.btnOpenSelected);
            this.Controls.Add(this.tabControlGroups);
            this.Controls.Add(this.btnAddDailyToQueue);
            this.Name = "Form1";
            this.Text = "409 Checklist Generation Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlGroups.ResumeLayout(false);
            this.tabDaily.ResumeLayout(false);
            this.tabWeekly.ResumeLayout(false);
            this.tabMonthly.ResumeLayout(false);
            this.tabRideTrack.ResumeLayout(false);
            this.tabStation.ResumeLayout(false);
            this.tabLSM.ResumeLayout(false);
            this.tabShotgunGate.ResumeLayout(false);
            this.tabTrain.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.contextMenuQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trainNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bogieNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chassisNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.couplingNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinNumber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloadNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadNumber)).EndInit();
            this.ResumeLayout(false);

        }

        private void UnloadNumber_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Unload Number changed to: " + unloadNumber.Value);
        }

        private void LoadNumber_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Load Number changed to: " + loadNumber.Value);
        }

        private void stationNumber_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Station Number changed to: " + stationNumber.Value);
        }

        private void waitingNumber_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Waiting Number changed to: " + waitingNumber.Value);
        }

        #endregion
        private NumericUpDown trainNumber_box;
        private Label bogieNumber_label;
        private NumericUpDown bogieNumber_box;
        private Label chassisNumber_label;
        private NumericUpDown chassisNumber;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown couplingNumber;
        private Label label5;
        private NumericUpDown seatNumber;
        private NumericUpDown cabinNumber;
        private GroupBox groupBox3;
        private Label label8;
        private NumericUpDown waitingNumber;
        private Label label7;
        private NumericUpDown exitNumber;
        private Label label6;
        private NumericUpDown stationNumber;
        private GroupBox groupBox2;
        private Label label10;
        private NumericUpDown unloadNumber;
        private Label label11;
        private NumericUpDown loadNumber;
    }
}