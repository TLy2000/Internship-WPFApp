/// Author
/// Thinh Ly
/// 11/12/2020
/// WPF app
///

using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Which is a WPF app to take user first name and last name
    /// And input it to a sql database, and output the entries in the database
    /// </summary>
    public partial class MainWindow : Window
    {
        public string table = "[dbo].[Users]";
        public string name = "UsersNABAdb";
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            // data source for the datagrid
            usersDG.ItemsSource = DataAccess.GetPeople(table, name);
            datagrid = usersDG;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // adds a new user when the button is clicked
            Person user = new Person();
            user.Id = GetID(table, name);
            user.FirstName = firstNameText.Text;
            user.LastName = lastNameText.Text;
            firstNameText.Clear();
            lastNameText.Clear();

            // updates/refreshes the table after the button is pressed
            DataAccess.DatabaseActions(user, table, name);
            LoadUsers();
            usersDG.Items.Refresh();
        }
        private static int GetID(string table, string name)
        {
            // gets the userid, which functions as the primary key
            SqlConnection conn = new SqlConnection(Helper.CnnVal(name));
            Int32 id = 0;
            string sql = "SELECT COUNT(*) Id FROM" + table;
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                // retreive the id count ( number of rows in the table ) and increment it
                conn.Open();
                id = (Int32)cmd.ExecuteScalar();
                id++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            conn.Close();
            return id;
        }
    }
}