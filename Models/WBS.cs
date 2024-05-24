using System.ComponentModel.DataAnnotations;

namespace MyTea.Models
{
    public class WBS
    {
        public int WBS_Id { get; set; }
        [Required]
        public string? WBS_Codigo { get; set; }
        [Required]
        public string? WBS_Descricao {  get; set; }
        [Required]
        public bool WBS_Chargeability {  get; set; }

    }
}
