namespace Афиша_Событий.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [Key]
        public int Ticket_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code_of_ticket { get; set; }

        public int Row { get; set; }

        public int Place { get; set; }

        public double Price { get; set; }

        public int? User_FK { get; set; }

        public int Status_FK { get; set; }

        public int DateEvent_FK { get; set; }

        public virtual DateEvent DateEvent { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
