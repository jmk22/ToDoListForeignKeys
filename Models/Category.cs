using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoDbFirstTest01.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
