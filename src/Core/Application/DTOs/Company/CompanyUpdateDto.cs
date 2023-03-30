using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Company
{
    public class CompanyUpdateDto
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyTaxNumber { get; set; }
    }
}
