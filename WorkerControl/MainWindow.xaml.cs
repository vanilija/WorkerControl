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
using System.Data.SqlClient;
using System.Configuration;


namespace Aplikacija_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private RadnaPovrsina radnaPovrsina;

        // //public MainWindow(RadnaPovrsina radnaPovrsina)
        // //{
        // //    InitializeComponent();
        // //    this.radnaPovrsina = radnaPovrsina;
        // //}

        // //private RadnaPovrsina radnaPovrsina;

        // /* public MainWindow(RadnaPovrsina radnaPovrsina)
        //  {
        //      this.radnaPovrsina = radnaPovrsina;
        //  }
        //*/


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var c = ConfigurationManager.ConnectionStrings["sqlBaza"].ConnectionString;
            SqlConnection vid = new SqlConnection(c);

            //Insert into SQL commands
            SqlCommand xp = new SqlCommand("INSERT INTO Prijava " + "(Operater) VALUES" + "(@Operater)", vid);

            xp.Parameters.AddWithValue("@Operater", Operater.Text);

            vid.Open();
            xp.ExecuteNonQuery();
            vid.Close();

            //SqlCommand xp = new SqlCommand("Select * from Prijava where Operater ='"+Tekst.Text+"', vid);

            //  try
            // {
            //    if()
            //}


            this.Hide();
            RadnaPovrsina radnaPovrsina = new RadnaPovrsina(this);
            radnaPovrsina.Show();
            //MessageBox.Show("Prebacujemo Vas u FAZU kojoj odgovara Vas ID", "Povratna poruka", MessageBoxButton.OK, MessageBoxImage.Asterisk);




        }


    }
}