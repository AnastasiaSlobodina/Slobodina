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
    /// Логика взаимодействия для TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        public Frame page;
        Tickets tickets;
        public TicketsPage(Frame pg, int Event_ID)
        {
            InitializeComponent();
            page = pg;
            tickets = new Tickets(Event_ID);
            DataContext = tickets;
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            EmailWindow emailWindow = new EmailWindow(tickets.SelectTicket, tickets);
            emailWindow.ShowDialog();
        }
    }
}
