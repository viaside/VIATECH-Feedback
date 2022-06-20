using System;
using System.Collections.Generic;
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
using Npgsql;
using System.Data;

namespace VIATECH_Feedback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NpgsqlConnection npgSqlConnection = null;
        private NpgsqlCommand npgSqlCommand = null;

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public MainWindow()
        {
            InitializeComponent();
            npgSqlConnection = new NpgsqlConnection("Server=localhost;Port=5432;Database=VIAtech;User Id=postgres;Password=zxc;");
            LoadData();
        }

        private void LoadData()
        {
            string sql = (@"SELECT * FROM public.""Orders""");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, npgSqlConnection);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            zxc.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = zxc.SelectedIndex;
            AnswerWindow answerWindow = new AnswerWindow();
            answerWindow.Show();
            string UserName = dt.Rows[id]["Name"].ToString();
            string UserEmail = dt.Rows[id]["Email"].ToString();
            answerWindow.LoadData(UserName, UserEmail);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

    }
}
