using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineWPF.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        //Customer output information
        private double _total;
        private double _inserted;
        private double _change;

        //Macahine information
        private double _bankTotal;

        public double Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
                OnPropertyChanged("Total"); 
            }
        }

        public double Inserted
        {
            get
            {
                return _inserted;
            }

            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {
            get
            {
                return _change;
            }

            set
            {
                _change = value;
                OnPropertyChanged("Change");
            }
        }

        public double BankTotal
        {
            get
            {
                return _bankTotal;
            }

            set
            {
                _bankTotal = value;
                OnPropertyChanged("BankTotal");
            }
        }

        public PaymentViewModel()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }

        //Inserting money values for transaction
        public void Insert(double value)
        {
            Inserted += value;
        }

        //set total of requested item cost
        public void SelectedPrice(double value)
        {
            Total = value;
        }

        //Confirm that they payment can be made
        public bool Confirm()
        {
            if (Inserted >= Total)
            {
                return true;
            }
            else
            {
                Console.WriteLine("The Amount entered is not enough for the item selected");
                return false;
            }

            
        }

        public void Pay()
        {
            Change = -Total - -Inserted;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;
        }

        public void Collect()
        {
            Console.WriteLine("Collected $" + string.Format("{0:0.00}", BankTotal) + " from the machine.");
            BankTotal = 0;
        }
        
    }
}
