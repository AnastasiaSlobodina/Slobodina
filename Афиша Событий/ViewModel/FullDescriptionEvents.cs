using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;

namespace Афиша_Событий.ViewModel
{
    class FullDescriptionEvents : Base
    {
        Model1 db;
        public EventViewModel evm { get; set; }
        private List<DateEventViewModel> allDate;
        public List<DateEventViewModel> AllDate
        {
            get { return allDate; }
            set
            {
                allDate = value; OnPropertyChanged("AllDate");
            }
        }

        public FullDescriptionEvents(int Event_ID)
        {
            db = new Model1();
            Event ev = db.Event.Find(Event_ID);
            evm = new EventViewModel(ev);
            AllDate = db.DateEvent.Where(i => i.Event_FK == Event_ID).ToList().Select(i => new DateEventViewModel(i)).ToList();
        }
    }
}

