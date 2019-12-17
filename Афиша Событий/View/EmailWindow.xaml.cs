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
using System.Windows.Shapes;
using Афиша_Событий.ViewModel;

namespace Афиша_Событий.View
{
    /// <summary>
    /// Логика взаимодействия для EmailWindow.xaml
    /// </summary>
    public partial class EmailWindow : Window
    {
        public EmailWindow(TicketViewModel t)
        {
            InitializeComponent();
            DataContext = new Users(t);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }        
    }
}
