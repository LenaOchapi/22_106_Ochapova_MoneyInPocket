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
using System.Windows.Shapes;

namespace _22_106_Ochapova_MoneyInPocket.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        public UserPage(SqlDataReader reader)
        {
            InitializeComponent();
            
            tbl_fio.Text =  reader.GetString(3) + " " +reader.GetString(4) +" "+ reader.GetString(5);
            tbPhone.Text = reader.GetString(8);
            tbAdress.Text = reader.GetString(9);
            tbEmail.Text = reader.GetString(10);
            DateTime Date = reader.GetDateTime(13);
            tbBirth.Text = Date.ToString();
            tbBirthPlace.Text = reader.GetString(14);
        }
    }
}
