using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace connection_DB_API_app.Classes
{
    public class DBConnect
    {
        private static NpgsqlConnection connection = new NpgsqlConnection(
            "server=localhost;" +
            "port=5432;" +
            "username=postgres;" +
            "password=rhfcbkjdf29;" +
            "database=CreatorsProducts;");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    MessageBox.Show("Подключение не корректно");
                }
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Отключение не корректно");
                }
            }
        }

        public NpgsqlConnection GetConnection()
        {
            return connection;
        }

        public static NpgsqlDataReader getAll<T>(NpgsqlConnection openConnection) where T : Table, new()
        {
            try
            {
                TableInfo tableInfo = TableInfo.getTableInfo<T>();

                string command_string = String.Format("select * from {0};", tableInfo.getTableName());
                NpgsqlCommand command = new NpgsqlCommand(command_string, openConnection);
                NpgsqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public static NpgsqlDataReader getOne<T>(int id, NpgsqlConnection openConnection) where T : Table, new()
        {
            try
            {
                TableInfo tableInfo = TableInfo.getTableInfo<T>();

                connection.Open();
                string command_string = String.Format("select * from {0} where {1} = @{2};", tableInfo.getTableName(), tableInfo.getIdName(), tableInfo.getIdName());
                NpgsqlCommand command = new NpgsqlCommand(command_string, openConnection);
                command.Parameters.Add(String.Format("@{0}", tableInfo.getIdName()), NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
                NpgsqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // CREATORS
        List<Creator> getCreatorsDB()
        {
            List<Creator> creators = new List<Creator>();
            DBConnect db = new DBConnect();
            db.openConnection();
            NpgsqlDataReader creatorReader = getAll<Creator>(db.GetConnection());
            if (creatorReader != null) while (creatorReader.Read())
            {
                Creator creator = new Creator();
                creator.kod_creatora = creatorReader.GetFieldValue<int>(0);
                creator.name = creatorReader.GetFieldValue<string>(1);
                creator.age = creatorReader.GetFieldValue<int>(2);
                creators.Add(creator);
            }
            else
            {
                throw new Exception("Пользователи не найдены");
            }
            db.closeConnection();

            return creators;
        }
    }
}
