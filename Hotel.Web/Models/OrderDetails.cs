using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Hotel.Web.Models;

namespace Hotel.Web.Models
{
    [Table(name: "OrderDetails")]

    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }



        #region Navigation Properties to the Customer Model
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(OrderDetails.CustomerId))]

        public Customer Customers { get; set; }

        #endregion


        #region Navigation Properties to the Menu Model

        [Display(Name = "Name of the Dish")]
        public int DishId { get; set; }

        [ForeignKey(nameof(OrderDetails.DishId))]

        public Menu Menus { get; set; }

        #endregion

        public int Quantity { get; set; }

        #region Navigation Properties to the Payment Model
        [Display(Name = "Payment Options")]
        public int PaymentMethod { get; set; }
        [ForeignKey(nameof(OrderDetails.PaymentMethod))]
        public Payment Payments { get; set; }


        #endregion
    }
}
