﻿
namespace Application.DTOs.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TaskId { get; set; }
        public int CompanyId { get; set; }
    }
}
