using System.Drawing;

namespace MyTea.Models
{
    public class Repository
    {
      
        private static List<Horas> _todasAsHoras = new List<Horas>();

        public static IEnumerable<Horas> TodasAsHoras
        {
            get { return _todasAsHoras; }
        }

        public static void Inserir(Horas registroHoras)
        {
            _todasAsHoras.Add(registroHoras);
        }

    }

    
}
