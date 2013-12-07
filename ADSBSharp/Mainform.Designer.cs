namespace ADSBSharp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tunerGainTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tunerAgcCheckBox = new System.Windows.Forms.CheckBox();
            this.gainLabel = new System.Windows.Forms.Label();
            this.frequencyCorrectionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tunerTypeLabel = new System.Windows.Forms.Label();
            this.rtlAgcCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.confidenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.framesPerSecLbl = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.fpsTimer = new System.Windows.Forms.Timer(this.components);
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.shareCb = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hostnameTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tunerGainTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyCorrectionNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confidenceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(15, 33);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(240, 21);
            this.deviceComboBox.TabIndex = 0;
            this.deviceComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Device";
            // 
            // tunerGainTrackBar
            // 
            this.tunerGainTrackBar.Enabled = false;
            this.tunerGainTrackBar.Location = new System.Drawing.Point(6, 119);
            this.tunerGainTrackBar.Maximum = 10000;
            this.tunerGainTrackBar.Name = "tunerGainTrackBar";
            this.tunerGainTrackBar.Size = new System.Drawing.Size(258, 45);
            this.tunerGainTrackBar.TabIndex = 3;
            this.tunerGainTrackBar.Scroll += new System.EventHandler(this.tunerGainTrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "RF Gain";
            // 
            // tunerAgcCheckBox
            // 
            this.tunerAgcCheckBox.AutoSize = true;
            this.tunerAgcCheckBox.Checked = true;
            this.tunerAgcCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tunerAgcCheckBox.Location = new System.Drawing.Point(15, 83);
            this.tunerAgcCheckBox.Name = "tunerAgcCheckBox";
            this.tunerAgcCheckBox.Size = new System.Drawing.Size(79, 17);
            this.tunerAgcCheckBox.TabIndex = 2;
            this.tunerAgcCheckBox.Text = "Tuner AGC";
            this.tunerAgcCheckBox.UseVisualStyleBackColor = true;
            this.tunerAgcCheckBox.CheckedChanged += new System.EventHandler(this.tunerAgcCheckBox_CheckedChanged);
            // 
            // gainLabel
            // 
            this.gainLabel.Location = new System.Drawing.Point(194, 103);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(68, 13);
            this.gainLabel.TabIndex = 26;
            this.gainLabel.Text = "1000dB";
            this.gainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gainLabel.Visible = false;
            // 
            // frequencyCorrectionNumericUpDown
            // 
            this.frequencyCorrectionNumericUpDown.Location = new System.Drawing.Point(172, 169);
            this.frequencyCorrectionNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.frequencyCorrectionNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.frequencyCorrectionNumericUpDown.Name = "frequencyCorrectionNumericUpDown";
            this.frequencyCorrectionNumericUpDown.Size = new System.Drawing.Size(83, 20);
            this.frequencyCorrectionNumericUpDown.TabIndex = 4;
            this.frequencyCorrectionNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frequencyCorrectionNumericUpDown.ValueChanged += new System.EventHandler(this.frequencyCorrectionNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Frequency correction (ppm)";
            // 
            // tunerTypeLabel
            // 
            this.tunerTypeLabel.Location = new System.Drawing.Point(169, 16);
            this.tunerTypeLabel.Name = "tunerTypeLabel";
            this.tunerTypeLabel.Size = new System.Drawing.Size(93, 13);
            this.tunerTypeLabel.TabIndex = 29;
            this.tunerTypeLabel.Text = "E4000";
            this.tunerTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtlAgcCheckBox
            // 
            this.rtlAgcCheckBox.AutoSize = true;
            this.rtlAgcCheckBox.Location = new System.Drawing.Point(15, 60);
            this.rtlAgcCheckBox.Name = "rtlAgcCheckBox";
            this.rtlAgcCheckBox.Size = new System.Drawing.Size(72, 17);
            this.rtlAgcCheckBox.TabIndex = 1;
            this.rtlAgcCheckBox.Text = "RTL AGC";
            this.rtlAgcCheckBox.UseVisualStyleBackColor = true;
            this.rtlAgcCheckBox.CheckedChanged += new System.EventHandler(this.rtlAgcCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtlAgcCheckBox);
            this.groupBox1.Controls.Add(this.deviceComboBox);
            this.groupBox1.Controls.Add(this.tunerTypeLabel);
            this.groupBox1.Controls.Add(this.tunerGainTrackBar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.frequencyCorrectionNumericUpDown);
            this.groupBox1.Controls.Add(this.tunerAgcCheckBox);
            this.groupBox1.Controls.Add(this.gainLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 202);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTL-SDR Control";
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(12, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.timeoutNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.confidenceNumericUpDown);
            this.groupBox2.Controls.Add(this.framesPerSecLbl);
            this.groupBox2.Controls.Add(this.fpsLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 69);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decoder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Timeout (sec)";
            // 
            // timeoutNumericUpDown
            // 
            this.timeoutNumericUpDown.Location = new System.Drawing.Point(104, 34);
            this.timeoutNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.timeoutNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeoutNumericUpDown.Name = "timeoutNumericUpDown";
            this.timeoutNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.timeoutNumericUpDown.TabIndex = 40;
            this.timeoutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeoutNumericUpDown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.timeoutNumericUpDown.ValueChanged += new System.EventHandler(this.timeoutNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Confidence";
            // 
            // confidenceNumericUpDown
            // 
            this.confidenceNumericUpDown.Location = new System.Drawing.Point(15, 34);
            this.confidenceNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.confidenceNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.confidenceNumericUpDown.Name = "confidenceNumericUpDown";
            this.confidenceNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.confidenceNumericUpDown.TabIndex = 0;
            this.confidenceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.confidenceNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.confidenceNumericUpDown.ValueChanged += new System.EventHandler(this.confidenceNumericUpDown_ValueChanged);
            // 
            // framesPerSecLbl
            // 
            this.framesPerSecLbl.AutoSize = true;
            this.framesPerSecLbl.Location = new System.Drawing.Point(192, 16);
            this.framesPerSecLbl.Name = "framesPerSecLbl";
            this.framesPerSecLbl.Size = new System.Drawing.Size(63, 13);
            this.framesPerSecLbl.TabIndex = 33;
            this.framesPerSecLbl.Text = "Frames/sec";
            // 
            // fpsLabel
            // 
            this.fpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.Location = new System.Drawing.Point(195, 34);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(60, 20);
            this.fpsLabel.TabIndex = 34;
            this.fpsLabel.Text = "FPS";
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fpsTimer
            // 
            this.fpsTimer.Enabled = true;
            this.fpsTimer.Interval = 500;
            this.fpsTimer.Tick += new System.EventHandler(this.fpsTimer_Tick);
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Location = new System.Drawing.Point(184, 15);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.portNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(98, 20);
            this.portNumericUpDown.TabIndex = 1;
            this.portNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portNumericUpDown.Value = new decimal(new int[] {
            47806,
            0,
            0,
            0});
            this.portNumericUpDown.ValueChanged += new System.EventHandler(this.portNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Port";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ADSB#";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // shareCb
            // 
            this.shareCb.AutoSize = true;
            this.shareCb.Location = new System.Drawing.Point(12, 44);
            this.shareCb.Name = "shareCb";
            this.shareCb.Size = new System.Drawing.Size(128, 17);
            this.shareCb.TabIndex = 35;
            this.shareCb.Text = "Share with ADSBHub";
            this.shareCb.UseVisualStyleBackColor = true;
            this.shareCb.CheckedChanged += new System.EventHandler(this.shareCb_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Host";
            // 
            // hostnameTb
            // 
            this.hostnameTb.Enabled = false;
            this.hostnameTb.Location = new System.Drawing.Point(184, 41);
            this.hostnameTb.Name = "hostnameTb";
            this.hostnameTb.Size = new System.Drawing.Size(98, 20);
            this.hostnameTb.TabIndex = 37;
            this.hostnameTb.Text = "sdrsharp.com";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 357);
            this.Controls.Add(this.hostnameTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.shareCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portNumericUpDown);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADSB#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tunerGainTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyCorrectionNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confidenceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tunerGainTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox tunerAgcCheckBox;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.NumericUpDown frequencyCorrectionNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tunerTypeLabel;
        private System.Windows.Forms.CheckBox rtlAgcCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label framesPerSecLbl;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Timer fpsTimer;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown confidenceNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown timeoutNumericUpDown;
        private System.Windows.Forms.CheckBox shareCb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox hostnameTb;
    }
}

