using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.Web.Models
{
    [Table(name: "Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DishID { get; set; }

        [Required]
        public string DishName { get; set; }


        [Required]
        public string DishPrice { get; set; }

        #region Navigation Properties to the Category Model
        public int CategoryId { get; set; }


        [ForeignKey(nameof(Menu.CategoryId))]
        public Category Category { get; set; }
        #endregion


        #region Navigation Properties to the OrderDetails Model
        public ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion
    }
}