using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Classes
{
    public class Material : Table
    {
        public int kod_materiala { get; set; }
        public string nazv_materiala { get; set; }
        public string homeland { get; set; }
    }
}
