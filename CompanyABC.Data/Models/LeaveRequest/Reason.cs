using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using CompanyABC.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace CompanyABC.Data.Models.LeaveRequest
{
    [Table("l_Reason", Schema = SchemaNames.LeaveRequest)]
    public class Reason : AuditableEntity
    {
        [Required]
        [StringLength(50)]
        [Index("UC_DisplayName", IsUnique = true)]
        public string DisplayName { get; set; }
    }
}