namespace Афиша_Событий.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            DateEvent = new HashSet<DateEvent>();
            Event_Type = new HashSet<Event_Type>();
        }

        [Key]
        public int Event_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NameE { get; set; }

        [Required]
        public string Description { get; set; }

        public TimeSpan Duration { get; set; }

        public int Admin_FK { get; set; }

        public int Category_FK { get; set; }

        public int Place_FK { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateEvent> DateEvent { get; set; }

        public virtual Place Place { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event_Type> Event_Type { get; set; }
    }
}
