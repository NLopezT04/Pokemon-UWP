using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Pokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width <= 600)
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
        }

        private void irPokeDex(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(PokedexPage));
        }

        private void irCombate(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(CombatePage));
        }

        private void irInicio(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(MainPage));
            //fmMain.Navigate(typeof(InicioPage));
            //fmMain.Navigate(typeof(MainPage(sView(fmMain(ucInicio))));
            //fmMain.Navigate(typeof(ucInicio));
        }

        private void irCaptura(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(CapturaPage));
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.BackStack.Any())
            {
                fmMain.GoBack();
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen; 
        }

    }
}
