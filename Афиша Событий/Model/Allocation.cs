namespace Афиша_Событий.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Allocation")]
    public partial class Allocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Allocation_ID { get; set; }

        public int Row { get; set; }

        public int Quantity_of_seats { get; set; }

        public int Place_FK { get; set; }

        public virtual Place Place { get; set; }
    }
}
