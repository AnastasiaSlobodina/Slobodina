using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Help;
using Афиша_Событий.Model;
using Афиша_Событий.View;
using System.Threading;

namespace Афиша_Событий.ViewModel
{
    public class Users : Base
    {
        Model1 db;
        Tickets tickets;
        private Ticket ticket;
        private BiletViewModel bilet;
        public BiletViewModel Bilet
        {
            get { return bilet; }
            set { bilet = value; OnPropertyChanged("Bilet"); }
        }
        public Users(Tickets t)
        {
            db = new Model1();
            tickets = t;
            ticket = db.Ticket.Find(t.SelectTicket.Ticket_ID);
            Bilet = new BiletViewModel(ticket);
        }

        private string identification;
        public string Identification
        {
            get { return identification; }
            set { identification = value;
                OnPropertyChanged("Identification");
            }
        }
        //private Tickets ti;
        //public Tickets tickets
        //{
        //    get
        //    {
        //        return ti;
        //    }
        //    set
        //    {
        //        ti = value;
        //        OnPropertyChanged("tickets");
        //    }
        //}

        private RelayCommand bookingCommand;
        public RelayCommand BookingCommand
        {
            get
            {
                return bookingCommand ??
                  (bookingCommand = new RelayCommand(obj => {
                      User user = new User();
                      user.Identification = identification;
                      db.User.Add(user);
                      Ticket tnew = ticket; 
                      tnew.Status_FK = 2;
                      tnew.User_FK = user.User_ID;
                      db.SaveChanges();
                      var bilet = new Bilet(this);
                      bilet.Show();
                      Thread.Sleep(10000);
                      bilet.Close();
                      tickets.AllTickets = db.Ticket.Where(i => i.DateEvent.DateEvent_ID == tickets.ID).ToList().Select(i => new TicketViewModel(i)).ToList();
                  },
                  
                //условие, при котором будет доступна команда
                (obj) => ( identification != null)));
            }
        }
    }
}
