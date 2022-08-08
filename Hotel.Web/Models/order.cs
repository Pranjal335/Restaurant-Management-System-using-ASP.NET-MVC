using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Hotel.Web.Models;

namespace Hotel.Web.Models
{

    [Table(name: "Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }



        #region 

        public int CustomerId { get; set; }

        [ForeignKey(nameof(Order.CustomerId))]

        public Customer Customers { get; set; }

        #endregion

        #region Navigation Properties to the OrderDetails Model
        public ICollection<OrderDetails> OrderDetails { get; set; }

        #endregion





    }
}