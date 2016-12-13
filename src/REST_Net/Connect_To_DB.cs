using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConnecToDB
{
     class DBConnect
    {
        private MySqlConnection connection;
        ConnectionState conState;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "facebook_data";
            uid = "root";
            password = null;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            conState = connection.State;
        }
        // open connection to database
        private bool OpenConnection()
        {
            try
            {
                if (conState == ConnectionState.Closed || conState == ConnectionState.Broken)
                {
                    connection.Open();
                }
                return true;
            }
            catch(MySqlException ex)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invlid user name and/or password.
                switch(ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Select statement
        public List< string >[] Select()
        {
            string query = "SELECT * FROM collected_info";

            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = (MySqlDataReader)cmd.ExecuteReader();
                
                //Read the data and store them in the list
                while(dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["status_message"] + "");
                    list[2].Add(dataReader["link_name"] + "");
                    list[3].Add(dataReader["link"] + "");
                }

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;

            }
            else
            {
                return list;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO date_time (time) VALUES ('13-11-2016 12:51 PM')"; //this should work with parameters

            //open connection
            if( this.OpenConnection() == true )
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE date_time SET time = '13-11-2016 1:02 PM' WHERE id='1'";

            //Open connection
            if( this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection 
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM date_time WHERE id='1'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand(query, connection);
               //Execute query
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }

        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM date_time";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute scalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");
                //close connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

    }
}
