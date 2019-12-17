using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;


namespace Афиша_Событий.ViewModel
{
    public class TicketViewModel : Base
    {
        private Ticket tickets;
        public TicketViewModel(Ticket t)
        {
            tickets = t;
        }
        public int Ticket_ID
        {
            get { return tickets.Ticket_ID; }
            set
            {
                tickets.Ticket_ID = value;
                OnPropertyChanged("Ticket_ID");
            }
        }

        public string Code_of_ticket
        {
            get { return tickets.Code_of_ticket; }
            set
            {
                tickets.Code_of_ticket = value;
                OnPropertyChanged("Code_of_ticket");
            }
        }

        public int Row
        {
            get { return tickets.Row; }
            set
            {
                tickets.Row = value;
                OnPropertyChanged("Row");
            }
        }

        public int Place
        {
            get { return tickets.Place; }
            set
            {
                tickets.Place = value;
                OnPropertyChanged("Place");
            }
        }

        public double Price
        {
            get { return tickets.Price; }
            set
            {
                tickets.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public int Status_FK
        {
            get { return tickets.Status_FK; }
            set
            {
                tickets.Status_FK = value;
                OnPropertyChanged("Status_FK");
            }
        }

        public int DateEvent_FK
        {
            get { return tickets.DateEvent_FK; }
            set
            {
                tickets.DateEvent_FK = value;
                OnPropertyChanged("DateEvent_FK");
            }
        }
        public string Status
        {
            get { return tickets.Status.NameS; }
        }

        public DateTime Date
        {
            get { return tickets.DateEvent.Date; }
        }
        public string EventName
        {
            get { return tickets.DateEvent.Event.NameE; }
        }

        public string ImageStatus
        {
            get { return "/Афиша Событий;component/Картинки/Статусы/" + tickets.Status.NameS + ".png"; }
        }

        public bool Booked
        {
            get {
                if (tickets.Status_FK != 1)
                    return false;
                else return true;
            }
        }
    }
}
