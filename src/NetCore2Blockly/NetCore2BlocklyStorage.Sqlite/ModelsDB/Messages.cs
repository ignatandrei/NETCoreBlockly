using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore2BlocklyStorage.Sqlite.ModelsSqlServer
{
    internal partial class Messages
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
