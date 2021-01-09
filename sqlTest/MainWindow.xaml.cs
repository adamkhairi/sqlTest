using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace sqlTest
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _conString = @"Data Source=DESKTOP-AGEVIQ5;Initial Catalog=congee;Integrated Security=True";
        private SqlConnection _cnx;
        private SqlCommand _sql;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (userRole.SelectedItem == null && userName.Text == "" && userMail.Text == "" && userPassword.Text == "")
            {
                return;
            }
            else
            {
                var name = userName.Text;
                var email = userMail.Text;
                var password = userPassword.Text;
                var value = (ComboBoxItem) userRole.SelectedValue;
                var role = (string) value.Content;


                _cnx = new SqlConnection(_conString);
                var query = "insert into userT(userName,user_email,user_password,user_role) values('"+ name + "','" + email + "','" + password + "','" + role + "')";
                //var query1 = "insert into users values(,'name','a@a.a','password','gg')";
                try
                {
                    _sql = new SqlCommand(query, _cnx);
                    _cnx.Open();
                    _sql.ExecuteNonQuery();
                    
                    MessageBox.Show("Saved !!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Not Saved");
                }
                finally
                {
                    _cnx.Close();
                }
            }
        }
    }
}