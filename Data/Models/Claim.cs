using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Policy))]
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        public DateTime DateOfClaim { get; set; }

        [Range(0, 99999999.99)]
        public decimal ClaimAmount { get; set; }

        [MaxLength(255)]
        [Required]
        public string ClaimDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClaimStatus { get; set; }    
    }

}
