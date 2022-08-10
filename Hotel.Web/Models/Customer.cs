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

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Customer")]

        public string CustomerName { get; set; }

        [Required(ErrorMessage ="{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Address")]

        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }



        

        #region Navigation Properties to the OrderDetail Model
        public ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion
    }
}