using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Policy))]
        public int PolicyID { get; set; }
        public Policy Policy { get; set; }


        [ForeignKey(nameof(Claim))]
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }

        public DateTime PaymentDate { get; set; }

        [Range(0, 99999999.99)]
        public decimal PaymentAmount { get; set; }

        public string PaymentType { get; set; }
    }
}
