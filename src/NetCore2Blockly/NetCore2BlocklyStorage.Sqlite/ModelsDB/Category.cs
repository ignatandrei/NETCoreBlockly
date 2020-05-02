using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    internal partial class Category
    {
        public Category()
        {
            Blocks = new HashSet<Blocks>();
            InverseIdparentNavigation = new HashSet<Category>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("IDParent")]
        public int? Idparent { get; set; }

        [ForeignKey(nameof(Idparent))]
        [InverseProperty(nameof(Category.InverseIdparentNavigation))]
        public virtual Category IdparentNavigation { get; set; }
        [InverseProperty("IdcategoryNavigation")]
        public virtual ICollection<Blocks> Blocks { get; set; }
        [InverseProperty(nameof(Category.IdparentNavigation))]
        public virtual ICollection<Category> InverseIdparentNavigation { get; set; }
    }
}
