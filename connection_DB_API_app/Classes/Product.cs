using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Classes
{
    public class Product : Table
    {
        public int kod_producta { get; set; }
        public string nazv_producta { get; set; }
        public int kod_materiala { get; set; }
        public int kod_creatora { get; set; }
        public int cost { get; set; }

    }
}
