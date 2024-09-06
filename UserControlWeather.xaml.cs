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
using Фигня_по_видеоPR4.DataMode;

namespace Фигня_по_видеоPR4
{
    /// <summary>
    /// Логика взаимодействия для UserControlWeather.xaml
    /// </summary>
    public partial class UserControlWeather : UserControl
    {
        public UserControlWeather()
        {
            InitializeComponent();
        }
        public UserControlWeather( Weather weather)
        {
            InitializeComponent();
            System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["weatherViewSource"];
            myCollectionViewSource.Source = new List<Weather>() { weather };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
