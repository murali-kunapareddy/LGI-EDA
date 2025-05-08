using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Models.Entities
{
    public class RolePrivilege : BaseTable
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "char(4)")]
        public string? RoleCode { get; set; } // FK to Role
        [ForeignKey("RoleCode")]
        public Role? Role { get; set; }
        public int PrivilegeId { get; set; } // FK to Privilege
        [ForeignKey("PrivilegeId")]
        public Privilege? Privilege { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool List { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
}
