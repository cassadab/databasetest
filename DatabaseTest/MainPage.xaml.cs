using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace DatabaseTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            String mySqlConnectionString = "YOUR CONNECTION STRING HERE";
            MySqlConnection con = new
                   MySqlConnection(mySqlConnectionString);
            try
            {

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                    String mySqlQuery = "YOUR QUERY HERE";
                    text.Text = "Version:" + con.ServerVersion + "\nState: " + con.State.ToString();
                    MySqlCommand command = new MySqlCommand(mySqlQuery, con);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        text.Text = reader.GetString(0);
                    }

                }
            }
            catch (MySqlException ex)
            {
                text.Text = ex.ToString();

            }
            catch (InvalidOperationException ex) {
                text.Text = ex.ToString();

            }
            finally
            {
                con.Close();
            }

        }
    }
}
