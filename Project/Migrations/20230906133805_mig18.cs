using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanunWebsite.Migrations
{
    /// <inheritdoc />
    public partial class mig18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedIn",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedIn",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                table: "Users",
                type: "ntext",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
