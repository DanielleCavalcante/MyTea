using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyTea.Models
{
    public class WBS
    {
        public int WBS_Id { get; set; }

        [Required]
        [RegularExpression("^(?=.{4,10}$).*")]
        public string? WBS_Codigo { get; set; }

        [Required]
        public string? WBS_Descricao { get; set; }

        [Required]
        public bool WBS_Chargeability { get; set; }

    }
}
