namespace mvcdrc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbldepartments",
                c => new
                    {
                        did = c.Int(nullable: false, identity: true),
                        dname = c.String(),
                    })
                .PrimaryKey(t => t.did);
            
            CreateTable(
                "dbo.tblgenders",
                c => new
                    {
                        gid = c.Int(nullable: false, identity: true),
                        gname = c.String(),
                    })
                .PrimaryKey(t => t.gid);
            
            CreateTable(
                "dbo.tblhobbies",
                c => new
                    {
                        hid = c.Int(nullable: false, identity: true),
                        hname = c.String(),
                    })
                .PrimaryKey(t => t.hid);
            
            CreateTable(
                "dbo.tblregistrations",
                c => new
                    {
                        rid = c.Int(nullable: false, identity: true),
                        rname = c.String(),
                        remail = c.String(),
                        rpassword = c.String(),
                        rdepartment = c.Int(nullable: false),
                        rgender = c.Int(nullable: false),
                        rhobbies = c.String(),
                    })
                .PrimaryKey(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblregistrations");
            DropTable("dbo.tblhobbies");
            DropTable("dbo.tblgenders");
            DropTable("dbo.tbldepartments");
        }
    }
}
