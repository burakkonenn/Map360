namespace Application.DTOs.Company
{
    public  class CompanyListDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyTaxNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
