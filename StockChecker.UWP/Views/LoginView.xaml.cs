using StockChecker.UWP.Helpers;
using StockChecker.UWP.ViewModels;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StockChecker.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        //public LoginView(IHttpStockClientHelper httpStockClientHelper)
        public LoginView()
        {
            this.InitializeComponent();
            //ViewModel = new LoginViewModel(httpStockClientHelper);
            ViewModel = new LoginViewModel();
            DataContext = ViewModel;
        }
        public LoginViewModel ViewModel { get; set; }
    }
}
