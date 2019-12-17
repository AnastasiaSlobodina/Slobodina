using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;

namespace Афиша_Событий.ViewModel
{
    public class Events : Base
    {
        Model1 db;
        static DateTime d = default(DateTime);
        
        private List<EventViewModel> allEvents;
        public List<EventViewModel> AllEvents
        {
            get { return allEvents; }
            set
            {
                allEvents = value; OnPropertyChanged("AllEvents");
            }
        }
        public Events()
        {
            db = new Model1();
            AllEvents = db.Event.Where(i => i.Place.City_FK == 1).ToList().Select(i => new EventViewModel(i)).ToList();

        }
        

        public void Update(int Category_ID, int City_ID, int Type_ID, DateTime date)
        {
            
            if (Type_ID == 1 && Category_ID == 1)
                AllEvents = db.Event.Where(i => i.Place.City_FK == City_ID).ToList().Select(i => new EventViewModel(i)).ToList();
            else
            {
                if (Category_ID == 1)
                    AllEvents = db.Event.Where(i => i.Place.City_FK == City_ID).ToList().Select(i => new EventViewModel(i)).Where(i => i.Type_ID.Contains(Type_ID)).ToList();
                else
                {
                    if (Type_ID == 1)
                        AllEvents = db.Event.Where(i => i.Category_FK == Category_ID && i.Place.City_FK == City_ID).ToList().Select(i => new EventViewModel(i)).ToList();
                    else
                        AllEvents = db.Event.Where(i => i.Category_FK == Category_ID && i.Place.City_FK == City_ID).ToList().Select(i => new EventViewModel(i)).Where(i => i.Type_ID.Contains(Type_ID)).ToList();
                }
            }
            if (date != d)
            {
                DateTime date2 = date.AddDays(1);
                List<DateEvent> dateEvents = db.DateEvent.Where(i => i.Date > date.Date && i.Date < date2).ToList();
                List<EventViewModel> events = AllEvents;
                AllEvents = new List<EventViewModel>();
                foreach (DateEvent d in dateEvents)
                    foreach (EventViewModel e in events)
                        if (d.Event_FK == e.Event_ID)
                            AllEvents.Add(e);
            }
            
        }

        private EventViewModel selectEvent;
        public EventViewModel SelectEvent 
        { 
            get
            {
                return selectEvent;
            }
            set
            {
                selectEvent = value;
                OnPropertyChanged("SelectEvent");
            }
        }
    }
}
