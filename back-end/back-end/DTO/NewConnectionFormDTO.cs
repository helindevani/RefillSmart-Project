using back_end.Enums;

namespace back_end.DTO
{
    public class NewConnectionFormDTO
    {
        public int? ConnectionNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Address { get; set; }
        public IFormFile AddressProof { get; set; }
        public string? Document {  get; set; }
        public string RationCardNo { get; set; }
        public RelatedType Related { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelatedAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }

    }
}
