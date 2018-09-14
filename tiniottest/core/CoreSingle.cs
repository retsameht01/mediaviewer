using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiniottest.core.Model;

namespace tiniottest.core
{
    public class CoreSingle
    {
        private static CoreSingle instance;
        private CoreSingle() {
            eventListeners = new List<AppEventListener>();
        }

        public static CoreSingle Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CoreSingle();
                }
                return instance;
            }
        }

        //static string BASE_IMG_URL = "https://www.gposdev.com/20002/images/";

        public String BASE_ASSET_URL { get; set; }

        private List<AppEventListener> eventListeners;

        public void addEventListener(AppEventListener listener)
        {
            eventListeners.Add(listener);
        }

        public void removeEventListener(AppEventListener listener)
        {
            eventListeners.Remove(listener);
        }

        public void reportEvent(EventContainer eventCon) 
        {
            foreach(AppEventListener listener in eventListeners)
            {
                listener.onEvent(eventCon);
            }
        }
    }

    
}
