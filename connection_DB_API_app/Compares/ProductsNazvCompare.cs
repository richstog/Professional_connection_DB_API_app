using connection_DB_API_app.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Compares
{
    public class ProductsNazvCompare : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return string.Compare(x.nazv_producta, y.nazv_producta);
        }
    }
}
