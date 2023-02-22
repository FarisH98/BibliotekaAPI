using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliotekas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRadnika = table.Column<double>(type: "float", nullable: false),
                    RadniDani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MjesecnaClanarina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotekas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjiges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKnjige = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MjesecnoIzdavana = table.Column<double>(type: "float", nullable: false),
                    OpisKnjige = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radnicis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivRadnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRadnihSati = table.Column<double>(type: "float", nullable: false),
                    Rejting = table.Column<double>(type: "float", nullable: false),
                    Plata = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnicis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bibliotekas");

            migrationBuilder.DropTable(
                name: "Knjiges");

            migrationBuilder.DropTable(
                name: "Radnicis");
        }
    }
}
