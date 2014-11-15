using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using CompanyABC.Data.Constants;

namespace CompanyABC.Data.Models.LeaveRequest
{
    [Table("m_User", Schema = SchemaNames.LeaveRequest)]
    public class User : AuditableEntity
    {
        [Required, StringLength(50), Index("UC_Username", IsUnique = true)]
        public string Username { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; }
    }
}