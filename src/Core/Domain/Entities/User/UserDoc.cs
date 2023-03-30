using Domain.Entities.Common;
using Domain.Entities.Company;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserDoc : BaseEntity
    {

        [Column(TypeName = "jsonb")]
        public User User { get; set; }

        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public TaskDoc TaskDoc { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public CompanyDoc CompanyDoc { get; set; }
    }
}
