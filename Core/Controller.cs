using System;
using System.Collections.Generic;
using System.Windows.Forms;
using msfs_simple_sail;
using msfs_simple_sail_core.UI;


namespace msfs_simple_sail_core.Core
{
    public class Controller
    {
        Plane plane;
        Config config;
        FormUI? form;
        public readonly Autopilot autopilot;
        public Dictionary<string, string> BankHoldControls { get; set; }
        public string BankHoldControlSelected { get; set; }
        public bool APActive { get; set; } = false;
        public bool LvLHold { get; set; } = false;
        public bool BankHold {  get; set; } = false;
        public bool VSActive { get; set; } = false;
        public bool VSHold { get; set; } = false;
        public bool useElevator {  get; set; } = true;
        public int aileronTrimPerc = 0;
        public int elevatorTrimPerc = 0;

        public Controller()
        {
            this.config = Config.Load();
            this.autopilot = new Autopilot();
            this.plane = new Plane(OnPlaneEventCallback);
            this.BankHoldControls = new();
            BankHoldControls.Add("Ailerons Trim", "AILERON TRIM PCT");
            BankHoldControls.Add("Ailerons", "AILERON POSITION");
            BankHoldControls.Add("Rudder Trim", "RUDDER TRIM PCT");
            this.BankHoldControlSelected = "Ailerons Trim";
        }

        private void OnPlaneEventCallback(PlaneEvent planeEvent)
        {
            switch (planeEvent.Event) 
            {
                case Aircraft.EVENTS.AP_MASTER: 
                    {
                        this.ToggleAP();
                        break;
                    }
                case Aircraft.EVENTS.AUTOPILOT_OFF:
                case Aircraft.EVENTS.AUTOPILOT_DISENGAGE_TOGGLE:
                    {
                        this.AP_off();
                        break;
                    }
                case Aircraft.EVENTS.AUTOPILOT_ON:
                    {
                        this.AP_on();
                        break;
                    }
                case Aircraft.EVENTS.AP_WING_LEVELER_ON:
                case Aircraft.EVENTS.AP_BANK_HOLD_ON:

                    {
                        this.LVL_on();
                        break;
                    }
                case Aircraft.EVENTS.AP_WING_LEVELER:
                case Aircraft.EVENTS.AP_BANK_HOLD:
                    {
                        this.ToogleLVL();
                        break;
                    }
                case Aircraft.EVENTS.AP_ALT_HOLD:
                case Aircraft.EVENTS.AP_ALT_HOLD_ON:
                case Aircraft.EVENTS.AP_PANEL_VS_HOLD:
                    {
                        this.VSHold_on();
                        break;
                    }
                default:
                    { break; }
            }

        }

        public void SetUI(FormUI form) 
        {
            this.form = form;
        }

        public void VSHold_on() 
        {
            this.VSHold = true;
            this.VSActive = true;
            this.autopilot.TargetVS = 0;
        }

        public void LVL_on() 
        {
            this.APActive = true;
            this.LvLHold = true;
            this.VSActive = true;
            this.VSHold = true;
            this.BankHold = true;
            this.autopilot.TargetBank = 0;
            this.autopilot.TargetVS = 0;
        }

        public void LVL_off()
        {
            AP_off();
        }

        public void ToogleLVL() 
        {
            if(this.LvLHold)
            {
                LVL_off();
            }
            else 
            {
                LVL_on();
            }
        }

        public void ToggleAP() 
        {
            if(this.APActive) 
            {
                this.AP_off();
            }
            else           
            {
                this.AP_on();
            }
        }

        private void AP_on() 
        {
            this.APActive = true;
            this.BankHold = true;
        }

        private void AP_off()
        {
            this.APActive = false;
            this.LvLHold = false;
            this.VSActive = false;
            this.VSHold = false;
            this.BankHold = false;
        }

        public void Init()
        {
            // Update once to trigger connect to sim
            plane.Update();
            return;
        }

        public bool IsReady() { return plane.isInit; }

        public void Run()
        {
            while (true)
            {
                if (form == null)
                {
                    System.Threading.Thread.Sleep(330);
                    continue;
                }
                try
                {
                    plane.Update();
                    if(!plane.isInit) { 
                        plane.Update();
                        System.Threading.Thread.Sleep(330);
                        continue;
                    };

                    if (plane.Title == null)
                    {
                        plane.Update();
                        System.Threading.Thread.Sleep(330);
                        continue;
                    };

                    if (plane.isInit) 
                    {
                        var BankHoldControles = this.BankHoldControls[BankHoldControlSelected];

                        if (this.APActive) 
                        {
                            (double elevator, double aileron) = autopilot.CalculateRequiredInput(plane.bank, plane.VerticalSpeed);
                            Console.WriteLine($"elev: {elevator} {plane.ElevatorTrimPct}, aile: {aileron} {plane.AileronTrimPct}");

                            this.elevatorTrimPerc = 0;
                            this.aileronTrimPerc = 0;

                            if (this.useElevator && this.VSActive)
                            {
                                this.elevatorTrimPerc = (int)Math.Round(elevator * 100);
                                plane.setValue("ELEVATOR TRIM POSITION", elevator * 0.44); // * 1.0084057139660976);
                            }
                            if (this.BankHold)
                            {
                                this.aileronTrimPerc = (int)Math.Round(aileron * 100);
                                plane.setValue(BankHoldControles, aileron);
                            }
                        }
                        else 
                        {
                            // plane.setValue("ELEVATOR TRIM POSITION", 0);
                            // plane.setValue(BankHoldControles, 0);
                        }

                        // crash protection:
                        if(config.autoPauseVSActive && plane.VerticalSpeed < -config.autoPauseVSLimit) 
                        {
                            plane.setValue("SIM DISABLED", 1);
                            DialogResult result = MessageBox.Show("Simulation stopped for vertical speed", "Sim stopped", MessageBoxButtons.OK);
                            if (result == DialogResult.OK)
                            {
                                config.autoPauseAltActive = false;
                                config.autoPauseVSActive = false;
                                plane.setValue("SIM DISABLED", 0);

                            }
                        }

                        // crash protection:
                        if (config.autoPauseAltActive && plane.AltitudeAGL < config.autoPauseAltLimit)
                        {
                            plane.setValue("SIM DISABLED", 1);
                            DialogResult result = MessageBox.Show("Simulation stopped for altitude", "Sim stopped", MessageBoxButtons.OK);
                            if(result == DialogResult.OK) 
                            {
                                config.autoPauseAltActive = false;
                                config.autoPauseVSActive = false;
                                plane.setValue("SIM DISABLED", 0);
                            }
                        }

                    }

                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                // sleep until next interval
                int intervall = plane.IsSimConnectConnected ? config.RefreshInterval : config.IdleRefreshInterval;
                System.Threading.Thread.Sleep(intervall);
            };
        }
    }
}
