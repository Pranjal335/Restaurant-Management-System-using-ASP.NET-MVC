using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Hotel.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CustomerId { get; set; }

        [Required]

        public string CustomerName { get; set; }






        #region Navigation Properties to the Order Model
        public ICollection<Order> Order { get; set; }
        #endregion

    }
}