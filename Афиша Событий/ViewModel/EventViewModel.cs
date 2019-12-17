using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Model;
using Афиша_Событий.Help;

namespace Афиша_Событий.ViewModel
{
    public class EventViewModel : Base
    {
        private Event events;
        public EventViewModel(Event e)
        {
            events = e;
        }
        public int Event_ID
        {
            get { return events.Event_ID; }
            set
            {
                events.Event_ID = value;
                OnPropertyChanged("Event_ID");
            }
        }

        public string NameE
        {
            get { return events.NameE; }
            set
            {
                events.NameE = value;
                OnPropertyChanged("NameE");
            }
        }

        public string Description
        {
            get { return events.Description; }
            set
            {
                events.Description = value;
                OnPropertyChanged("Descriprion");
            }
        }

        public string Duration
        {
            get { return events.Duration.ToString("hh':'mm"); }
        }

        public int Place_FK
        {
            get { return events.Place_FK; }
            set
            {
                events.Place_FK = value;
                OnPropertyChanged("Place_FK");
            }
        }

        public string Place
        {
            get { return events.Place.NameP; }
        }

        public string City
        {
            get { return events.Place.City.Name; }
        }

        public string Image
        {
            get { return "/Афиша Событий;component/Картинки/Мероприятия/"+ events.Event_ID +".jpg"; }
        }

        public List<int> Type_ID
        {
            get { return events.Event_Type.Select(i => i.Type_FK).ToList<int>(); }
        }

        public List<DateEventViewModel> AllDates
        {
            get { return events.DateEvent.Where(i => i.Event_FK == Event_ID).ToList().Select(i => new DateEventViewModel(i)).ToList(); }
        }
    }
}
