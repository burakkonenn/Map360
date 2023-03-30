using Domain.Entities.Common;
using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    public class CompanyDoc : BaseEntity
    {

        [Column(TypeName = "jsonb")]
        public Company Company { get; set; }
        public List<UserDoc> User { get; set; }
        public List<TaskDoc> Task { get; set; }
    }
}
