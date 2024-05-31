using System.Collections.Generic;
using MyTea.Models;

namespace MyTea.ViewModels
{
    public class FuncionarioViewModel
    {
        public Funcionario Funcionario { get; set; }
        public IEnumerable<Departamento> Departamento { get; set; }
        public IEnumerable<NivelAcesso> NivelAcesso { get; set; }
    }
}
