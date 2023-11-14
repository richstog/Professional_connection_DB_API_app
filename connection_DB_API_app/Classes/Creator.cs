using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Classes
{
    public class Creator : Table
    {
        public int kod_creatora { get; set; }
        public string name{ get; set; }
        public int age { get; set; }
    }
}
