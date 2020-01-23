using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseMngr = new HashSet<Employee>();
        }

        [Key]
        [Column("emp_id")]
        public int EmpId { get; set; }
        [Column("dept_id")]
        public int? DeptId { get; set; }
        [Column("mngr_id")]
        public int? MngrId { get; set; }
        [Column("emp_name")]
        [StringLength(20)]
        public string EmpName { get; set; }
        [Column("salary")]
        public int? Salary { get; set; }

        [ForeignKey(nameof(DeptId))]
        [InverseProperty(nameof(Department.Employee))]
        public virtual Department Dept { get; set; }
        [ForeignKey(nameof(MngrId))]
        [InverseProperty(nameof(Employee.InverseMngr))]
        public virtual Employee Mngr { get; set; }
        [InverseProperty(nameof(Employee.Mngr))]
        [Column("emp_email")]
        [StringLength(20)]
       
        public string Email { get; set; }

        public virtual ICollection<Employee> InverseMngr { get; set; }
    }
}
