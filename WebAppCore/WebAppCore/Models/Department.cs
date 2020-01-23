using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCore.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [Column("dept_id")]
        public int DeptId { get; set; }
        [Column("dept_name")]
        [StringLength(20)]
        public string DeptName { get; set; }

        [InverseProperty("Dept")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
