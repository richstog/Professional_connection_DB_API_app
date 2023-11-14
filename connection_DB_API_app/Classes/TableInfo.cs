using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Classes
{
    public class TableInfo
    {
        private string tableName { get; set; }
        private string idName { get; set; }

        private TableInfo(string tableName, string idName)
        {
            this.tableName = tableName;
            this.idName = idName;
        }

        public static TableInfo getTableInfo<T>() where T : Table, new()
        {
            switch (typeof(T).Name)
            {
                case "Creator":
                    return new TableInfo("creators", "kod_creatora");
                case "Product":
                    return new TableInfo("products", "kod_producta");
                case "Material":
                    return new TableInfo("materials", "kod_materiala");
                default:
                    throw new Exception("Несуществующий объект");
            }
        }

        public string getTableName()
        {
            return tableName;
        }

        public string getIdName()
        {
            return idName;
        }
    }
}
