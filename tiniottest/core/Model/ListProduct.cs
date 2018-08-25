using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    public class ListProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ImageUri { get; set; }
        public object Details { get; set; }
        public bool Active { get; set; }
        public bool NonInventory { get; set; }
        public bool Customizable { get; set; }
        public bool IsGiftCard { get; set; }
        public object PrinterName { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public string itemPrice
        {
            get
            {
                Product product = Products.FirstOrDefault();
                if (product != null)
                {
                    return String.Format("${0}", product.Price);
                } else
                {
                    return "$0.0";
                }
                
            }
        }
        static string BASE_IMG_URL = "https://www.gposdev.com/20002/images/";

        public string imgUri
        {
            get
            {
                //https://www.gposdev.com/20002/images/pedicure.jpg
                Product product = Products.FirstOrDefault();
                if (product != null)
                {
                    return string.Format("{0}{1}", BASE_IMG_URL, product.ImageUri);
                }
                else
                {
                    return "";
                }
                
            }

        }

    }
}
