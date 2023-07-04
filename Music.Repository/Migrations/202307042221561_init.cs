namespace Onion.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                        ActiveCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingerName = c.String(nullable: false, maxLength: 100),
                        SingerImage = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingerId = c.Int(nullable: false),
                        SongName = c.String(nullable: false, maxLength: 100),
                        SongFileName = c.String(nullable: false, maxLength: 100),
                        SongImageName = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.SingerId);
            
            CreateTable(
                "dbo.SongLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        UserIP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.SongVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        UserIP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        ImageName = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongVisits", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongLikes", "SongId", "dbo.Songs");
            DropForeignKey("dbo.Songs", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.SongVisits", new[] { "SongId" });
            DropIndex("dbo.SongLikes", new[] { "SongId" });
            DropIndex("dbo.Songs", new[] { "SingerId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropTable("dbo.Sliders");
            DropTable("dbo.SongVisits");
            DropTable("dbo.SongLikes");
            DropTable("dbo.Songs");
            DropTable("dbo.Singers");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
