namespace RunnersWeather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClothesPieces",
                c => new
                    {
                        ClothesPieceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClothesPieceId);
            
            CreateTable(
                "dbo.ClothesUsageConditions",
                c => new
                    {
                        ClothesUsageConditionsId = c.Int(nullable: false, identity: true),
                        ParamName = c.String(),
                        MinValue = c.Single(nullable: false),
                        MaxValue = c.Single(nullable: false),
                        ClothesPiece_ClothesPieceId = c.Int(),
                    })
                .PrimaryKey(t => t.ClothesUsageConditionsId)
                .ForeignKey("dbo.ClothesPieces", t => t.ClothesPiece_ClothesPieceId)
                .Index(t => t.ClothesPiece_ClothesPieceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClothesUsageConditions", "ClothesPiece_ClothesPieceId", "dbo.ClothesPieces");
            DropIndex("dbo.ClothesUsageConditions", new[] { "ClothesPiece_ClothesPieceId" });
            DropTable("dbo.ClothesUsageConditions");
            DropTable("dbo.ClothesPieces");
        }
    }
}
