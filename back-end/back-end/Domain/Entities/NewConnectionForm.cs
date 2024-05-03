using back_end.Enums;
using System.ComponentModel.DataAnnotations;

namespace back_end.Domain.Entities
{
    public class NewConnectionForm
    {
        [Key]
        public int ConnectionNo { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Address { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        public string AddressProof { get; set; }
        public string RationCardNo {  get; set; }
        public ConnectionType ConnectionStatus { get; set; } = ConnectionType.Pending;
        public RelatedType Related { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelatedAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }

    }
}
