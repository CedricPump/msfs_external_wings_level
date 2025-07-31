namespace msfs_simple_sail
{
    public class Plane : Aircraft
    {
        public delegate void PlaneEventCallBack(PlaneEvent planeEvent);
        private PlaneEventCallBack callBack = null;

        public Plane(PlaneEventCallBack callback): base()
        {
            this.callBack = callback;
        }

        public override void OnEvent(EVENTS recEvent)
        {
            switch (recEvent)
            {
                default:
                    {

                        this.callBack(new PlaneEvent
                        {
                            Event = recEvent,
                            Parameter = null
                        });
                            
                        break;
                    }
                case EVENTS.SimStop:
                    {
                        this.callBack(new PlaneEvent
                        {
                            Event = recEvent,
                            Parameter = new object[0]
                        });
                        break;
                    }
            }
        }

        public override void OnQuit()
        {
            this.callBack(new PlaneEvent
            {
                Event = EVENTS.APPLICATION_QUIT,
                Parameter = new object[0]
            });
            this.isInit = false;
            //System.Environment.Exit(0);
        }
    }
    
}
