using System;
using System.Collections.Generic;
using System.Windows;

namespace Posao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _symbol;
        
        public List<BerzaModel> ItemsList { get; set; }
        public bool ShowEnabled { get; set; }

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                ShowEnabled = !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
                btnPrikazi.IsEnabled = ShowEnabled;
                
            }
        }

        public MainWindow()
        {
            

            InitializeComponent();
            ShowEnabled = false;
            this.DataContext = this;
            ItemsList = new List<BerzaModel>();
            

            //Inicijalizacija HTTP klijenta 

            ApiHelper.InitializeClient();
        }

        private async void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
            //Hvatanje mogućih izuzetaka i prikazivanje podataka.

            try
            {
                ItemsList = await Processor.prikaziBerzu(Symbol);
                BerzaGrid.ItemsSource = ItemsList;
            }
            catch(Exception)
            {
                MessageBox.Show("Unesite ime simbola u ispravnom formatu (npr. GOOG,AAPL,YHOO...)","Simbol nije u ispravnom formatu" , MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComicWindow prozor= new ComicWindow();
            prozor.Show();
        }
    }
}
