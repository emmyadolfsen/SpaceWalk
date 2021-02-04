using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpaceMVC.Models
{
    public class Item
    {
        // Lägg till annotation och ändra displaynamn
        [Required(ErrorMessage = "Du måste fylla i kattnamn")]
        [Display(Name = "Favorit Kattnamn")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste välja film")]
        [Display(Name = "Film")]
        public string Movie { get; set; }

        [Required(ErrorMessage = "Du måste välja dryck")]
        [Display(Name = "Välj dryck")]
        public string Drink { get; set; }

        // Checklista
        public bool AmericanCream { get; set; }
        public bool AmericanCurl { get; set; }
        public bool Balines { get; set; }

        public Item()
        {

        }

    }

    public class ViewModelItem
    {
        // Ienumerable för lista
        public IEnumerable<Item> ItemList { get; set; }
    }
}
