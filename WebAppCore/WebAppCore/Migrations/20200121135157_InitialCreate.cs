using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    dept_id = table.Column<int>(nullable: false),
                    dept_name = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__DCA6597455DFCF34", x => x.dept_id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    emp_id = table.Column<int>(nullable: false),
                    dept_id = table.Column<int>(nullable: true),
                    mngr_id = table.Column<int>(nullable: true),
                    emp_name = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    salary = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__1299A86160218078", x => x.emp_id);
                    table.ForeignKey(
                        name: "FK__Employee__dept_i__286302EC",
                        column: x => x.dept_id,
                        principalTable: "Department",
                        principalColumn: "dept_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Employee__mngr_i__276EDEB3",
                        column: x => x.mngr_id,
                        principalTable: "Employee",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_dept_id",
                table: "Employee",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_mngr_id",
                table: "Employee",
                column: "mngr_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
