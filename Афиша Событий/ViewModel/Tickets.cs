using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;

namespace Афиша_Событий.ViewModel
{
    public class Tickets : Base
    {
        Model1 db;
        public EventViewModel evm { get; set; }
        private List<TicketViewModel> allTickets;
        public List<TicketViewModel> AllTickets
        {
            get { return allTickets; }
            set
            {
                allTickets = value; OnPropertyChanged("AllTickets");
            }
        }

        private List<DateEventViewModel> allDate;
        public List<DateEventViewModel> AllDate
        {
            get { return allDate; }
            set
            {
                allDate = value; OnPropertyChanged("AllDate");
            }
        }
        public Tickets(int Event_ID)
        {
            db = new Model1();
            Event ev = db.Event.Find(Event_ID);
            evm = new EventViewModel(ev);
            AllDate = db.DateEvent.Where(i => i.Event_FK == Event_ID).ToList().Select(i => new DateEventViewModel(i)).ToList();
        }

        private DateEventViewModel selectDate;
        public DateEventViewModel SelectDate
        {
            get
            {
                return selectDate;
            }
            set
            {
                selectDate = value;
                OnPropertyChanged("SelectDate");
            }
        }

        private TicketViewModel selectTicket;
        public TicketViewModel SelectTicket
        {
            get
            {
                return selectTicket;
            }
            set
            {
                selectTicket= value;
                OnPropertyChanged("SelectTicket");
            }
        }

        private RelayCommand bookingEvent;
        public RelayCommand BookingEvent
        {
            get
            {
                return bookingEvent ??
                  (bookingEvent = new RelayCommand(obj => { },

                 //условие, при котором будет доступна команда
                 (obj) => (selectTicket != null && selectTicket.Status_FK == 1)));
            }
        }

        public int ID;
        private RelayCommand selectedCommand;
        public RelayCommand SelectedCommand
        {
            get
            {
                return selectedCommand ??
                  (selectedCommand = new RelayCommand(obj => {
                      DateEventViewModel de = (DateEventViewModel)obj;
                      ID = de.DateEvent_ID;
                      AllTickets = db.Ticket.Where(i => i.DateEvent.DateEvent_ID == de.DateEvent_ID ).ToList().Select(i => new TicketViewModel(i)).ToList();
                  },

                 //условие, при котором будет доступна команда
                 (obj) => (obj != null)));
            }
        }
    }
}
