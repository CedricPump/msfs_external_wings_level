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
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitVS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitAltAgl).BeginInit();
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
            buttonlvl.Location = new System.Drawing.Point(12, 12);
            buttonlvl.Name = "buttonlvl";
            buttonlvl.Size = new System.Drawing.Size(496, 56);
            buttonlvl.TabIndex = 0;
            buttonlvl.Text = "LVL";
            buttonlvl.UseVisualStyleBackColor = false;
            buttonlvl.Click += buttonlvl_Click;
            // 
            // checkBoxAutoPauseVS
            // 
            checkBoxAutoPauseVS.AutoSize = true;
            checkBoxAutoPauseVS.Location = new System.Drawing.Point(12, 75);
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
            checkBoxAutoPauseAltALG.Location = new System.Drawing.Point(12, 104);
            checkBoxAutoPauseAltALG.Name = "checkBoxAutoPauseAltALG";
            checkBoxAutoPauseAltALG.Size = new System.Drawing.Size(136, 19);
            checkBoxAutoPauseAltALG.TabIndex = 2;
            checkBoxAutoPauseAltALG.Text = "auto pause on alt agl";
            checkBoxAutoPauseAltALG.UseVisualStyleBackColor = true;
            checkBoxAutoPauseAltALG.CheckedChanged += checkBoxAutoPauseAltALG_CheckedChanged;
            // 
            // numericUpDownLimitVS
            // 
            numericUpDownLimitVS.BorderStyle = BorderStyle.None;
            numericUpDownLimitVS.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownLimitVS.Location = new System.Drawing.Point(388, 74);
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
            numericUpDownLimitAltAgl.BorderStyle = BorderStyle.None;
            numericUpDownLimitAltAgl.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownLimitAltAgl.Location = new System.Drawing.Point(388, 103);
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
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(357, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(25, 15);
            label1.TabIndex = 5;
            label1.Text = "ft/s";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(355, 105);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 15);
            label2.TabIndex = 6;
            label2.Text = "feet";
            // 
            // FormUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(520, 138);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownLimitAltAgl);
            Controls.Add(numericUpDownLimitVS);
            Controls.Add(checkBoxAutoPauseAltALG);
            Controls.Add(checkBoxAutoPauseVS);
            Controls.Add(buttonlvl);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormUI";
            Text = "MSFS Simple Sail";
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitVS).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLimitAltAgl).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }

    class DrawPanel : Panel
    {
        public DrawPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}