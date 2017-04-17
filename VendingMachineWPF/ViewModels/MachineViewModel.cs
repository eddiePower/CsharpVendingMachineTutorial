using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineWPF.ViewModels
{
    public class MachineViewModel  : ObservableObject
    {
        //observableCollection is a wpf friendly list of items, in this case our productVMs
        public ObservableCollection<ProductViewModel> Items { get;  private set; }
        public PaymentViewModel Bank { get; private set; }

        public MachineViewModel()
        {
            //create the different objects to make up all areas of the machine.
            Bank = new PaymentViewModel();
            Items = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel(1, "CokaCola", 0.50),
                new ProductViewModel(2, "Diet CokaCola", 0.50),
                new ProductViewModel(3, "Zero CokaCola", 0.80),
                new ProductViewModel(4, "Fanta", 0.75),
                new ProductViewModel(5, "Diet Fanta", 0.75),
           };
        }

        public void Purchase(object item)
        {
            var requestedItem = item as ProductViewModel;
            Bank.SelectedPrice(requestedItem.Information.Price);

            if(Bank.Confirm())
            {
                if(requestedItem.Dispense())
                {
                    Bank.Pay();
                    Console.WriteLine("Enjoy Your " + requestedItem.Information.Name);
                }
            }
        }

        public void InsertChange(double value)
        {
            Bank.Insert(value);
        }

        public void CollectPayments()
        {
            Bank.Collect();
        }

        public void Refill()
        {
            foreach(var i in Items)
            {
                i.Refill();
            }
            Console.WriteLine("Machine has had the stock refilled.");
        }

        public void Empty()
        {
            foreach (var i in Items)
            {
                i.Empty();
            }
            Console.WriteLine("Machine has had the stock Emptied.");
        }
    }
}
