using System;
using System.Linq;

namespace CompanyABC.Data.Models
{
    public interface IAuditableEntity
    {
        int Id { get; set; }
        DateTime? CreatedDate { get; set; }
    }
}