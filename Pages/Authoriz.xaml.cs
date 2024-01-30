using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _22_106_Ochapova_MoneyInPocket.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authoriz.xaml
    /// </summary>
    public partial class Authoriz : Window
    {
        public Authoriz()
        {
            InitializeComponent();

            

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
            //SqlDataReader reader = command.ExecuteReader();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=22-106-Ochapova-MoneyInEveryPocket;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlExpression = "Select * from dbo.[User] Where Login = '" + tbLogin.Text + "' and Password = '" + PassBox.Password + "'";// + tbPassword + "";
                //string sqlExpression = "Select IDUser from dbo.[User] Where Login = 11198151 and Password = '3QjGHM'";
                connection.Open();
                string query = $"SELECT * FROM [User] WHERE Login = '{tbLogin.Text}' AND password = '{PassBox.Password}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string login = reader.GetString(1);
                                string password = reader.GetString(2);
                                if (password == PassBox.Password)
                                {
                                    UserPage userPage = new Pages.UserPage(reader);
                                    userPage.Show();
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }

        }
    }
}
