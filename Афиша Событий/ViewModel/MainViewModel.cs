using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Афиша_Событий.Help;
using Афиша_Событий.Model;

namespace Афиша_Событий.ViewModel
{
    public class MainViewModel : Base
    {
        private Model1 db;
        private Events events;
        public List<City> AllCity { get; set; }
        public List<Category> AllCategory { get; set; }
        public List<Model.Type> AllType{ get; set; }

        public MainViewModel(Events ev)
        {
            db = new Model1();
            events = ev;
            AllCity = db.City.ToList();
            AllCategory = db.Category.ToList();
            AllType = db.Type.ToList();
        }

        private int selectedCity_ID = 1;
        public int SelectedCity_ID
        {
            get { return selectedCity_ID; }
            set { selectedCity_ID = value; OnPropertyChanged("SelectedCity_ID"); }
        }

        private int selectedCategory_ID = 1;
        public int SelectedCategory_ID
        {
            get { return selectedCategory_ID; }
            set { selectedCategory_ID = value; OnPropertyChanged("SelectedCategory_ID"); }
        }

        private int selectedType_ID = 1;
        public int SelectedType_ID
        {
            get { return selectedType_ID; }
            set { selectedType_ID = value; OnPropertyChanged("SelectedType_ID"); }
        }


        private Nullable<DateTime> date = null;
        public Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        private RelayCommand reportEvents;
        public RelayCommand ReportEvents
        {
            get
            {
                return reportEvents ??
                  (reportEvents = new RelayCommand(obj => 
                  {
                      events.Update(selectedCategory_ID, selectedCity_ID, selectedType_ID, date);
                      //eve.AllEvents = eve.AllEvents;
                  },

                 //условие, при котором будет доступна команда
                 (obj) => (selectedCity_ID != 0 && selectedCategory_ID != 0 && selectedType_ID != 0)));
            }
        }
    }
}
