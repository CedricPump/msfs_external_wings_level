using System.Windows.Forms;

namespace msfs_simple_sail_core.UI
{
    partial class FormUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUI));
            timer1 = new Timer(components);
            buttonlvl = new Button();
            checkBoxAutoPauseVS = new CheckBox();
            checkBoxAutoPauseAltALG = new CheckBox();
            numericUpDownLimitVS = new NumericUpDown();
            numericUpDownLimitAltAgl = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            comboBoxLvlHoldControls = new ComboBox();
            label3 = new Label();
            labelDebugText = new Label();
            label5 = new Label();
            buttonBNK = new Button();
            buttonVS = new Button();
            buttonALT = new Button();
            buttonAP = new Button();
            numericUpDownBNK = new NumericUpDown();
            numericUpDownVS = new NumericUpDown();
            checkBoxUserElevator = new CheckBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitVS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitAltAgl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBNK).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVS).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // buttonlvl
            // 
            buttonlvl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            buttonlvl.FlatStyle = FlatStyle.Flat;
            buttonlvl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttonlvl.ForeColor = System.Drawing.SystemColors.ControlText;
            buttonlvl.Location = new System.Drawing.Point(98, 12);
            buttonlvl.Name = "buttonlvl";
            buttonlvl.Size = new System.Drawing.Size(80, 40);
            buttonlvl.TabIndex = 0;
            buttonlvl.Text = "LVL";
            buttonlvl.UseVisualStyleBackColor = false;
            buttonlvl.Click += buttonlvl_Click;
            // 
            // checkBoxAutoPauseVS
            // 
            checkBoxAutoPauseVS.AutoSize = true;
            checkBoxAutoPauseVS.Location = new System.Drawing.Point(6, 22);
            checkBoxAutoPauseVS.Name = "checkBoxAutoPauseVS";
            checkBoxAutoPauseVS.Size = new System.Drawing.Size(176, 19);
            checkBoxAutoPauseVS.TabIndex = 1;
            checkBoxAutoPauseVS.Text = "auto pause on vertical speed";
            checkBoxAutoPauseVS.UseVisualStyleBackColor = true;
            checkBoxAutoPauseVS.CheckedChanged += checkBoxAutoPauseVS_CheckedChanged;
            // 
            // checkBoxAutoPauseAltALG
            // 
            checkBoxAutoPauseAltALG.AutoSize = true;
            checkBoxAutoPauseAltALG.Location = new System.Drawing.Point(6, 47);
            checkBoxAutoPauseAltALG.Name = "checkBoxAutoPauseAltALG";
            checkBoxAutoPauseAltALG.Size = new System.Drawing.Size(136, 19);
            checkBoxAutoPauseAltALG.TabIndex = 2;
            checkBoxAutoPauseAltALG.Text = "auto pause on alt agl";
            checkBoxAutoPauseAltALG.UseVisualStyleBackColor = true;
            checkBoxAutoPauseAltALG.CheckedChanged += checkBoxAutoPauseAltALG_CheckedChanged;
            // 
            // numericUpDownLimitVS
            // 
            numericUpDownLimitVS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownLimitVS.BorderStyle = BorderStyle.None;
            numericUpDownLimitVS.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownLimitVS.Location = new System.Drawing.Point(297, 24);
            numericUpDownLimitVS.Maximum = new decimal(new int[] { 6000, 0, 0, 0 });
            numericUpDownLimitVS.Minimum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDownLimitVS.Name = "numericUpDownLimitVS";
            numericUpDownLimitVS.Size = new System.Drawing.Size(120, 19);
            numericUpDownLimitVS.TabIndex = 3;
            numericUpDownLimitVS.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownLimitVS.ValueChanged += numericUpDownLimitVS_ValueChanged;
            // 
            // numericUpDownLimitAltAgl
            // 
            numericUpDownLimitAltAgl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownLimitAltAgl.BorderStyle = BorderStyle.None;
            numericUpDownLimitAltAgl.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownLimitAltAgl.Location = new System.Drawing.Point(297, 49);
            numericUpDownLimitAltAgl.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownLimitAltAgl.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownLimitAltAgl.Name = "numericUpDownLimitAltAgl";
            numericUpDownLimitAltAgl.Size = new System.Drawing.Size(120, 19);
            numericUpDownLimitAltAgl.TabIndex = 4;
            numericUpDownLimitAltAgl.Value = new decimal(new int[] { 1500, 0, 0, 0 });
            numericUpDownLimitAltAgl.ValueChanged += numericUpDownLimitAltAgl_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(262, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "fpm";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(264, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 15);
            label2.TabIndex = 6;
            label2.Text = "feet";
            // 
            // comboBoxLvlHoldControls
            // 
            comboBoxLvlHoldControls.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxLvlHoldControls.FormattingEnabled = true;
            comboBoxLvlHoldControls.Location = new System.Drawing.Point(296, 91);
            comboBoxLvlHoldControls.Name = "comboBoxLvlHoldControls";
            comboBoxLvlHoldControls.Size = new System.Drawing.Size(121, 23);
            comboBoxLvlHoldControls.TabIndex = 7;
            comboBoxLvlHoldControls.SelectedIndexChanged += comboBoxLvlHoldControls_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 94);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(138, 15);
            label3.TabIndex = 8;
            label3.Text = "wings level hold controls";
            // 
            // labelDebugText
            // 
            labelDebugText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDebugText.AutoSize = true;
            labelDebugText.Location = new System.Drawing.Point(201, 117);
            labelDebugText.Name = "labelDebugText";
            labelDebugText.Size = new System.Drawing.Size(216, 15);
            labelDebugText.TabIndex = 9;
            labelDebugText.Text = "Aileron Trim: ----% Elevator Trim: ----%";
            labelDebugText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            labelDebugText.Click += labelDebugText_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 117);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(92, 15);
            label5.TabIndex = 10;
            label5.Text = "applied controls";
            // 
            // buttonBNK
            // 
            buttonBNK.FlatStyle = FlatStyle.Flat;
            buttonBNK.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttonBNK.Location = new System.Drawing.Point(184, 12);
            buttonBNK.Name = "buttonBNK";
            buttonBNK.Size = new System.Drawing.Size(80, 40);
            buttonBNK.TabIndex = 12;
            buttonBNK.Text = "BNK";
            buttonBNK.UseVisualStyleBackColor = true;
            buttonBNK.Click += buttonBNK_Click;
            // 
            // buttonVS
            // 
            buttonVS.FlatStyle = FlatStyle.Flat;
            buttonVS.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttonVS.Location = new System.Drawing.Point(270, 12);
            buttonVS.Name = "buttonVS";
            buttonVS.Size = new System.Drawing.Size(80, 40);
            buttonVS.TabIndex = 13;
            buttonVS.Text = "VS";
            buttonVS.UseVisualStyleBackColor = true;
            buttonVS.Click += buttonVS_Click;
            // 
            // buttonALT
            // 
            buttonALT.FlatStyle = FlatStyle.Flat;
            buttonALT.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttonALT.Location = new System.Drawing.Point(355, 12);
            buttonALT.Name = "buttonALT";
            buttonALT.Size = new System.Drawing.Size(80, 40);
            buttonALT.TabIndex = 14;
            buttonALT.Text = "ALT";
            buttonALT.UseVisualStyleBackColor = true;
            buttonALT.Click += buttonALT_Click;
            // 
            // buttonAP
            // 
            buttonAP.FlatStyle = FlatStyle.Flat;
            buttonAP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttonAP.ForeColor = System.Drawing.SystemColors.ControlText;
            buttonAP.Location = new System.Drawing.Point(12, 12);
            buttonAP.Name = "buttonAP";
            buttonAP.Size = new System.Drawing.Size(80, 40);
            buttonAP.TabIndex = 15;
            buttonAP.Text = "AP";
            buttonAP.UseVisualStyleBackColor = true;
            buttonAP.Click += buttonAP_Click;
            // 
            // numericUpDownBNK
            // 
            numericUpDownBNK.BorderStyle = BorderStyle.None;
            numericUpDownBNK.Location = new System.Drawing.Point(184, 58);
            numericUpDownBNK.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            numericUpDownBNK.Minimum = new decimal(new int[] { 45, 0, 0, int.MinValue });
            numericUpDownBNK.Name = "numericUpDownBNK";
            numericUpDownBNK.Size = new System.Drawing.Size(80, 19);
            numericUpDownBNK.TabIndex = 16;
            numericUpDownBNK.ValueChanged += numericUpDownBNK_ValueChanged;
            // 
            // numericUpDownVS
            // 
            numericUpDownVS.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownVS.Location = new System.Drawing.Point(270, 55);
            numericUpDownVS.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownVS.Minimum = new decimal(new int[] { 3000, 0, 0, int.MinValue });
            numericUpDownVS.Name = "numericUpDownVS";
            numericUpDownVS.Size = new System.Drawing.Size(80, 23);
            numericUpDownVS.TabIndex = 17;
            numericUpDownVS.ValueChanged += numericUpDownVS_ValueChanged;
            // 
            // checkBoxUserElevator
            // 
            checkBoxUserElevator.AutoSize = true;
            checkBoxUserElevator.Checked = true;
            checkBoxUserElevator.CheckState = CheckState.Checked;
            checkBoxUserElevator.Location = new System.Drawing.Point(6, 72);
            checkBoxUserElevator.Name = "checkBoxUserElevator";
            checkBoxUserElevator.Size = new System.Drawing.Size(139, 19);
            checkBoxUserElevator.TabIndex = 11;
            checkBoxUserElevator.Text = "user elevator controls";
            checkBoxUserElevator.UseVisualStyleBackColor = true;
            checkBoxUserElevator.CheckedChanged += checkBoxUserElevator_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBoxAutoPauseVS);
            groupBox1.Controls.Add(checkBoxAutoPauseAltALG);
            groupBox1.Controls.Add(checkBoxUserElevator);
            groupBox1.Controls.Add(numericUpDownLimitVS);
            groupBox1.Controls.Add(numericUpDownLimitAltAgl);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelDebugText);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBoxLvlHoldControls);
            groupBox1.Location = new System.Drawing.Point(12, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(423, 143);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // FormUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(449, 232);
            Controls.Add(numericUpDownVS);
            Controls.Add(numericUpDownBNK);
            Controls.Add(buttonAP);
            Controls.Add(buttonALT);
            Controls.Add(buttonVS);
            Controls.Add(buttonBNK);
            Controls.Add(buttonlvl);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormUI";
            Text = "MSFS External Wings Level";
            Load += FormUI_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitVS).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitAltAgl).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBNK).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVS).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Button buttonlvl;
        private CheckBox checkBoxAutoPauseVS;
        private CheckBox checkBoxAutoPauseAltALG;
        private NumericUpDown numericUpDownLimitVS;
        private NumericUpDown numericUpDownLimitAltAgl;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxLvlHoldControls;
        private Label label3;
        private Label labelDebugText;
        private Label label5;
        private Button buttonBNK;
        private Button buttonVS;
        private Button buttonALT;
        private Button buttonAP;
        private NumericUpDown numericUpDownBNK;
        private NumericUpDown numericUpDownVS;
        private CheckBox checkBoxUserElevator;
        private GroupBox groupBox1;
    }

    class DrawPanel : Panel
    {
        public DrawPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}