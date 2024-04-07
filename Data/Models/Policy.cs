using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [MaxLength(50)]
        public string PolicyType { get; set; }

        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime EndDate { get; set; }

        [Range(0, 99999999.99)]
        public decimal PremiumAmount { get; set; }
    }
}
