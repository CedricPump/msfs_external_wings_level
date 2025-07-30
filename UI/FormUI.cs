using System;
using System.Drawing;
using System.Windows.Forms;
using msfs_simple_sail_core.Core;


namespace msfs_simple_sail_core.UI
{
    public partial class FormUI : Form
    {
        private readonly Controller controller;
        private readonly Config Config;

        public FormUI(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            Config = Config.GetInstance();

            this.Text = "MSFS External Wings Level " + VersionHelper.GetVersion();

#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable WFO5001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            if (Application.IsDarkModeEnabled)
            {
                // init components manually
            }
#pragma warning restore WFO5001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning restore CA1416 // Validate platform compatibility


            if (Config.transparencyPercent > 0)
            {
                // Clamp between 0 and 100
                int percent = Math.Max(0, Math.Min(90, Config.transparencyPercent));

                // Convert percent to a value between 0.0 (fully transparent) and 1.0 (fully opaque)
                this.Opacity = 1 - percent / 100.0;
            }

            this.checkBoxAutoPauseAltALG.Checked = Config.autoPauseAltActive;
            this.checkBoxAutoPauseVS.Checked = Config.autoPauseVSActive;
            this.numericUpDownLimitAltAgl.Value = Config.autoPauseAltLimit;
            this.numericUpDownLimitVS.Value = Config.autoPauseVSLimit;

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (this.Config)
            {
                if (!this.Config.autoPauseAltActive && this.checkBoxAutoPauseAltALG.Checked) this.checkBoxAutoPauseAltALG.Checked = false;
                if (!this.Config.autoPauseVSActive && this.checkBoxAutoPauseVS.Checked) this.checkBoxAutoPauseVS.Checked = false;
            }
        }

        private void buttonlvl_Click(object sender, EventArgs e)
        {
            controller.LvlHold = !controller.LvlHold;
            if (controller.LvlHold)
            {
                this.buttonlvl.FlatAppearance.BorderColor = Color.Green;
                // this.buttonlvl.ForeColor = Color.Green;
                this.buttonlvl.ForeColor = SystemColors.ControlText;
                // this.buttonlvl.Text = "¯\\_(ツ)_ /¯";
            }
            else
            {
                this.buttonlvl.FlatAppearance.BorderColor = SystemColors.ControlText;
                this.buttonlvl.ForeColor = SystemColors.ControlText;
                // this.buttonlvl.Text = "LVL";
            }
        }

        private void checkBoxAutoPauseVS_CheckedChanged(object sender, EventArgs e)
        {
            lock (this.Config)
            {
                this.Config.autoPauseVSActive = this.checkBoxAutoPauseVS.Checked;
                try
                {
                    this.Config.Save();
                }
                catch { }
            }
        }

        private void checkBoxAutoPauseAltALG_CheckedChanged(object sender, EventArgs e)
        {
            lock (this.Config)
            {
                this.Config.autoPauseAltActive = this.checkBoxAutoPauseAltALG.Checked;
                try
                {
                    this.Config.Save();
                }
                catch { }
            }
        }

        private void numericUpDownLimitVS_ValueChanged(object sender, EventArgs e)
        {
            this.Config.autoPauseVSLimit = (int)this.numericUpDownLimitVS.Value;
            try
            {
                this.Config.Save();
            }
            catch { }
        }

        private void numericUpDownLimitAltAgl_ValueChanged(object sender, EventArgs e)
        {
            this.Config.autoPauseAltLimit = (int) this.numericUpDownLimitAltAgl.Value;
            try 
            {
                this.Config.Save();
            } catch { }
        }
    }
}
