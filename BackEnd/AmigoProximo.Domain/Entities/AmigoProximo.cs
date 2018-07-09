using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Entities
{
    public class AmigoProximo
    {
        public AmigoProximo()
        {
        }
        public int ID { get; set; }
        public int AmigoID { get; set; }
        public int AmigoQueEstaoProximoID { get; set; }
        public virtual Amigo Amigo { get; set; }
        public virtual Amigo AmigoQueEstaoProximo { get; set; }
    }
}
