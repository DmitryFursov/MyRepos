using ClassLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    class DbHandler
    {
        private static MySqlConnection connection;
        private static string connectionString;

        public DbHandler()
        {
            InitializeComponents();
        }

        void InitializeComponents()
        {
            connectionString = "Server=localhost; Port=3306; Database=mydatabase; Uid=root; Pwd=sql12345678;";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(DataModel dataModel)
        {
            OpenConnection();

            var command = new MySqlCommand();
            command.CommandText = "INSERT INTO datamodel VALUES(@id,@secondname, @firstname, @middlename, @sum, @date, @ispaid)";
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = dataModel.Id;
            command.Parameters.Add("@secondname", MySqlDbType.VarString).Value = dataModel.SecondName;
            command.Parameters.Add("@firstname", MySqlDbType.VarString).Value = dataModel.FirstName;
            command.Parameters.Add("@middlename", MySqlDbType.VarString).Value = dataModel.MiddleName;
            command.Parameters.Add("@sum", MySqlDbType.Int32).Value = dataModel.Sum;
            command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dataModel.Date;//.ToString("yyyy-MM-dd HH:mm:ss");
            command.Parameters.Add("@ispaid", MySqlDbType.Int32).Value = dataModel.IsPaid;

            command.Connection = connection;
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public DataTable Select()
        {
            OpenConnection();

            var command = new MySqlCommand();
            command.CommandText = "SELECT * FROM datamodel";
            command.Connection = connection;
            var adapter = new MySqlDataAdapter(command.CommandText, connection);
            var table = new DataTable();
            adapter.Fill(table);

            

            //var data = command.ExecuteScalar();

            CloseConnection();

            return table;
        }

        public void Delete()
        {
            OpenConnection();
            CloseConnection();
        }
    }
}
