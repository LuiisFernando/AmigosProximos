namespace AmigoProximo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmigoProximo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AmigoID = c.Int(nullable: false),
                        AmigoQueEstaoProximoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Amigo", t => t.AmigoQueEstaoProximoID)
                .ForeignKey("dbo.Amigo", t => t.AmigoID)
                .Index(t => t.AmigoID)
                .Index(t => t.AmigoQueEstaoProximoID);
            
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        PosicaoX = c.Double(nullable: false),
                        PosicaoY = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CalculoHistorico",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Acao = c.String(nullable: false, maxLength: 20, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 300, unicode: false),
                        AmigoID = c.Int(nullable: false),
                        AmigoCalculadoID = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Amigo", t => t.AmigoID)
                .ForeignKey("dbo.Amigo", t => t.AmigoCalculadoID)
                .Index(t => t.AmigoID)
                .Index(t => t.AmigoCalculadoID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalculoHistorico", "AmigoCalculadoID", "dbo.Amigo");
            DropForeignKey("dbo.CalculoHistorico", "AmigoID", "dbo.Amigo");
            DropForeignKey("dbo.AmigoProximo", "AmigoID", "dbo.Amigo");
            DropForeignKey("dbo.AmigoProximo", "AmigoQueEstaoProximoID", "dbo.Amigo");
            DropIndex("dbo.CalculoHistorico", new[] { "AmigoCalculadoID" });
            DropIndex("dbo.CalculoHistorico", new[] { "AmigoID" });
            DropIndex("dbo.AmigoProximo", new[] { "AmigoQueEstaoProximoID" });
            DropIndex("dbo.AmigoProximo", new[] { "AmigoID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.CalculoHistorico");
            DropTable("dbo.Amigo");
            DropTable("dbo.AmigoProximo");
        }
    }
}
