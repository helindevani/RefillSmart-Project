using back_end.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Domain.Entities
{
    public class GasBooking
    {
        [Key]
        public Guid BookingId { get; set; } = Guid.NewGuid();

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public DateTime DeliveryDate { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        [ForeignKey("NewConnectionForms")]
        public int ConnectionNo { get; set; }

        public NewConnectionForm? NewConnectionForm { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
