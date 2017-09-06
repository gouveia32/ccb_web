namespace ccb_web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarcliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120, unicode: false),
                        Contato_Funcao = c.String(maxLength: 20, unicode: false),
                        Contato_Nome = c.String(maxLength: 40, unicode: false),
                        Cgc_Cpf = c.String(maxLength: 18, unicode: false),
                        Inscr_Estadual = c.String(maxLength: 20, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Cidade = c.String(maxLength: 40, unicode: false),
                        Estado = c.String(maxLength: 2, unicode: false),
                        Cep = c.String(maxLength: 9, unicode: false),
                        Telefone1 = c.String(maxLength: 20, unicode: false),
                        Telefone2 = c.String(maxLength: 20, unicode: false),
                        Telefone3 = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 60, unicode: false),
                        Obs = c.String(maxLength: 1024, unicode: false),
                        Preco_Base = c.Decimal(nullable: false, precision: 6, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
