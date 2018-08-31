using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int DisplayOrder { get; set; }
        public List<ListProduct> ListProducts { get; set; }
        public List<object> Modifiers { get; set; }
    }
}
