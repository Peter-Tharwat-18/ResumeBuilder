using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeBuilder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addrelationsbetweentables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_AspNetUsers_ApplicationUserId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skilles_AspNetUsers_ApplicationUserId",
                table: "Skilles");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Skilles",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Skilles_ApplicationUserId",
                table: "Skilles",
                newName: "IX_Skilles_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Experiences",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_ApplicationUserId",
                table: "Experiences",
                newName: "IX_Experiences_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Educations",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_ApplicationUserId",
                table: "Educations",
                newName: "IX_Educations_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Certifications",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_ApplicationUserId",
                table: "Certifications",
                newName: "IX_Certifications_ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Skilles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Experiences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Certifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_AspNetUsers_ApplicationUserID",
                table: "Certifications",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserID",
                table: "Educations",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserID",
                table: "Experiences",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skilles_AspNetUsers_ApplicationUserID",
                table: "Skilles",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_AspNetUsers_ApplicationUserID",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserID",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skilles_AspNetUsers_ApplicationUserID",
                table: "Skilles");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Skilles",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Skilles_ApplicationUserID",
                table: "Skilles",
                newName: "IX_Skilles_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Experiences",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_ApplicationUserID",
                table: "Experiences",
                newName: "IX_Experiences_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Educations",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_ApplicationUserID",
                table: "Educations",
                newName: "IX_Educations_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Certifications",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_ApplicationUserID",
                table: "Certifications",
                newName: "IX_Certifications_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Skilles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Experiences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Certifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_AspNetUsers_ApplicationUserId",
                table: "Certifications",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_ApplicationUserId",
                table: "Educations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_ApplicationUserId",
                table: "Experiences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skilles_AspNetUsers_ApplicationUserId",
                table: "Skilles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
