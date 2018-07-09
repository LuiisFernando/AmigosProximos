using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.ViewModel
{
    public class AmigoProximoVM
    {
        public AmigoProximoVM()
        {

        }
        public AmigoProximoVM(AmigoProximo.Domain.Entities.AmigoProximo amigoProximo)
        {
            ID = amigoProximo.ID;

            AmigoID = amigoProximo.AmigoID;
            AmigoQueEstaoProximoID = amigoProximo.AmigoQueEstaoProximoID;

            Amigo = new AmigoVM 
            {
                ID = amigoProximo.Amigo.ID,
                Nome = amigoProximo.Amigo.Nome,
                PosicaoX = amigoProximo.Amigo.PosicaoX,
                PosicaoY = amigoProximo.Amigo.PosicaoY

            };
        }

        public static AmigoProximo.Domain.Entities.AmigoProximo ConvertModel(AmigoProximoVM model)
        {
            var amigoProximo = new AmigoProximo.Domain.Entities.AmigoProximo()
            {
                ID = model.ID,
                AmigoID = model.AmigoID,
                AmigoQueEstaoProximoID = model.AmigoQueEstaoProximoID,
                Amigo = AmigoVM.ConvertModel(model.Amigo)
            };

            return amigoProximo;
        }

        public int ID { get; set; }
        public int AmigoID { get; set; }
        public int AmigoQueEstaoProximoID { get; set; }

        public AmigoVM Amigo { get; set; }
        public virtual AmigoVM AmigoQueEstaoProximo { get; set; }
    }
}
