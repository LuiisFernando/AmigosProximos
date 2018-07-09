namespace AmigoProximo.Infra.Data.Migrations
{
    using AmigoProximo.Domain.Entities;
    using AmigoProximo.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AmigoProximoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmigoProximoContext context)
        {
            #region Usuario

            context.Usuarios.AddOrUpdate(
                new Usuario { ID = 1, Login = "luis" }
            );

            #endregion

            #region Amigo

            context.Amigos.AddOrUpdate(
                new Amigo { ID = 1, Nome = "Pablo", PosicaoX = 10, PosicaoY = 200, Ativo = true },
                new Amigo { ID = 2, Nome = "Nemo", PosicaoX = 55, PosicaoY = 143, Ativo = true },
                new Amigo { ID = 3, Nome = "Diego", PosicaoX = 94, PosicaoY = 63, Ativo = true },
                new Amigo { ID = 4, Nome = "João", PosicaoX = 20, PosicaoY = 90, Ativo = true }
            );

            #endregion

            #region AmigosProximos

            context.AmigoProximos.AddOrUpdate(
                new AmigoProximo { ID = 1,  AmigoID = 1, AmigoQueEstaoProximoID = 2 },
                new AmigoProximo { ID = 2,  AmigoID = 1, AmigoQueEstaoProximoID = 3 },
                new AmigoProximo { ID = 3,  AmigoID = 1, AmigoQueEstaoProximoID = 4 },
                                   
                new AmigoProximo { ID = 4,  AmigoID = 2, AmigoQueEstaoProximoID = 1 },
                new AmigoProximo { ID = 5,  AmigoID = 2, AmigoQueEstaoProximoID = 3 },
                new AmigoProximo { ID = 6,  AmigoID = 2, AmigoQueEstaoProximoID = 4 },
                                   
                new AmigoProximo { ID = 7,  AmigoID = 3, AmigoQueEstaoProximoID = 1 },
                new AmigoProximo { ID = 8,  AmigoID = 3, AmigoQueEstaoProximoID = 2 },
                new AmigoProximo { ID = 9,  AmigoID = 3, AmigoQueEstaoProximoID = 4 },
                                    
                new AmigoProximo { ID = 10,  AmigoID = 4, AmigoQueEstaoProximoID = 1 },
                new AmigoProximo { ID = 11,  AmigoID = 4, AmigoQueEstaoProximoID = 2 },
                new AmigoProximo { ID = 12, AmigoID = 4, AmigoQueEstaoProximoID = 3 }
            );

            #endregion

        }
    }
}
