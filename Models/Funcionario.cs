namespace MyTea.Models
{
    public class Funcionario
    {
        public int Func_Id { get; set; }
        public string? Func_Nome { get; set; }
        public string? Func_Sobrenome { get; set; }
        public DateTime Func_DtAdm { get; set; }
        public DateTime? Func_DtDes { get; set; }
        public decimal Func_CH_Est { get; set; }
        public string? Func_Gen { get; set; }
        public string? Func_Usuario { get; set; }
        public string? Func_Senha { get; set; }
        public int NAcesso_Id { get; set; }
        public int Depto_Id { get; set; }

    }
}
