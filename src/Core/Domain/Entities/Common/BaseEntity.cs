using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
