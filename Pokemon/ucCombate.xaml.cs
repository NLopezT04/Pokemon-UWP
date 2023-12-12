using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokemon
{
    public sealed partial class ucCombate : UserControl
    {
        public ucCombate()
        {
            this.InitializeComponent();
            int counter = 0;

            Storyboard sb1 = (Storyboard)this.Resources["sbSaludar"];
            while (counter < 4)
            {
                sb1.AutoReverse = true;
                sb1.Begin();
                counter++;
            }
        }

        private void ataqueDescanso(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbDescanso"];
            tbConsola.Text = "¡ SNORLAX usó DESCANSO ! ";
            imZzZ.Width = 40; imZzZ.Height = 40; imZzZ.Visibility = Visibility.Visible;
            sb.Begin();
            this.pbVida.Value += 50;
            if (pbVida.Value >= 100)
            {
                this.imPocion.Opacity = 0.0;
            }
        }

        private void ataqueRizoDefensa(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbDefensa"];
            tbConsola.Text = "¡ SNORLAX usó RIZO DEFENSA ! ";
            ellipse.Visibility = Visibility.Visible;
            ellipse2.Visibility = Visibility.Visible;
            sb.Begin();
            this.pbEscudo.Value += 30;
        }

        private void ataqueGolpeCuerpo(object sender, RoutedEventArgs e)
        {
            tbConsola.Text = "¡ SNORLAX usó AYUDA ! ";
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 3);

            if (value == 0)
            {
                Storyboard sb = (Storyboard)this.Resources["sbDescanso"];
                tbConsola.Text = "¡ SNORLAX usó DESCANSO ! ";
                imZzZ.Width = 40; imZzZ.Height = 40; imZzZ.Visibility = Visibility.Visible;
                sb.Begin();
                this.pbVida.Value += 50;
                if (pbVida.Value >= 100)
                {
                    this.imPocion.Opacity = 0.0;
                }

            }
            else if(value == 1)
            {
                Storyboard sb = (Storyboard)this.Resources["sbDefensa"];
                tbConsola.Text = "¡ SNORLAX usó RIZO DEFENSA ! ";
                ellipse.Visibility = Visibility.Visible;
                ellipse2.Visibility = Visibility.Visible;
                sb.Begin();
                this.pbEscudo.Value += 30;
            }
            else
            {
                tbConsola.Text = "¡ SNORLAX usó TAMBOR ! ";
                path.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Visible;
                image_Copy.Visibility = Visibility.Visible;
                image1.Visibility = Visibility.Visible;
                image1_Copy1.Visibility = Visibility.Visible;
                image2.Visibility = Visibility.Visible;

                pbVida.Value /= 2;
                if (pbVida.Value < 1)
                {
                    consolaKO();
                }
                else
                {
                    Storyboard sb = (Storyboard)this.Resources["sbTambor"];
                    sb.Begin();
                }
                if (pbVida.Value <= 100)
                {
                    this.imPocion.Opacity = 100;
                }
            }
        }

        private void ataqueTambor(object sender, RoutedEventArgs e)
        {
            tbConsola.Text = "¡ SNORLAX usó TAMBOR ! ";
            path.Visibility = Visibility.Visible;
            image.Visibility = Visibility.Visible;
            image_Copy.Visibility = Visibility.Visible;
            image1.Visibility = Visibility.Visible;
            image1_Copy1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Visible;

            pbVida.Value /= 2;
            if (pbVida.Value < 1)
            {
                consolaKO();
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["sbTambor"];
                sb.Begin();
            }
        }

        private void consolaKO()
        {
            Storyboard sb = (Storyboard)this.Resources["sbKO"];
            tbConsola.Text = "¡ SNORLAX se debilitó ! ";
            sb.Begin();
            this.imPocion.Opacity = 0.0;
        }

        private void subirVida(object sender, TappedRoutedEventArgs e)
        {
            this.pbVida.Value = 100;
            this.imPocion.Opacity = 0.0;          
        }
     
    }
}
