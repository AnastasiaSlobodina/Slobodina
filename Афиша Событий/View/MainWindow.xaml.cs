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
using Афиша_Событий.ViewModel;

namespace Афиша_Событий.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Events events;
        public MainWindow()
        {
            InitializeComponent();
            events = new Events();
            Page.Content = new EventsPage(Page, events);
            DataContext = new MainViewModel(events);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new EventsPage(Page, events);
        }
    }
}
