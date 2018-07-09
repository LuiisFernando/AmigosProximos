using AmigoProximo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.ViewModel
{
    public class AmigoVM
    {
        public AmigoVM()
        {

        }

        public AmigoVM(Amigo amigo)
        {
            AmigosProximos = new List<AmigoProximoVM>();

            ID = amigo.ID;
            Nome = amigo.Nome;
            PosicaoX = amigo.PosicaoX;
            PosicaoY = amigo.PosicaoY;
            Ativo = amigo.Ativo;

            //AmigosProximos.Add(new AmigoProximoVM(amigo.))
            //amigo.AmigosQueEstaoProximos.ToList().ForEach(x => AmigosProximos.Add(new AmigoProximoVM(x)));

        }

        public static Amigo ConvertModel(AmigoVM amigo)
        {
            var Amigo = new Amigo
            {
                ID = amigo.ID ?? 0,
                Nome = amigo.Nome,
                PosicaoX = amigo.PosicaoX,
                PosicaoY = amigo.PosicaoY,
                Ativo = amigo.Ativo
            };

            return Amigo;
        }

        public int? ID { get; set; }
        public string Nome { get; set; }
        public double PosicaoX { get; set; }
        public double PosicaoY { get; set; }
        public double Distance { get; set; }
        public bool Ativo { get; set; }

        public List<AmigoProximoVM> AmigosProximos { get; set; }
    }
}
