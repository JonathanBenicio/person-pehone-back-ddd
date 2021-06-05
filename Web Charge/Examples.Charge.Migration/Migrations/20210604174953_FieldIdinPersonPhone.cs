using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examples.Charge.Infra.Data.Configuration.Migrations
{
    public partial class FieldIdinPersonPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonPhone",
                schema: "dbo",
                table: "PersonPhone");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "PersonPhone",
                keyColumns: new[] { "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                keyValues: new object[] { 1, "(19)99999-2883", 1 });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "PersonPhone",
                keyColumns: new[] { "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                keyValues: new object[] { 1, "(19)99999-4021", 2 });

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "PersonPhone",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "PersonPhone",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonPhone",
                schema: "dbo",
                table: "PersonPhone",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "Id", "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                values: new object[] { 1, 1, "(19)99999-2883", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "Id", "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                values: new object[] { 2, 1, "(19)99999-4021", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_BusinessEntityID",
                schema: "dbo",
                table: "PersonPhone",
                column: "BusinessEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonPhone",
                schema: "dbo",
                table: "PersonPhone");

            migrationBuilder.DropIndex(
                name: "IX_PersonPhone_BusinessEntityID",
                schema: "dbo",
                table: "PersonPhone");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "PersonPhone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "PersonPhone",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonPhone",
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" });
        }
    }
}
