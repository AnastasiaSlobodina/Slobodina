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
    /// Логика взаимодействия для FullDescriptionPage.xaml
    /// </summary>
    public partial class FullDescriptionPage : Page
    {
        public Frame page;
        FullDescriptionEvents ev;
        int id;

        public FullDescriptionPage(Frame pg, int Event_ID)
        {

            InitializeComponent();
            id = Event_ID;
            page = pg;
            DataContext = new FullDescriptionEvents(Event_ID); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            page.Content = new TicketsPage(page, id);
        }
    }
}
