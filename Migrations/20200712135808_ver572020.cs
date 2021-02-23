using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCore.Migrations
{
    public partial class ver572020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPatient",
                columns: table => new
                {
                    PatientName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient", x => x.PatientName);
                });

            migrationBuilder.CreateTable(
                name: "tblProblem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientProblem = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProblem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblProblem_tblPatient_PatientName",
                        column: x => x.PatientName,
                        principalTable: "tblPatient",
                        principalColumn: "PatientName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProblem_PatientName",
                table: "tblProblem",
                column: "PatientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProblem");

            migrationBuilder.DropTable(
                name: "tblPatient");
        }
    }
}
