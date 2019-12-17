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
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        Frame page;
        private Events events;
        public EventsPage(Frame pg, Events ev)
        {
            InitializeComponent();
            page = pg;
            events = ev;
            DataContext = ev;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            page.Content = new FullDescriptionPage(page, events.SelectEvent.Event_ID);
        }
    }
}
