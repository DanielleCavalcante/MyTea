using System.ComponentModel.DataAnnotations;

namespace MyTea.Models
{
    public class Data
    {
        public DateTime Dt_Id { get; set; }
        public int Dt_Ano { get; set; }
        public int Dt_Mes { get; set; }
        public int Dt_Dia { get; set; }
        public string? Dt_Mes_Nome { get; set; }
        public DateTime Dt_Mes_DtInicial { get; set; }
        public DateTime Dt_Mes_DtFinal { get; set; }
        public int Dt_Quinzena_Mes { get; set; }
        public DateTime Dt_Quinzena_DtInicial { get; set; }
        public DateTime Dt_Quinzena_DtFinal { get; set; }
        public int Dt_DiaSemana { get; set; }
        public string? Dt_DiaSemana_Nome { get; set; }
        public bool Dt_Feriado { get; set; }
        public string? Dt_Feriado_Descricao { get; set; }
        public bool Dt_DiaUtil { get; set; }
    }
}
