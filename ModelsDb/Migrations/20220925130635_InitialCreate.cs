using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsDb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id_client = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    birt_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pasport_num = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id_employee = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    birt_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pasport_num = table.Column<int>(type: "integer", nullable: false),
                    salary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id_employee);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    ClientDbId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_accounts_clients_ClientDbId",
                        column: x => x.ClientDbId,
                        principalTable: "clients",
                        principalColumn: "id_client");
                });

            migrationBuilder.CreateTable(
                name: "currences",
                columns: table => new
                {
                    currence_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currences", x => x.currence_id);
                    table.ForeignKey(
                        name: "FK_currences_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_ClientDbId",
                table: "accounts",
                column: "ClientDbId");

            migrationBuilder.CreateIndex(
                name: "IX_currences_account_id",
                table: "currences",
                column: "account_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currences");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
