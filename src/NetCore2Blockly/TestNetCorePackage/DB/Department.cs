using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNetCorePackage.DB
{
    public partial class DBDepartment
    {
        public DBDepartment()
        {
            Employee = new HashSet<DBEmployee>();
        }

        [Key]
        [Column("IDDepartment")]
        public long Iddepartment { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("IddepartmentNavigation")]
        public virtual ICollection<DBEmployee> Employee { get; set; }
    }
}
