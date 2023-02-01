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

namespace OnlineOra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sliRed.Value = 255;
            sliGreen.Value = 255;
            sliBlue.Value = 255;
        }

        private void changeColorSlider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red = Convert.ToByte(sliRed.Value);
            byte green = Convert.ToByte(sliGreen.Value);
            byte blue = Convert.ToByte(sliBlue.Value);
            this.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        private void changeColorBox(object sender, TextChangedEventArgs e)
        {
            byte red = Convert.ToByte(sliRed.Value);
            byte green = Convert.ToByte(sliGreen.Value);
            byte blue = Convert.ToByte(sliBlue.Value);
            this.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        private void Rogzit_Click(object sender, RoutedEventArgs e)
        {
            byte red = Convert.ToByte(sliRed.Value);
            byte green = Convert.ToByte(sliGreen.Value);
            byte blue = Convert.ToByte(sliBlue.Value);
            string szin = red + ";" + green + ";" + blue;
            int sameCounter = 0;
            for (int i = 0; i < szinekbox.Items.Count; i++)
            {
                if (szin == szinekbox.Items[i].ToString())
                {
                    sameCounter++;
                }
            }
            if (sameCounter == 0)
            {
                szinekbox.Items.Add(szin);
            }
            else
            {
                MessageBox.Show("Már létezik ez a szín a listában!");
            }

        }

        private void Torol_Click(object sender, RoutedEventArgs e)
        {
            if (szinekbox.SelectedIndex >= 0)
            {
                szinekbox.Items.RemoveAt(szinekbox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincsen kiválasztva semmi a listában!");
            }
        }

        private void Urit_Click(object sender, RoutedEventArgs e)
        {
            szinekbox.Items.Clear();
        }

        private void setSzin(object sender, RoutedEventArgs e)
        {
            if (szinekbox.SelectedIndex != -1)
            {
                string[] tagok = szinekbox.Items[szinekbox.SelectedIndex].ToString().Split(';');
                sliRed.Value = Convert.ToByte(tagok[0]);
                sliGreen.Value = Convert.ToByte(tagok[1]);
                sliBlue.Value = Convert.ToByte(tagok[2]);
            }
        }
    }
}
