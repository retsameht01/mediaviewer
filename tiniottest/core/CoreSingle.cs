using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core
{
    public class CoreSingle
    {
        private static CoreSingle instance;
        private CoreSingle() { }

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


    }
}
