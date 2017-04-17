using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineWPF.Models;

namespace VendingMachineWPF.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        //model the product view model represents
        private VendingItem _model;

        //Maximum number of items for this view model
        private const int _maxQuantity = 10;

        //current amount in the view model
        private int _quantity;

        public int Id
        {
            get
            {
                return _model.Id;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            //quantity can only be set from within this class
            private set
            {
                _quantity = value;
                OnPropertyChanged("OutOfStockMessage");
                OnPropertyChanged("InventoryDisplay");
                OnPropertyChanged("Quantity");
            }
        }

        //A formatted display of inventory in the machine
        //EG: Diet Coke: 10
        public string InventoryDisplay
        {
            get
            {
                return _model.Name + ": " + _quantity;
            }
        }

        public VendingItem Information
        {
            get
            {
                return _model;
            }
        }

        //Determin if we need to display out of stock message ie: cola: 0
        public Visibility OutOfStockMessage
        {
            get
            {
                //if there is some quantity then hide the message
                if(_quantity > 0)
                  return Visibility.Hidden;
                
                //set flag to visible
                return Visibility.Visible;
            }
        }

        public ProductViewModel(int id, string name, double price)
        {
            _model = new VendingItem(id, name, price);
            Quantity = 0;
        }

        public int Refill()
        {
            var amount = _maxQuantity - _quantity;
            Quantity += amount;

            return amount;
        }

        public int Empty()
        {
            var amount = Quantity;
            Quantity = 0;
            return amount;
        }

        public bool Dispense()
        {
            if(Quantity > 0)
            {
                Quantity--;
                return true;
            }

            return false;
        }
    }
}
