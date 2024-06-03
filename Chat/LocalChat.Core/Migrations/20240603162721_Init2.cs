using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalChat.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_messedgeUsers_MessedgeUsersId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessedgeUsersId",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "MessegeUsersId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessegeUsersId",
                table: "Messages",
                column: "MessegeUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_messedgeUsers_MessegeUsersId",
                table: "Messages",
                column: "MessegeUsersId",
                principalTable: "messedgeUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_messedgeUsers_MessegeUsersId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessegeUsersId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessegeUsersId",
                table: "Messages");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessedgeUsersId",
                table: "Messages",
                column: "MessedgeUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_messedgeUsers_MessedgeUsersId",
                table: "Messages",
                column: "MessedgeUsersId",
                principalTable: "messedgeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
