﻿using System;
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
    public sealed partial class ucSnorlax : UserControl
    {
        public ucSnorlax()
        {
            this.InitializeComponent();
            int cont = 0;

            Storyboard sb = (Storyboard)this.Resources["sbSaludar"];
            while (cont < 4)
            {
                sb.AutoReverse = true;
                sb.Begin();
                cont++;
            }
        }

        private void Capturar(object sender, TappedRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbCaptura"];
            sb.Begin();
        }
    }
}
