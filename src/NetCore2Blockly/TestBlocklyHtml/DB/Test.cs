using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBlocklyHtml.DB
{
    [Table("test")]
    public partial class Test
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
