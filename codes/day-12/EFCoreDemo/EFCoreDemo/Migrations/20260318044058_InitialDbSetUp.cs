using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    dept_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    dept_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    emp_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.dept_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    emp_salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    emp_mobile = table.Column<long>(type: "bigint", nullable: false),
                    emp_email = table.Column<string>(type: "varchar(50)", nullable: false),
                    emp_dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.emp_id);
                    table.ForeignKey(
                        name: "FK_employees_departments_emp_dept_id",
                        column: x => x.emp_dept_id,
                        principalTable: "departments",
                        principalColumn: "dept_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_emp_dept_id",
                table: "employees",
                column: "emp_dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
