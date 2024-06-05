namespace MyTea.Models
{
    public class HomeViewModel
    {
        // Lista de datas
        public List<Data> Datas { get; set; }

        // Funcionario atual
        public Funcionario Funcionario { get; set; }

        // Lista de Work Breakdown Structures
        public List<WBS> WBSs { get; set; } 

        // Lista de departamentos
        public List<Departamento> Departamentos { get; set; }

        // Lista de níveis de acesso
        public List<NivelAcesso> NiveisAcesso { get; set; }
    }
}

