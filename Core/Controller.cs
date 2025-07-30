using System;
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
        Autopilot autopilot;
        public bool LvlHold { get; set; } = false;

        public Controller()
        {
            this.config = Config.Load();
            this.autopilot = new Autopilot();
            plane = new Plane(OnPlaneEventCallback);
        }

        private void OnPlaneEventCallback(PlaneEvent planeEvent)
        {
            // throw new NotImplementedException();
        }

        public void SetUI(FormUI form) 
        {
            this.form = form;
        }

        public void Init()
        {
            // Update once to trigger connect to sim
            plane.Update();
            return;
        }

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
                        if(this.LvlHold) 
                        {
                            (double elevator, double aileron) = autopilot.CalculateRequiredInput(plane.bank, plane.VerticalSpeed);
                            Console.WriteLine($"elev: {elevator} {plane.ElevatorTrimPct}, aile: {aileron} {plane.AileronTrimPct}");

                            if (plane.IsEngineOn)
                            {
                                plane.setValue("ELEVATOR TRIM POSITION", elevator * 0.44); // * 1.0084057139660976);
                            }
                            plane.setValue("AILERON TRIM PCT", aileron);
                        }
                        else 
                        {
                            plane.setValue("ELEVATOR TRIM POSITION", 0);
                            plane.setValue("AILERON TRIM PCT", 0);
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
