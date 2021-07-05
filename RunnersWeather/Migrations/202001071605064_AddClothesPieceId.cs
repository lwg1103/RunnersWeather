namespace RunnersWeather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClothesPieceId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClothesUsageConditions", "ClothesPiece_ClothesPieceId", "dbo.ClothesPieces");
            DropIndex("dbo.ClothesUsageConditions", new[] { "ClothesPiece_ClothesPieceId" });
            RenameColumn(table: "dbo.ClothesUsageConditions", name: "ClothesPiece_ClothesPieceId", newName: "ClothesPieceId");
            AlterColumn("dbo.ClothesUsageConditions", "ClothesPieceId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClothesUsageConditions", "ClothesPieceId");
            AddForeignKey("dbo.ClothesUsageConditions", "ClothesPieceId", "dbo.ClothesPieces", "ClothesPieceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClothesUsageConditions", "ClothesPieceId", "dbo.ClothesPieces");
            DropIndex("dbo.ClothesUsageConditions", new[] { "ClothesPieceId" });
            AlterColumn("dbo.ClothesUsageConditions", "ClothesPieceId", c => c.Int());
            RenameColumn(table: "dbo.ClothesUsageConditions", name: "ClothesPieceId", newName: "ClothesPiece_ClothesPieceId");
            CreateIndex("dbo.ClothesUsageConditions", "ClothesPiece_ClothesPieceId");
            AddForeignKey("dbo.ClothesUsageConditions", "ClothesPiece_ClothesPieceId", "dbo.ClothesPieces", "ClothesPieceId");
        }
    }
}
