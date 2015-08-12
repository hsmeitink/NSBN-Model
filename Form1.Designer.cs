namespace NSBN_V._2._1
{
    partial class Form1
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
            this.glControl1 = new OpenTK.GLControl();
            this.btn_StartSimulation = new System.Windows.Forms.Button();
            this.RtxtB_MainTextOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_NoDrawing = new System.Windows.Forms.Button();
            this.btn_DrawFast = new System.Windows.Forms.Button();
            this.chkbox_TextOutput = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_WindowRatioLabel = new System.Windows.Forms.Label();
            this.lbl_InitialSettings = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_ClearRun = new System.Windows.Forms.Button();
            this.btn_DrawSlow = new System.Windows.Forms.Button();
            this.lbl_DrawSpeedIndicator = new System.Windows.Forms.Label();
            this.lbl_DrawSpeedLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbox_strictK = new System.Windows.Forms.CheckBox();
            this.lbl_restartafter = new System.Windows.Forms.Label();
            this.num_RestartAfter = new System.Windows.Forms.NumericUpDown();
            this.chbox_CarnivorPercentage = new System.Windows.Forms.CheckBox();
            this.num_WorldHeight = new System.Windows.Forms.NumericUpDown();
            this.num_WorldWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_WorldWidth = new System.Windows.Forms.Label();
            this.lbl_World_Height = new System.Windows.Forms.Label();
            this.lbl_NValue = new System.Windows.Forms.Label();
            this.lbox_KValues = new System.Windows.Forms.ListBox();
            this.lbl_AgentsPerK = new System.Windows.Forms.Label();
            this.lbl_KBox = new System.Windows.Forms.Label();
            this.num_NValue = new System.Windows.Forms.NumericUpDown();
            this.numUD_AgentsPerKValue = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_RestartAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WorldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WorldWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_NValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AgentsPerKValue)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl1.Location = new System.Drawing.Point(296, 10);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(800, 800);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load_1);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // btn_StartSimulation
            // 
            this.btn_StartSimulation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartSimulation.Location = new System.Drawing.Point(3, 8);
            this.btn_StartSimulation.Name = "btn_StartSimulation";
            this.btn_StartSimulation.Size = new System.Drawing.Size(92, 33);
            this.btn_StartSimulation.TabIndex = 5;
            this.btn_StartSimulation.Text = "Start Simulation";
            this.btn_StartSimulation.UseVisualStyleBackColor = true;
            this.btn_StartSimulation.Click += new System.EventHandler(this.btn_StartSimulation_Click);
            // 
            // RtxtB_MainTextOutput
            // 
            this.RtxtB_MainTextOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RtxtB_MainTextOutput.HideSelection = false;
            this.RtxtB_MainTextOutput.Location = new System.Drawing.Point(13, 536);
            this.RtxtB_MainTextOutput.Name = "RtxtB_MainTextOutput";
            this.RtxtB_MainTextOutput.ReadOnly = true;
            this.RtxtB_MainTextOutput.Size = new System.Drawing.Size(240, 261);
            this.RtxtB_MainTextOutput.TabIndex = 6;
            this.RtxtB_MainTextOutput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turn, Agent_Count";
            // 
            // btn_NoDrawing
            // 
            this.btn_NoDrawing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NoDrawing.Location = new System.Drawing.Point(3, 139);
            this.btn_NoDrawing.Name = "btn_NoDrawing";
            this.btn_NoDrawing.Size = new System.Drawing.Size(92, 33);
            this.btn_NoDrawing.TabIndex = 8;
            this.btn_NoDrawing.Text = "No Drawing";
            this.btn_NoDrawing.UseVisualStyleBackColor = true;
            this.btn_NoDrawing.Click += new System.EventHandler(this.btn_NoDrawing_Click);
            // 
            // btn_DrawFast
            // 
            this.btn_DrawFast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DrawFast.Location = new System.Drawing.Point(3, 100);
            this.btn_DrawFast.Name = "btn_DrawFast";
            this.btn_DrawFast.Size = new System.Drawing.Size(92, 33);
            this.btn_DrawFast.TabIndex = 9;
            this.btn_DrawFast.Text = "Draw Fast";
            this.btn_DrawFast.UseVisualStyleBackColor = true;
            this.btn_DrawFast.Click += new System.EventHandler(this.btn_DrawFast_Click);
            // 
            // chkbox_TextOutput
            // 
            this.chkbox_TextOutput.AutoSize = true;
            this.chkbox_TextOutput.Checked = true;
            this.chkbox_TextOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_TextOutput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_TextOutput.Location = new System.Drawing.Point(129, 507);
            this.chkbox_TextOutput.Name = "chkbox_TextOutput";
            this.chkbox_TextOutput.Size = new System.Drawing.Size(120, 17);
            this.chkbox_TextOutput.TabIndex = 10;
            this.chkbox_TextOutput.Text = "Enable Text Output";
            this.chkbox_TextOutput.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_WindowRatioLabel);
            this.panel1.Controls.Add(this.lbl_InitialSettings);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkbox_TextOutput);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 800);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Aspect Ratio:";
            // 
            // lbl_WindowRatioLabel
            // 
            this.lbl_WindowRatioLabel.AutoSize = true;
            this.lbl_WindowRatioLabel.Location = new System.Drawing.Point(159, 385);
            this.lbl_WindowRatioLabel.Name = "lbl_WindowRatioLabel";
            this.lbl_WindowRatioLabel.Size = new System.Drawing.Size(49, 13);
            this.lbl_WindowRatioLabel.TabIndex = 20;
            this.lbl_WindowRatioLabel.Text = "1111111";
            // 
            // lbl_InitialSettings
            // 
            this.lbl_InitialSettings.AutoSize = true;
            this.lbl_InitialSettings.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InitialSettings.Location = new System.Drawing.Point(16, 12);
            this.lbl_InitialSettings.Name = "lbl_InitialSettings";
            this.lbl_InitialSettings.Size = new System.Drawing.Size(95, 18);
            this.lbl_InitialSettings.TabIndex = 15;
            this.lbl_InitialSettings.Text = "Initial Settings";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_StartSimulation);
            this.panel3.Controls.Add(this.btn_ClearRun);
            this.panel3.Controls.Add(this.btn_DrawSlow);
            this.panel3.Controls.Add(this.lbl_DrawSpeedIndicator);
            this.panel3.Controls.Add(this.btn_DrawFast);
            this.panel3.Controls.Add(this.lbl_DrawSpeedLabel);
            this.panel3.Controls.Add(this.btn_NoDrawing);
            this.panel3.Location = new System.Drawing.Point(145, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(101, 298);
            this.panel3.TabIndex = 19;
            // 
            // btn_ClearRun
            // 
            this.btn_ClearRun.Enabled = false;
            this.btn_ClearRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearRun.Location = new System.Drawing.Point(3, 256);
            this.btn_ClearRun.Name = "btn_ClearRun";
            this.btn_ClearRun.Size = new System.Drawing.Size(92, 33);
            this.btn_ClearRun.TabIndex = 12;
            this.btn_ClearRun.Text = "Clear Run";
            this.btn_ClearRun.UseVisualStyleBackColor = true;
            this.btn_ClearRun.Click += new System.EventHandler(this.btn_ClearRun_Click);
            // 
            // btn_DrawSlow
            // 
            this.btn_DrawSlow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DrawSlow.Location = new System.Drawing.Point(3, 61);
            this.btn_DrawSlow.Name = "btn_DrawSlow";
            this.btn_DrawSlow.Size = new System.Drawing.Size(92, 33);
            this.btn_DrawSlow.TabIndex = 12;
            this.btn_DrawSlow.Text = "Draw Slow";
            this.btn_DrawSlow.UseVisualStyleBackColor = true;
            this.btn_DrawSlow.Click += new System.EventHandler(this.btn_DrawSlow_Click);
            // 
            // lbl_DrawSpeedIndicator
            // 
            this.lbl_DrawSpeedIndicator.AutoSize = true;
            this.lbl_DrawSpeedIndicator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DrawSpeedIndicator.Location = new System.Drawing.Point(14, 197);
            this.lbl_DrawSpeedIndicator.Name = "lbl_DrawSpeedIndicator";
            this.lbl_DrawSpeedIndicator.Size = new System.Drawing.Size(56, 13);
            this.lbl_DrawSpeedIndicator.TabIndex = 17;
            this.lbl_DrawSpeedIndicator.Text = "Draw Fast";
            // 
            // lbl_DrawSpeedLabel
            // 
            this.lbl_DrawSpeedLabel.AutoSize = true;
            this.lbl_DrawSpeedLabel.Location = new System.Drawing.Point(13, 181);
            this.lbl_DrawSpeedLabel.Name = "lbl_DrawSpeedLabel";
            this.lbl_DrawSpeedLabel.Size = new System.Drawing.Size(69, 13);
            this.lbl_DrawSpeedLabel.TabIndex = 16;
            this.lbl_DrawSpeedLabel.Text = "Draw Speed:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chbox_strictK);
            this.panel2.Controls.Add(this.lbl_restartafter);
            this.panel2.Controls.Add(this.num_RestartAfter);
            this.panel2.Controls.Add(this.chbox_CarnivorPercentage);
            this.panel2.Controls.Add(this.num_WorldHeight);
            this.panel2.Controls.Add(this.num_WorldWidth);
            this.panel2.Controls.Add(this.lbl_WorldWidth);
            this.panel2.Controls.Add(this.lbl_World_Height);
            this.panel2.Controls.Add(this.lbl_NValue);
            this.panel2.Controls.Add(this.lbox_KValues);
            this.panel2.Controls.Add(this.lbl_AgentsPerK);
            this.panel2.Controls.Add(this.lbl_KBox);
            this.panel2.Controls.Add(this.num_NValue);
            this.panel2.Controls.Add(this.numUD_AgentsPerKValue);
            this.panel2.Location = new System.Drawing.Point(6, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 473);
            this.panel2.TabIndex = 18;
            // 
            // chbox_strictK
            // 
            this.chbox_strictK.AutoSize = true;
            this.chbox_strictK.Checked = true;
            this.chbox_strictK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbox_strictK.Location = new System.Drawing.Point(13, 419);
            this.chbox_strictK.Name = "chbox_strictK";
            this.chbox_strictK.Size = new System.Drawing.Size(60, 17);
            this.chbox_strictK.TabIndex = 25;
            this.chbox_strictK.Text = "Strict K";
            this.chbox_strictK.UseVisualStyleBackColor = true;
            // 
            // lbl_restartafter
            // 
            this.lbl_restartafter.AutoSize = true;
            this.lbl_restartafter.Location = new System.Drawing.Point(11, 377);
            this.lbl_restartafter.Name = "lbl_restartafter";
            this.lbl_restartafter.Size = new System.Drawing.Size(66, 13);
            this.lbl_restartafter.TabIndex = 24;
            this.lbl_restartafter.Text = "Restart After";
            // 
            // num_RestartAfter
            // 
            this.num_RestartAfter.Location = new System.Drawing.Point(13, 392);
            this.num_RestartAfter.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.num_RestartAfter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.num_RestartAfter.Name = "num_RestartAfter";
            this.num_RestartAfter.Size = new System.Drawing.Size(94, 20);
            this.num_RestartAfter.TabIndex = 23;
            this.num_RestartAfter.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // chbox_CarnivorPercentage
            // 
            this.chbox_CarnivorPercentage.AutoSize = true;
            this.chbox_CarnivorPercentage.Location = new System.Drawing.Point(13, 437);
            this.chbox_CarnivorPercentage.Name = "chbox_CarnivorPercentage";
            this.chbox_CarnivorPercentage.Size = new System.Drawing.Size(123, 17);
            this.chbox_CarnivorPercentage.TabIndex = 21;
            this.chbox_CarnivorPercentage.Text = "Carnivor Percentage";
            this.chbox_CarnivorPercentage.UseVisualStyleBackColor = true;
            // 
            // num_WorldHeight
            // 
            this.num_WorldHeight.Location = new System.Drawing.Point(12, 28);
            this.num_WorldHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_WorldHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_WorldHeight.Name = "num_WorldHeight";
            this.num_WorldHeight.Size = new System.Drawing.Size(92, 20);
            this.num_WorldHeight.TabIndex = 1;
            this.num_WorldHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // num_WorldWidth
            // 
            this.num_WorldWidth.Location = new System.Drawing.Point(12, 72);
            this.num_WorldWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_WorldWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_WorldWidth.Name = "num_WorldWidth";
            this.num_WorldWidth.Size = new System.Drawing.Size(92, 20);
            this.num_WorldWidth.TabIndex = 2;
            this.num_WorldWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lbl_WorldWidth
            // 
            this.lbl_WorldWidth.AutoSize = true;
            this.lbl_WorldWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WorldWidth.Location = new System.Drawing.Point(9, 56);
            this.lbl_WorldWidth.Name = "lbl_WorldWidth";
            this.lbl_WorldWidth.Size = new System.Drawing.Size(70, 13);
            this.lbl_WorldWidth.TabIndex = 3;
            this.lbl_WorldWidth.Text = "World Width:";
            // 
            // lbl_World_Height
            // 
            this.lbl_World_Height.AutoSize = true;
            this.lbl_World_Height.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_World_Height.Location = new System.Drawing.Point(9, 12);
            this.lbl_World_Height.Name = "lbl_World_Height";
            this.lbl_World_Height.Size = new System.Drawing.Size(69, 13);
            this.lbl_World_Height.TabIndex = 4;
            this.lbl_World_Height.Text = "World Height";
            // 
            // lbl_NValue
            // 
            this.lbl_NValue.AutoSize = true;
            this.lbl_NValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NValue.Location = new System.Drawing.Point(11, 336);
            this.lbl_NValue.Name = "lbl_NValue";
            this.lbl_NValue.Size = new System.Drawing.Size(58, 13);
            this.lbl_NValue.TabIndex = 14;
            this.lbl_NValue.Text = "N (nodes):";
            // 
            // lbox_KValues
            // 
            this.lbox_KValues.FormattingEnabled = true;
            this.lbox_KValues.Items.AddRange(new object[] {
            "K = 0",
            "K = 1",
            "K = 2",
            "K = 3",
            "K = 4",
            "K = 5",
            "K = 6",
            "K = 7",
            "K = 8",
            "K = 9",
            "K = 10"});
            this.lbox_KValues.Location = new System.Drawing.Point(12, 121);
            this.lbox_KValues.Name = "lbox_KValues";
            this.lbox_KValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbox_KValues.Size = new System.Drawing.Size(90, 160);
            this.lbox_KValues.TabIndex = 13;
            // 
            // lbl_AgentsPerK
            // 
            this.lbl_AgentsPerK.AutoSize = true;
            this.lbl_AgentsPerK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AgentsPerK.Location = new System.Drawing.Point(12, 293);
            this.lbl_AgentsPerK.Name = "lbl_AgentsPerK";
            this.lbl_AgentsPerK.Size = new System.Drawing.Size(73, 13);
            this.lbl_AgentsPerK.TabIndex = 14;
            this.lbl_AgentsPerK.Text = "Agents Per K:";
            // 
            // lbl_KBox
            // 
            this.lbl_KBox.AutoSize = true;
            this.lbl_KBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KBox.Location = new System.Drawing.Point(9, 105);
            this.lbl_KBox.Name = "lbl_KBox";
            this.lbl_KBox.Size = new System.Drawing.Size(79, 13);
            this.lbl_KBox.TabIndex = 12;
            this.lbl_KBox.Text = "Select K Values";
            // 
            // num_NValue
            // 
            this.num_NValue.Location = new System.Drawing.Point(14, 352);
            this.num_NValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_NValue.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.num_NValue.Name = "num_NValue";
            this.num_NValue.Size = new System.Drawing.Size(92, 20);
            this.num_NValue.TabIndex = 12;
            this.num_NValue.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numUD_AgentsPerKValue
            // 
            this.numUD_AgentsPerKValue.Location = new System.Drawing.Point(12, 309);
            this.numUD_AgentsPerKValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUD_AgentsPerKValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_AgentsPerKValue.Name = "numUD_AgentsPerKValue";
            this.numUD_AgentsPerKValue.Size = new System.Drawing.Size(92, 20);
            this.numUD_AgentsPerKValue.TabIndex = 12;
            this.numUD_AgentsPerKValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 822);
            this.Controls.Add(this.RtxtB_MainTextOutput);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "NSBN Simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_RestartAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WorldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WorldWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_NValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AgentsPerKValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button btn_StartSimulation;
        private System.Windows.Forms.RichTextBox RtxtB_MainTextOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_NoDrawing;
        private System.Windows.Forms.Button btn_DrawFast;
        private System.Windows.Forms.CheckBox chkbox_TextOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_DrawSlow;
        private System.Windows.Forms.Label lbl_DrawSpeedIndicator;
        private System.Windows.Forms.Label lbl_DrawSpeedLabel;
        private System.Windows.Forms.Button btn_ClearRun;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_InitialSettings;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown num_WorldHeight;
        private System.Windows.Forms.NumericUpDown num_WorldWidth;
        private System.Windows.Forms.Label lbl_WorldWidth;
        private System.Windows.Forms.Label lbl_World_Height;
        private System.Windows.Forms.Label lbl_NValue;
        private System.Windows.Forms.ListBox lbox_KValues;
        private System.Windows.Forms.Label lbl_AgentsPerK;
        private System.Windows.Forms.Label lbl_KBox;
        private System.Windows.Forms.NumericUpDown num_NValue;
        private System.Windows.Forms.NumericUpDown numUD_AgentsPerKValue;
        private System.Windows.Forms.Label lbl_WindowRatioLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbox_CarnivorPercentage;
        private System.Windows.Forms.Label lbl_restartafter;
        private System.Windows.Forms.NumericUpDown num_RestartAfter;
        private System.Windows.Forms.CheckBox chbox_strictK;
    }
}

