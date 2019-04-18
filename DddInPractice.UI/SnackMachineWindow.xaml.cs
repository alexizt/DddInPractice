using DddInPractice.Logic;
using DddInPractice.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DddInPractice.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SnackMachineWindow : Window
    {


        

        public SnackMachineWindow()
        {
            InitializeComponent();
            var _viewModel = new SnackMachineViewModel(new Logic.SnackMachine());
            this.DataContext = _viewModel;
            this.btnCent_Copy.CommandParameter = Money.Cent;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    switch (((Button)sender).Name)
        //    {
        //        case "btnDollar":
        //            ((SnackMachineViewModel)this.DataContext).InsertMoney(Money.Dollar);
        //            break;
        //        case "btnCent":
        //            ((SnackMachineViewModel)this.DataContext).InsertMoney(Money.Cent);
        //            break;
        //        case "btnTenCent":
        //            ((SnackMachineViewModel)this.DataContext).InsertMoney(Money.TenCent);
        //            break;

        //        default:
        //            break;
        //    }

        //}
    }
}
