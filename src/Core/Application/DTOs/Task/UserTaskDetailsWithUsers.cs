using Application.DTOs.CompanyTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserTask
{
    public class UserTaskDetailsWithUsers
    {
        public string TaskName { get; set; }
        public List<TaskWithUserDetails> Users { get; set; }
    }
}
