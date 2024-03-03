using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Round : IRound
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoundNumber { get; set; }
        [Required]
        public int AttackerHeroId { get; set; }
        [Required]
        public int DefenderHeroId { get; set; }
    }
}
