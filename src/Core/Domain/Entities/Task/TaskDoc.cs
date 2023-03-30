using Domain.Entities.Common;
using Domain.Entities.User;

namespace Domain.Entities.Task
{
    public  class TaskDoc:BaseEntity
    {
        public string Name { get; set; }
        public List<UserDoc> User { get; set; }
    }
}
