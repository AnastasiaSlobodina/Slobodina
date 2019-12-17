using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Help;
using Афиша_Событий.Model;

namespace Афиша_Событий.ViewModel
{
    public class Users : Base
    {
        Model1 db;
        Ticket ticket;
        public Users(TicketViewModel t)
        {
            db = new Model1();
            ticket = db.Ticket.Find(t.Ticket_ID);
        }

        private string identification;
        public string Identification
        {
            get { return identification; }
            set { identification = value;
                OnPropertyChanged("Identification");
            }
        }

        //private User selectedUser;
        //public ObservableCollection<User> Us { get; set; }
        //public User SelectedUser
        //{
        //    get { return selectedUser; }
        //    set
        //    {
        //        selectedUser = value;
        //        OnPropertyChanged("SelectedUser");
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
                  },
                  
                //условие, при котором будет доступна команда
                (obj) => ( identification != null)));
            }
        }
    }
}
