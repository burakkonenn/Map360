namespace Application.DTOs.UserTask
{
    public class TaskWithUserDetails
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string TaskName { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
