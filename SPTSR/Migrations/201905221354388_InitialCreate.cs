namespace SPTSR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kolegijs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        SeminarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seminars", t => t.SeminarId, cascadeDelete: true)
                .Index(t => t.SeminarId);
            
            CreateTable(
                "dbo.KorisnikKolegijs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KorisnikId = c.Int(nullable: false),
                        KolegijId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kolegijs", t => t.KolegijId, cascadeDelete: true)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId, cascadeDelete: true)
                .Index(t => t.KorisnikId)
                .Index(t => t.KolegijId);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Jmbag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemaId = c.Int(nullable: false),
                        TerminId = c.Int(nullable: false),
                        MaxClanovi = c.Int(nullable: false),
                        RokPrijave = c.DateTime(nullable: false),
                        Clan1 = c.Int(nullable: false),
                        Clan2 = c.Int(nullable: false),
                        Clan3 = c.Int(nullable: false),
                        Clan4 = c.Int(nullable: false),
                        Clan5 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Temas", t => t.TemaId, cascadeDelete: true)
                .ForeignKey("dbo.Termins", t => t.TerminId, cascadeDelete: true)
                .Index(t => t.TemaId)
                .Index(t => t.TerminId);
            
            CreateTable(
                "dbo.Temas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naslov = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Termins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vrijeme = c.DateTime(nullable: false),
                        BrojIzlaganja = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seminars", "TerminId", "dbo.Termins");
            DropForeignKey("dbo.Seminars", "TemaId", "dbo.Temas");
            DropForeignKey("dbo.Kolegijs", "SeminarId", "dbo.Seminars");
            DropForeignKey("dbo.KorisnikKolegijs", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.KorisnikKolegijs", "KolegijId", "dbo.Kolegijs");
            DropIndex("dbo.Seminars", new[] { "TerminId" });
            DropIndex("dbo.Seminars", new[] { "TemaId" });
            DropIndex("dbo.KorisnikKolegijs", new[] { "KolegijId" });
            DropIndex("dbo.KorisnikKolegijs", new[] { "KorisnikId" });
            DropIndex("dbo.Kolegijs", new[] { "SeminarId" });
            DropTable("dbo.Termins");
            DropTable("dbo.Temas");
            DropTable("dbo.Seminars");
            DropTable("dbo.Korisniks");
            DropTable("dbo.KorisnikKolegijs");
            DropTable("dbo.Kolegijs");
        }
    }
}
