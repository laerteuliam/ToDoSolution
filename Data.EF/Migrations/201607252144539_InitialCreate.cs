namespace Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 200, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDo");
        }
    }
}
