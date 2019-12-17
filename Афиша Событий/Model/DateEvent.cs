namespace Афиша_Событий.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DateEvent")]
    public partial class DateEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DateEvent()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int DateEvent_ID { get; set; }

        public DateTime Date { get; set; }

        public int Event_FK { get; set; }

        public virtual Event Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
