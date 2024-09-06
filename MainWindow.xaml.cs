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
using System.Threading;
using System.Xml.Linq;
using Фигня_по_видеоPR4.DataMode;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Фигня_по_видеоPR4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Model1 model = new Model1();
        private int Skip = 0;
        private int Take = 25;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(LoadData);
        }

        private void LoadData(object sender)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() =>
            {
                lableLoad.Visibility = Visibility.Visible;
                wrapPanelWeather.Children.Clear();
            }));
            foreach (Weather weather in model.Weather.ToList().Skip(Skip).Take(Take))
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() =>
                {
                    UserControlWeather controlWeather = new UserControlWeather(weather);
                    wrapPanelWeather.Children.Add(controlWeather);
                }));
            }
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)(() =>
            {
                lableLoad.Visibility = Visibility.Collapsed;
            }));
        }
        private void ButtonPlus(object sender, RoutedEventArgs e)
        {
            int Summ = Skip + Take;
            if (model.Weather.ToList().Count > Summ)
            {
                Skip += Take;
                ThreadPool.QueueUserWorkItem(LoadData);
            }
            else if (model.Weather.ToList().Count < Skip)
            {
                Skip += model.Weather.ToList().Count - Skip;
                ThreadPool.QueueUserWorkItem(LoadData);
            }
        }

        private void ButtonMinus(object sender, RoutedEventArgs e)
        {
            if (Skip > Take && Skip != 0)
            {
                Skip += Take;
                ThreadPool.QueueUserWorkItem(LoadData);
            }
            else if (Skip != 0)
            {
                Skip = 0;
                ThreadPool.QueueUserWorkItem(LoadData);
            }
        }
    }
}
