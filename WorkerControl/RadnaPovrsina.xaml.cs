using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Threading;

namespace Aplikacija_03
{
    /// <summary>
    /// Interaction logic for RadnaPovrsina.xaml
    /// </summary>
    public partial class RadnaPovrsina : Window
    {
        public DateTime StartTimeStamp { get; set; }

        private MainWindow mainWindow;

        public RadnaPovrsina(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        //Data INPUT 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var provedenoVrijeme = (DateTime.Now - StartTimeStamp).TotalMinutes;

            //This is a connection string for SQL database.
            SqlConnection vid = new SqlConnection("Data Source=KODA\\SQLEXPRESS;Initial Catalog=IzvodOperateri;Integrated Security=True");

            //Insert into SQL commands
            SqlCommand xp = new SqlCommand("INSERT INTO Operateri " +
                "(ID, Artikl, Tehnika, DodatneInformacije, VrijemeUMinutama, TimeStamp) VALUES" +
                "(@ID, @Artikl, @Tehnika, @DodatneInformacije, @VrijemeUMinutama, @TimeStamp)", vid);

            xp.Parameters.AddWithValue("@ID", ID.Text);
            xp.Parameters.AddWithValue("@Artikl", Artikl.Text);
            xp.Parameters.AddWithValue("@Tehnika", Tehnika.Text);
            //xp.Parameters.AddWithValue("@Datum", Datum.Text);
            //xp.Parameters.AddWithValue("@Vrijeme", Vrijeme.Text);
            xp.Parameters.AddWithValue("@DodatneInformacije", DodatneInformacije.Text);
            xp.Parameters.AddWithValue("@VrijemeUMinutama", provedenoVrijeme);
            xp.Parameters.AddWithValue("@TimeStamp", StartTimeStamp);
            //xp.Parameters.AddWithValue("@TimerLabel", TimerLabel.Text);

            //Open and close the connection string
            vid.Open();
            xp.ExecuteNonQuery();
            vid.Close();
            //MessageBox to show the user that the informations are stored into SQL table
            MessageBox.Show("Podaci su uspješno spremljeni!", "Povratna poruka", MessageBoxButton.OK, MessageBoxImage.None);

            MessageBox.Show("Vrijeme provedeno dangubeci: " + provedenoVrijeme);
        }


        //Button which returns the user back to the main screen //not implemented.
        private void Button_Nazad(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();
            MessageBox.Show("Vraćamo VAS na početni zaslon", "Povratna poruka", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }


        //DispatcherTimer - We have an issue to store the time data into SQL.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dateTicker;
            dt.Start();

            StartTimeStamp = DateTime.Now;
        }

        private int increment = 0;

        //TimerLabel
        private void dateTicker(object sender, EventArgs e)
        {
            increment++;

            TimerLabel.Text = increment.ToString();
        }

        private void Validation(object sender, RoutedEventArgs e)
        {
            var c = ConfigurationManager.ConnectionStrings["sqlBaza"].ConnectionString;
            SqlConnection vid = new SqlConnection(c);
        }
    }

}


//TEMP CODE
//private void Button_Click_1(object sender, RoutedEventArgs e)
//{
//    this.Hide();
//    MainWindow mainWindow = new MainWindow(this);
//    mainWindow.Show();
//}
