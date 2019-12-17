using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;

namespace Афиша_Событий.ViewModel 
{
    public class DateEventViewModel :  Base
    {
        private DateEvent dateevents;
        public DateEventViewModel(DateEvent de)
        {
            dateevents = de;
        }
        public int DateEvent_ID
        {
            get { return dateevents.DateEvent_ID; }
            set
            {
                dateevents.DateEvent_ID = value;
                OnPropertyChanged("DateEvent_ID");
            }
        }

        public DateTime Date1
        {
            get { return dateevents.Date; }
        }
        public string Date
        {
            get { return dateevents.Date.ToLongDateString() + " " + dateevents.Date.ToShortTimeString(); }
        }

        public int Event_FK
        {
            get { return dateevents.Event_FK; }
            set
            {
                dateevents.Event_FK = value;
                OnPropertyChanged("Event_FK");
            }
        }
    }
}
