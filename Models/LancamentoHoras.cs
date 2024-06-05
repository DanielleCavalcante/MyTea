using System.ComponentModel.DataAnnotations.Schema;

namespace MyTea.Models
{
    public class LancamentoHoras
    {
        public int LHora_Id { get; set; }

        public DateOnly Dt_Id { get; set; }
       
        public int Func_Id { get; set; }

        public int WBS_Id { get; set; }

        public decimal LHora_QTdeHoras { get; set; }
    }
}
