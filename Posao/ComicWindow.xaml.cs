﻿using System;
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
using System.Windows.Shapes;

namespace Posao
{
    /// <summary>
    /// Interaction logic for ComicWindow.xaml
    /// </summary>
    public partial class ComicWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;
        public ComicWindow()
        {
            InitializeComponent();
            ApiHelper2.InitializeClient2();
            dugmeNapred.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber=0)
        {
            var comic = await ComicProcessor.loadComic(imageNumber);

            if(imageNumber==0)
            {
                maxNumber = comic.Num;
            }
            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void dugmeNazad_Click(object sender, RoutedEventArgs e)
        {
            if(currentNumber>1)
            {
                currentNumber -= 1;
                dugmeNapred.IsEnabled = true;
                await LoadImage(currentNumber);

                if(currentNumber==1)
                {
                    dugmeNazad.IsEnabled = false;
                }
            }
        }

        private async void dugmeNapred_Click(object sender, RoutedEventArgs e)
        {
            if(currentNumber<maxNumber)
            {
                currentNumber += 1;
                dugmeNazad.IsEnabled = true;
                await LoadImage(currentNumber);
                if(currentNumber==maxNumber)
                {
                    dugmeNapred.IsEnabled = false;
                }
            }
        }
    }
}
