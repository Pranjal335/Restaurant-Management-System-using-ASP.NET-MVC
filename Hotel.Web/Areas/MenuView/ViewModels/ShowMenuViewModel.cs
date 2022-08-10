
using Hotel.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Web.Areas.MenuView.ViewModels
{
    public class ShowMenuViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<Menu> MenuItems { get; set; }

    }
}
