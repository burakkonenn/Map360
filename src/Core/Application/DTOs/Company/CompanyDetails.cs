using Application.DTOs.User;
using Application.DTOs.UserTask;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Company
{
    public class CompanyDetails
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyTaxNumber { get; set; }
        public List<TaskWithUserDetails> UserDetails { get; set; }
        public List<UserDetailDto> UserTask { get; set; }
    }
}
