using StockChecker.UWP.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockChecker.UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(() => DoLogin());
        }

        private void DoLogin()
        {
            throw new NotImplementedException();
        }

        public RelayCommand LoginCommand { get; set; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                UpdateField(ref _username, value);
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                UpdateField(ref _password, value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool UpdateField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
