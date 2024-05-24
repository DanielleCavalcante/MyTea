namespace MyTea.Models
{
    public class Horas
    {
        public bool Feriado { get; set; }

        public bool DeveMostrarDiv { get; set; }
        public bool MensagemErroHorasDia { get; set; }
        public bool LinhaAdicionalTabela { get; set; }
        public int TotalHorasQuinzEsperada { get; set; }

        public int TotalHorasQuinzExecutada { get; set; }

        public int Dia_Um { get; set; }
        public int Dia_Dois { get; set; }
        public int Dia_Tres { get; set; }
        public int Dia_Quatro { get; set; }
        public int Dia_Cinco { get; set; }
        public int Dia_Seis { get; set; }
        public int Dia_Sete { get; set; }
        public int Dia_Oito { get; set; }
        public int Dia_Nove { get; set; }
        public int Dia_Dez { get; set; }
        public int Dia_Onze { get; set; }
    }
}
