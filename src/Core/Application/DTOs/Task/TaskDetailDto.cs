using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserTask
{
    public class TaskDetailDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
