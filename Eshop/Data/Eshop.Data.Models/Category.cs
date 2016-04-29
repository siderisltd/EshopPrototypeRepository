namespace Eshop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class Category : BaseModel
    {
        private ICollection<Category> children;

        private ICollection<Item> items;

        public Category()
        {
            this.children = new HashSet<Category>();
            this.items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
