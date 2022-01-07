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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int _productId;
        private int _quantity;
        private int _originalQuantity;

        private readonly IHttpStockClientHelper _httpClientHelper;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand UpdateQuantity { get; set; }
        public MainPageViewModel(IHttpStockClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
            UpdateQuantity = new RelayCommand(async () =>
            {
                await _httpClientHelper.UpdateQuantityAsync(
                ProductId, Quantity);
                await RefreshQuantity();
            }, () => Quantity != _originalQuantity);
        }

        public int ProductId 
        { 
            get => _productId;
            set
            {
                if (UpdateField(ref _productId, value))
                    RefreshQuantity();
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (UpdateField(ref _quantity, value))
                    UpdateQuantity.RaiseCanExecuteChanged();
            }
        }
        private bool UpdateField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private async Task RefreshQuantity()
        {
            Quantity = await _httpClientHelper.GetQuantityAsync(ProductId);
            _originalQuantity = Quantity;
            UpdateQuantity.RaiseCanExecuteChanged();
        }
    }
}
