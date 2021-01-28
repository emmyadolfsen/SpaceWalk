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
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste fylla i favoritfilm")]
        [Display(Name = "Favoritfilm")]
        public string Movie { get; set; }

        [Required(ErrorMessage = "Du måste fylla i dryck")]
        [Display(Name = "Välj dryck")]
        public string Drink { get; set; }

        public bool AmericanCream { get; set; }
        public bool AmericanCurl { get; set; }
        public bool Balines { get; set; }

        public Item()
        {

        }

    }
    public class ViewModelItem
    {
        // Skapa ienumerablelista
        public IEnumerable<Item> ItemList { get; set; }
    }
}
