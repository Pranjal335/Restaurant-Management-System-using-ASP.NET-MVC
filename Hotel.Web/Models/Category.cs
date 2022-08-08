using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Hotel.Web.Models
{
    [Table(name: "DishCategory")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        #region Navigation Properties to the Menu Model

        public ICollection<Menu> Menu { get; set; }

        #endregion


    }
}