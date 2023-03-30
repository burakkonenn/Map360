using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Company
{
    public class CompanyCreateDto
    {
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyTaxNumber { get; set; }
    }
}
