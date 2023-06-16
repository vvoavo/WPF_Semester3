using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;

namespace _03._Bindings
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        ObservableCollection<Color> colors = new ObservableCollection<Color>();
        public ColorPicker()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            colorListView.ItemsSource = colors;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            colors.Add(new Color() { R = Convert.ToByte(redSlider.Value), G = Convert.ToByte(greenSlider.Value), B = Convert.ToByte(blueSlider.Value), A = Convert.ToByte(alphaSlider.Value) });
        }

        private void delBTN_Click(object sender, RoutedEventArgs e)
        {
            if (colorListView.SelectedItem != null)
            {
                colors.Remove((Color)colorListView.SelectedItem);
            }
        }
    }

    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }
        public Color Color
        {
            get
            {
                return new Color() { R = Convert.ToByte(Red), G = Convert.ToByte(Green), B = Convert.ToByte(Blue), A = Convert.ToByte(Alpha) };
            }
            set
            {

            }
        }

        public ViewModel()
        {
            Color = new Color();
        }
    }

}
