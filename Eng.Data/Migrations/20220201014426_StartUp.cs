using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eng.Data.Migrations
{
  public partial class StartUp : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            Active = table.Column<bool>(type: "bit", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Id);
          });

      //Set initial data into User table
      migrationBuilder.Sql(@"INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Alcides Orozco Valle',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Eulalia Carrillo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Marcelino Malo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Reyna Galan Prats',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Erasmo Falcó Rius',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Aurelia Daza-Coll',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Margarita Coloma',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Jenaro del Villegas',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Victor Manuel de Galan',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Guadalupe Doménech Blazquez',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Maximino Nicodemo Valverde Chico',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Blas Milla Frías',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Esperanza Jordá Calvet',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Moreno Conesa Tamarit',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Marisela Salom Uribe',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Salomón Palmer Donaire',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Maribel Higueras Pol',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Inés Pujadas Arteaga',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Cecilia Polo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Teodoro Cortina-Pombo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Rosalía Ferrández Tamarit',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Fidel Lago Ramis',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Domitila del Mateos',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Edelmira Andrea Mate Godoy',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Sonia Zurita',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Florina Plana Benítez',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Alex Caballero Escribano',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'René Trillo Noriega',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Eligia Colomer Pozuelo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Lucía Feijoo Amaya',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Chema Paniagua Bertrán',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Noemí Gordillo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Jordi Lobo',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Inmaculada Novoa Cuesta',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Mariana del Morán',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'José Ángel Javi Rueda Barrio',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Lupita Bertrán Pedrero',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Apolonia Pazos Cifuentes',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Moisés Boix',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Pánfilo Girona Hoz',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Magdalena Valentín Jiménez',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Celestina Yuste Ponce',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Lucía Barroso Valbuena',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Cirino del Aragonés',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),1)
                             INSERT INTO dbo.[User] (Id,[Name],BirthDate,Active) values (NEWID(),'Aureliano Cerdán Ripoll',DATEADD(day, (ABS(CHECKSUM(NEWID())) % 35530), 0),0)
                             ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "User");
    }
  }
}
