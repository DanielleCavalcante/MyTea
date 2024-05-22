using System.Drawing;

namespace MyTea.Models
{
    public class Repository
    {
        private static List<Quinzenas> _todasAsQuinzenas = new List<Quinzenas>();

        public static IEnumerable<Quinzenas> TodasAsQuinzenas
        {
            get { return _todasAsQuinzenas; }
        }

        public static void Inserir(Quinzenas registroQuinzena)
        {
            _todasAsQuinzenas.Add(registroQuinzena);
        }

    }

    
}
