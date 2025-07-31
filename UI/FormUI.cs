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

            this.Text = "MSFS External Wings Level " + VersionHelper.GetVersion() + " - " + (this.controller.IsReady() ? "(connected)" : "(not connected)");

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
            foreach (var item in controller.BankHoldControls.Keys)
            {
                this.comboBoxLvlHoldControls.Items.Add(item);
            }
            comboBoxLvlHoldControls.Text = controller.BankHoldControlSelected;


            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (this.Config)
            {
                if (!this.Config.autoPauseAltActive && this.checkBoxAutoPauseAltALG.Checked) this.checkBoxAutoPauseAltALG.Checked = false;
                if (!this.Config.autoPauseVSActive && this.checkBoxAutoPauseVS.Checked) this.checkBoxAutoPauseVS.Checked = false;
            }

            // set Buttons
            this.buttonAP.FlatAppearance.BorderColor = this.controller.APActive ? Color.Green : SystemColors.ControlText;
            this.buttonlvl.FlatAppearance.BorderColor = this.controller.LvLHold ? Color.Green : SystemColors.ControlText;
            this.buttonBNK.FlatAppearance.BorderColor = this.controller.BankHold ? Color.Green : SystemColors.ControlText;
            this.buttonVS.FlatAppearance.BorderColor = this.controller.VSActive ? Color.Green : SystemColors.ControlText;
            this.buttonALT.FlatAppearance.BorderColor = this.controller.VSHold ? Color.Green : SystemColors.ControlText;

            this.Text = "MSFS External Wings Level " + VersionHelper.GetVersion() + " - " + (this.controller.IsReady() ? "(connected)" : "(not connected)");

            this.numericUpDownBNK.Value = (decimal) controller.autopilot.TargetBank;
            this.numericUpDownVS.Value = (decimal) controller.autopilot.TargetVS;

            this.labelDebugText.Text = $"{controller.BankHoldControlSelected}: {controller.aileronTrimPerc,4:0}% Elevator Trim: {controller.elevatorTrimPerc,4:0}%";
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
            this.Config.autoPauseAltLimit = (int)this.numericUpDownLimitAltAgl.Value;
            try
            {
                this.Config.Save();
            }
            catch { }
        }

        private void comboBoxLvlHoldControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.controller.BankHoldControlSelected = comboBoxLvlHoldControls.Text;
        }

        private void FormUI_Load(object sender, EventArgs e)
        {

        }

        private void labelDebugText_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxUserElevator_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.useElevator = checkBoxUserElevator.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AP Toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAP_Click(object sender, EventArgs e)
        {
            if (this.controller.APActive)
            {
                controller.APActive = false;
                controller.LvLHold = false;
                controller.BankHold = false;
                controller.VSActive = false;
                controller.VSHold = false;
            }
            else
            {
                this.controller.APActive = true;
                this.controller.BankHold = true;
            }
        }

        /// <summary>
        /// LVL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonlvl_Click(object sender, EventArgs e)
        {

            if (!controller.LvLHold)
            {
                controller.APActive = true;
                controller.LvLHold = true;
                controller.BankHold = true;
                controller.VSActive = true;
                controller.VSHold = true;
                controller.autopilot.TargetBank = 0;
                controller.autopilot.TargetVS = 0;
                this.numericUpDownBNK.Value = 0;
                this.numericUpDownVS.Value = 0;
            }
            else
            {
                controller.APActive = false;
                controller.LvLHold = false;
                controller.BankHold = false;
                controller.VSActive = false;
                controller.VSHold = false;
                // do nothing
            }
        }

        private void buttonBNK_Click(object sender, EventArgs e)
        {
            if (!controller.APActive) return;

            if (controller.BankHold)
            {
                // if active disengege 
                this.controller.BankHold = false;
                if (controller.LvLHold) controller.LvLHold = false;
            }
            else
            {
                // if inactive start
                this.controller.BankHold = true;
            }
        }

        private void buttonVS_Click(object sender, EventArgs e)
        {
            if (!controller.APActive) return;

            if (controller.VSActive)
            {
                // if active disengege 
                this.controller.VSActive = false;
                this.controller.LvLHold = false;
                this.controller.VSHold = false;
            }
            else
            {
                // if inactive start
                this.controller.VSActive = true;
            }
        }

        private void buttonALT_Click(object sender, EventArgs e)
        {
            if (!controller.APActive) return;

            if (controller.VSHold)
            {
                // if active no effect, change target VS to disable 
            }
            else
            {
                // if inactive start
                this.controller.VSHold = true;
                this.controller.VSActive = true;
                this.controller.autopilot.TargetVS = 0;
                this.numericUpDownVS.Value = 0;
            }
        }

        private void numericUpDownBNK_ValueChanged(object sender, EventArgs e)
        {
            if (!controller.APActive) return;

            decimal selcetedBank = this.numericUpDownBNK.Value;
            if (controller.BankHold)
            {
                this.controller.autopilot.TargetBank = (double)selcetedBank;
            }

            if(selcetedBank != 0) this.controller.LvLHold = false;
        }

        private void numericUpDownVS_ValueChanged(object sender, EventArgs e)
        {
            if (!controller.APActive) return;

            decimal selcetedVS = this.numericUpDownVS.Value;
            if (selcetedVS != 0)
            {
                this.controller.LvLHold = false;
                this.controller.VSHold = false;
                this.controller.autopilot.TargetVS = (double)selcetedVS;
            }
        }
    }
}
