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

        #region
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderDetails.OrderId))]

        public Order Orders { get; set; }

        #endregion


        #region 

        public int DishID { get; set; }

        [ForeignKey(nameof(OrderDetails.DishID))]

        public Menu Menus { get; set; }

        #endregion

        public int Quantity { get; set; }

        

    }
}
