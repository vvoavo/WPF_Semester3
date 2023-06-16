using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using PropertyChanged;

namespace _02_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private string SelectedRoomType()
        {
            if(cheap.IsChecked == true)
            {
                return "Cheap";
            }
            else if(standart.IsChecked == true)
            {
                return "Standart";
            }
            else if (luxe.IsChecked == true)
            {
                return "luxe";
            }
            else
            {
                return string.Empty;
            }
        }

        private double CountPrice()
        {
            double price = 0;
            price = peopleCount_Slider.Value * 20.0 * (departDateCalendar.SelectedDate.Value - arriveDateCalendar.SelectedDate.Value).TotalDays;
            return price * ComfortValue();
        }

        private double ComfortValue()
        {
            if (cheap.IsChecked == true)
            {
                return 0.8;
            }
            else if (standart.IsChecked == true)
            {
                return 1.1;
            }
            else if (luxe.IsChecked == true)
            {
                return 2.3;
            }
            else
            {
                return 1.0;
            }
        }

        private void confirmBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Personal info:\nName: {nameTextBox.Text}\nSurname: {surnameTextBox.Text}\n\nContact info:\nPhone: {phoneTextBox.Text}\nE-mail: {emailTextBox.Text}\n\nRoom info:\nPeople count: {peopleCount_Slider.Value}\nRoom type: {SelectedRoomType()}\n\nStay time: {arriveDateCalendar.SelectedDate.Value.ToShortDateString()} - {departDateCalendar.SelectedDate.Value.ToShortDateString()}\n\nTotal price: {CountPrice()}$");
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public int peopleCount { get; set; }
        public bool ToU_Accepted { get; set; }

        public ViewModel() 
        {
            peopleCount = 2;
            ToU_Accepted = false;
        }
    }
}
