namespace MyTea.Models
{
    //model para listar departamento e exibir no select
    public class ViewModelListar
    {
        public Funcionario Funcionario { get; set; }
        public List<Departamento> listarDepto { get; set; }
        public List<NivelAcesso> NiveisAcesso { get; set; }
    }
}
