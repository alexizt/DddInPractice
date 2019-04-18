using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DddInPractice.Logic;

namespace DddInPractice.UI.Common
{
    public class SnackMachineViewModel: INotifyPropertyChanged
    {
        private readonly SnackMachine _snackMachine;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Caption => "Snack Machine";


        public CommandInsertMoney cmdInsertCent { get; set; }
        public CommandInsertMoney cmdInsertTenCent { get; set; }
        public CommandInsertMoney cmdInsertQuarter { get; set; }
        public CommandInsertMoney cmdInsertDollar { get; set; }
        public CommandInsertMoney cmdInsertFiveDollar { get; set; }
        public CommandInsertMoney cmdInsertTwentyDollar { get; set; }

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.Amount.ToString();

        //public CommandBase InsertCentCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine) {

            _snackMachine = snackMachine;
            this.cmdInsertCent = new CommandInsertMoney(this, () => InsertMoney(Money.Cent));
            this.cmdInsertTenCent = new CommandInsertMoney(this, () => InsertMoney(Money.TenCent));
            this.cmdInsertQuarter = new CommandInsertMoney(this, () => InsertMoney(Money.Quarter));
            this.cmdInsertDollar = new CommandInsertMoney(this, () => InsertMoney(Money.Dollar));
            this.cmdInsertFiveDollar = new CommandInsertMoney(this, () => InsertMoney(Money.FiveDollar));
            this.cmdInsertTwentyDollar = new CommandInsertMoney(this, () => InsertMoney(Money.TwentyDollar));
        }

        public void InsertMoney(Money money)
        {
            _snackMachine.InsertMoney(money);
            OnPropertyChanged("MoneyInTransaction");
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }  
        
    }
}
