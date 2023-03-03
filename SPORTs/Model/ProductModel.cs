using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPORTs.Model
{
    public class ProductModel
    {
        public string id_product { get; set; }
        public string name_product { get; set; }
        public Nullable<int> id_unit { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<double> discount_max { get; set; }
        public Nullable<int> id_developer { get; set; }
        public Nullable<int> id_provider { get; set; }
        public Nullable<int> id_categoty { get; set; }
        public Nullable<double> discount_now { get; set; }
        public Nullable<int> count_ { get; set; }
        public string description { get; set; }
        public string image_ { get; set; }
        public string color { get; set; }
        public Nullable<int> price_now { get; set; }
    }
}
