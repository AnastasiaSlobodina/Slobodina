using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;

namespace Афиша_Событий.ViewModel
{
    public class BiletViewModel
    {
        private Ticket ticket;

        public BiletViewModel(Ticket t)
        {
            ticket = t;
        }

        public string Code
        {
            get { return ticket.Code_of_ticket; }
        }

        public string Name
        {
            get { return ticket.DateEvent.Event.NameE; }
        }

        public string Duration
        {
            get { return ticket.DateEvent.Event.Duration.ToString("hh':'mm"); }
        }

        public int Place
        {
            get { return ticket.Place; }
        }

        public int Row
        {
            get { return ticket.Row; }
        }

        public double Price
        {
            get { return ticket.Price; }
        }

        public string Date
        {
            get { return ticket.DateEvent.Date.ToLongDateString() + " " + ticket.DateEvent.Date.ToShortTimeString(); }
        }
    }
}
