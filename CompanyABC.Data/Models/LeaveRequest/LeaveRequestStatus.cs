using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using CompanyABC.Data.Constants;

namespace CompanyABC.Data.Models.LeaveRequest
{
    [Table("l_LeaveRequestStatus", Schema = SchemaNames.LeaveRequest)]
    public class LeaveRequestStatus : AuditableEntity
    {
        [Required]
        [StringLength(50)]
        [Index("UC_Name", IsUnique = true)]
        public string Name { get; set; }
    }
}