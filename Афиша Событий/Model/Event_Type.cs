namespace Афиша_Событий.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event_Type
    {
        [Key]
        public int Event_Type_ID { get; set; }

        public int Event_FK { get; set; }

        public int Type_FK { get; set; }

        public virtual Event Event { get; set; }

        public virtual Type Type { get; set; }
    }
}
