using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Entities
{
    public class Amigo
    {
        public Amigo()
        {
            AmigosQueEstaoProximos = new List<AmigoProximo>();
            CalculoHistorico = new List<CalculoHistorico>();
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public double PosicaoX { get; set; }
        public double PosicaoY { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<AmigoProximo> AmigosQueEstaoProximos { get; set; }
        public virtual ICollection<CalculoHistorico> CalculoHistorico { get; set; }

    }
}
