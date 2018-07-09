namespace AmigoProximo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalculoHistorico", "Acao", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalculoHistorico", "Acao", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}
