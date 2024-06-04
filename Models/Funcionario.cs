using System.ComponentModel.DataAnnotations;

namespace MyTea.Models
{
    public class Funcionario
    {
        public int Func_Id { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string? Func_Nome { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no sobrenome.")]
        public string? Func_Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de admissão é obrigatória.")]
        public DateOnly Func_Dt_Adm { get; set; }

        public DateOnly Func_Dt_Des { get; set; }

        [Required(ErrorMessage = "A carga horária é obrigatória")]
        [Range(8, 8, ErrorMessage = "Carga horária deve ser 8h.")]
        public decimal Func_CH_Est { get; set; }

        public string? Func_Gen { get; set; }

        [Required(ErrorMessage = "O nível de acesso é obrigatório.")]
        public int NAcesso_Id { get; set; }

        [Required(ErrorMessage = "O departamento é obrigatório.")]
        public int Depto_Id { get; set; }

        // Associações adicionais
        public List<Departamento> Departamento { get; set; }
        public List<NivelAcesso> NivelAcessos { get; set; }
    }
}
