using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetPosterURLtoOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movies",
                type: "nvarchar(2084)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "Movies",
                type: "nvarchar(2084)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)",
                oldNullable: true);
        }
    }
}
