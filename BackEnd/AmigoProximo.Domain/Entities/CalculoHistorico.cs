using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Entities
{
    public class CalculoHistorico
    {
        public CalculoHistorico()
        {

        }
        public int ID { get; set; }
        public string Acao { get; set; }
        public string Descricao { get; set; }
        public int AmigoID { get; set; }
        public int AmigoCalculadoID { get; set; }
        public DateTime Data { get; set; }

        public virtual Amigo Amigo { get; set; }
        public virtual Amigo AmigoCalculado { get; set; }

    }
}
