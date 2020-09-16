namespace POS.Dto
{
    public class RegisterDto
    {   
        public string CompanyName { get; set; }
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public int MajorServiceId { get; set; }
        public int CountryId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirebaseTokenId { get; set; }
        public string languageId { get; set; }

    }
}