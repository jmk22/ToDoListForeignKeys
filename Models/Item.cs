using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoDbFirstTest01.Models
{
    [Table("Item")]
    public partial class Item
    {
        public int ItemId { get; set; }
        [Display(Name="Task Description")]
        public string Description { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
