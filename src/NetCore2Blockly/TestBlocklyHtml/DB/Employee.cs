using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBlocklyHtml.DB
{
    public partial class Employee
    {
        [Key]
        [Column("IDEmployee")]
        public long Idemployee { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("IDDepartment")]
        public long Iddepartment { get; set; }

        [ForeignKey(nameof(Iddepartment))]
        [InverseProperty(nameof(Department.Employee))]
        public virtual Department IddepartmentNavigation { get; set; }
    }
}
