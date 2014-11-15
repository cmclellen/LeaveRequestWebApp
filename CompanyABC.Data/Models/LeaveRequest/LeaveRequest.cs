using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using CompanyABC.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace CompanyABC.Data.Models.LeaveRequest
{
    [Table("m_LeaveRequest", Schema = SchemaNames.LeaveRequest)]
    public class LeaveRequest : AuditableEntity
    {
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public int ReasonId { get; set; }
        [ForeignKey("ReasonId")]
        public virtual Reason Reason { get; set; }

        [MaxLength]
        public string Comments { get; set; }
    }
}