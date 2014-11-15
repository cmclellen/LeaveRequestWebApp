using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CompanyABC.Data.Models
{
    public class AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 1)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
    }
}