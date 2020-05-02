using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    internal partial class Blocks
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(4000)]
        public string Value { get; set; }
        [Column("IDCategory")]
        public int Idcategory { get; set; }

        [ForeignKey(nameof(Idcategory))]
        [InverseProperty(nameof(Category.Blocks))]
        public virtual Category IdcategoryNavigation { get; set; }
    }
}
