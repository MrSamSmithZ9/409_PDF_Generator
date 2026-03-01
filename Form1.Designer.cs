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
        private TabPage tabDaily; // NEW
        private TabPage tabStation;
        private TabPage tabLSM;
        private TabPage tabShotgunGate;
        private TabPage tabTrain;
        private TabPage tabOther;

        // Switched from CheckedListBox -> ListBox (no checkboxes)
        private ListBox listBox_RideTrack;
        private ListBox listBox_Daily; // NEW
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
            this.cabinNumber_box = new System.Windows.Forms.NumericUpDown();
            this.CabinNumber_label = new System.Windows.Forms.Label();
            this.trainNumber_label = new System.Windows.Forms.Label();
            this.trainNumber_box = new System.Windows.Forms.NumericUpDown();
            this.bogieNumber_label = new System.Windows.Forms.Label();
            this.bogieNumber_box = new System.Windows.Forms.NumericUpDown();
            this.switchNumber_label = new System.Windows.Forms.Label();
            this.switchNumber_box = new System.Windows.Forms.NumericUpDown();
            this.chassisNumber_label = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlGroups.SuspendLayout();
            this.tabDaily.SuspendLayout();
            this.tabRideTrack.SuspendLayout();
            this.tabStation.SuspendLayout();
            this.tabLSM.SuspendLayout();
            this.tabShotgunGate.SuspendLayout();
            this.tabTrain.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.contextMenuQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bogieNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchNumber_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGroups
            // 
            this.tabControlGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGroups.Controls.Add(this.tabDaily);
            this.tabControlGroups.Controls.Add(this.tabRideTrack);
            this.tabControlGroups.Controls.Add(this.tabStation);
            this.tabControlGroups.Controls.Add(this.tabLSM);
            this.tabControlGroups.Controls.Add(this.tabShotgunGate);
            this.tabControlGroups.Controls.Add(this.tabTrain);
            this.tabControlGroups.Controls.Add(this.tabOther);
            this.tabControlGroups.Location = new System.Drawing.Point(16, 76);
            this.tabControlGroups.Name = "tabControlGroups";
            this.tabControlGroups.SelectedIndex = 0;
            this.tabControlGroups.Size = new System.Drawing.Size(426, 207);
            this.tabControlGroups.TabIndex = 0;
            // 
            // tabDaily
            // 
            this.tabDaily.Controls.Add(this.listBox_Daily);
            this.tabDaily.Location = new System.Drawing.Point(4, 22);
            this.tabDaily.Name = "tabDaily";
            this.tabDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaily.Size = new System.Drawing.Size(418, 181);
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
            this.listBox_Daily.Size = new System.Drawing.Size(412, 175);
            this.listBox_Daily.TabIndex = 0;
            this.listBox_Daily.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Daily.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // tabRideTrack
            // 
            this.tabRideTrack.Controls.Add(this.listBox_RideTrack);
            this.tabRideTrack.Location = new System.Drawing.Point(4, 22);
            this.tabRideTrack.Name = "tabRideTrack";
            this.tabRideTrack.Padding = new System.Windows.Forms.Padding(3);
            this.tabRideTrack.Size = new System.Drawing.Size(418, 181);
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
            this.listBox_RideTrack.Size = new System.Drawing.Size(412, 175);
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
            this.tabStation.Size = new System.Drawing.Size(418, 181);
            this.tabStation.TabIndex = 2;
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
            this.listBox_Station.Size = new System.Drawing.Size(412, 175);
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
            this.tabLSM.Size = new System.Drawing.Size(418, 181);
            this.tabLSM.TabIndex = 3;
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
            this.listBox_LSM.Size = new System.Drawing.Size(412, 175);
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
            this.tabShotgunGate.Size = new System.Drawing.Size(418, 181);
            this.tabShotgunGate.TabIndex = 4;
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
            this.listBox_ShotgunGate.Size = new System.Drawing.Size(412, 175);
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
            this.tabTrain.Size = new System.Drawing.Size(418, 181);
            this.tabTrain.TabIndex = 5;
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
            this.listBox_Train.Size = new System.Drawing.Size(412, 175);
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
            this.tabOther.Size = new System.Drawing.Size(418, 181);
            this.tabOther.TabIndex = 6;
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
            this.listBox_Other.Size = new System.Drawing.Size(412, 175);
            this.listBox_Other.TabIndex = 0;
            this.listBox_Other.Click += new System.EventHandler(this.listBox_ItemClick);
            this.listBox_Other.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSelected.Location = new System.Drawing.Point(516, 277);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(120, 30);
            this.btnOpenSelected.TabIndex = 2;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSelected.Location = new System.Drawing.Point(659, 277);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(120, 30);
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
            this.lblRootFolder.Location = new System.Drawing.Point(8, 6);
            this.lblRootFolder.Name = "lblRootFolder";
            this.lblRootFolder.Size = new System.Drawing.Size(429, 23);
            this.lblRootFolder.TabIndex = 4;
            this.lblRootFolder.Text = "Scan folder:";
            // 
            // lblQueue
            // 
            this.lblQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueue.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueue.Location = new System.Drawing.Point(654, 63);
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
            this.listBoxPrintQueue.Location = new System.Drawing.Point(502, 98);
            this.listBoxPrintQueue.Name = "listBoxPrintQueue";
            this.listBoxPrintQueue.Size = new System.Drawing.Size(432, 173);
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
            this.btnClearQueue.Location = new System.Drawing.Point(804, 277);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(120, 30);
            this.btnClearQueue.TabIndex = 11;
            this.btnClearQueue.Text = "Clear";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // btnAddDailyToQueue
            // 
            this.btnAddDailyToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDailyToQueue.Location = new System.Drawing.Point(502, 55);
            this.btnAddDailyToQueue.Name = "btnAddDailyToQueue";
            this.btnAddDailyToQueue.Size = new System.Drawing.Size(85, 37);
            this.btnAddDailyToQueue.TabIndex = 2;
            this.btnAddDailyToQueue.Text = "Add ALL Daily";
            this.btnAddDailyToQueue.UseVisualStyleBackColor = true;
            this.btnAddDailyToQueue.Click += new System.EventHandler(this.btnAddDailyToQueue_Click);
            // 
            // cabinNumber_box
            // 
            this.cabinNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cabinNumber_box.Location = new System.Drawing.Point(107, 335);
            this.cabinNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cabinNumber_box.Name = "cabinNumber_box";
            this.cabinNumber_box.Size = new System.Drawing.Size(34, 20);
            this.cabinNumber_box.TabIndex = 12;
            this.cabinNumber_box.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // CabinNumber_label
            // 
            this.CabinNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CabinNumber_label.AutoSize = true;
            this.CabinNumber_label.Location = new System.Drawing.Point(16, 337);
            this.CabinNumber_label.Name = "CabinNumber_label";
            this.CabinNumber_label.Size = new System.Drawing.Size(85, 13);
            this.CabinNumber_label.TabIndex = 13;
            this.CabinNumber_label.Text = "Cabins Per Train";
            // 
            // trainNumber_label
            // 
            this.trainNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trainNumber_label.AutoSize = true;
            this.trainNumber_label.Location = new System.Drawing.Point(32, 301);
            this.trainNumber_label.Name = "trainNumber_label";
            this.trainNumber_label.Size = new System.Drawing.Size(69, 13);
            this.trainNumber_label.TabIndex = 15;
            this.trainNumber_label.Text = "Active Trains";
            // 
            // trainNumber_box
            // 
            this.trainNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trainNumber_box.Location = new System.Drawing.Point(107, 299);
            this.trainNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainNumber_box.Name = "trainNumber_box";
            this.trainNumber_box.Size = new System.Drawing.Size(34, 20);
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
            this.bogieNumber_label.Location = new System.Drawing.Point(22, 366);
            this.bogieNumber_label.Name = "bogieNumber_label";
            this.bogieNumber_label.Size = new System.Drawing.Size(79, 13);
            this.bogieNumber_label.TabIndex = 17;
            this.bogieNumber_label.Text = "Bogie per Train";
            // 
            // bogieNumber_box
            // 
            this.bogieNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bogieNumber_box.Location = new System.Drawing.Point(107, 364);
            this.bogieNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bogieNumber_box.Name = "bogieNumber_box";
            this.bogieNumber_box.Size = new System.Drawing.Size(34, 20);
            this.bogieNumber_box.TabIndex = 16;
            this.bogieNumber_box.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // switchNumber_label
            // 
            this.switchNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchNumber_label.AutoSize = true;
            this.switchNumber_label.Location = new System.Drawing.Point(152, 303);
            this.switchNumber_label.Name = "switchNumber_label";
            this.switchNumber_label.Size = new System.Drawing.Size(96, 13);
            this.switchNumber_label.TabIndex = 19;
            this.switchNumber_label.Text = "Switches on Track";
            // 
            // switchNumber_box
            // 
            this.switchNumber_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchNumber_box.Location = new System.Drawing.Point(254, 301);
            this.switchNumber_box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.switchNumber_box.Name = "switchNumber_box";
            this.switchNumber_box.Size = new System.Drawing.Size(34, 20);
            this.switchNumber_box.TabIndex = 18;
            this.switchNumber_box.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chassisNumber_label
            // 
            this.chassisNumber_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chassisNumber_label.AutoSize = true;
            this.chassisNumber_label.Location = new System.Drawing.Point(13, 396);
            this.chassisNumber_label.Name = "chassisNumber_label";
            this.chassisNumber_label.Size = new System.Drawing.Size(88, 13);
            this.chassisNumber_label.TabIndex = 21;
            this.chassisNumber_label.Text = "Chassis per Train";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.Location = new System.Drawing.Point(107, 394);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown2.TabIndex = 20;
            this.numericUpDown2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Checklist Selection";
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(969, 442);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chassisNumber_label);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.switchNumber_label);
            this.Controls.Add(this.switchNumber_box);
            this.Controls.Add(this.bogieNumber_label);
            this.Controls.Add(this.bogieNumber_box);
            this.Controls.Add(this.trainNumber_label);
            this.Controls.Add(this.trainNumber_box);
            this.Controls.Add(this.CabinNumber_label);
            this.Controls.Add(this.cabinNumber_box);
            this.Controls.Add(this.btnClearQueue);
            this.Controls.Add(this.listBoxPrintQueue);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblRootFolder);
            this.Controls.Add(this.btnPrintSelected);
            this.Controls.Add(this.btnOpenSelected);
            this.Controls.Add(this.tabControlGroups);
            this.Controls.Add(this.btnAddDailyToQueue);
            this.Name = "Form1";
            this.Text = "PDF Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlGroups.ResumeLayout(false);
            this.tabDaily.ResumeLayout(false);
            this.tabRideTrack.ResumeLayout(false);
            this.tabStation.ResumeLayout(false);
            this.tabLSM.ResumeLayout(false);
            this.tabShotgunGate.ResumeLayout(false);
            this.tabTrain.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.contextMenuQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cabinNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bogieNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchNumber_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown cabinNumber_box;
        private Label CabinNumber_label;
        private Label trainNumber_label;
        private NumericUpDown trainNumber_box;
        private Label bogieNumber_label;
        private NumericUpDown bogieNumber_box;
        private Label switchNumber_label;
        private NumericUpDown switchNumber_box;
        private Label chassisNumber_label;
        private NumericUpDown numericUpDown2;
        private Label label1;
    }
}