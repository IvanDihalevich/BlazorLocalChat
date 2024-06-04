using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalChat.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_chatRoomIdId",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_User_userId",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_messedgeUsers_MessegeUsersId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messedgeUsers_User_ReceiverId",
                table: "messedgeUsers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_messedgeUsers_ReceiverId",
                table: "messedgeUsers");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessegeUsersId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_ChatRoomUsers_chatRoomIdId",
                table: "ChatRoomUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatRoomUsers_userId",
                table: "ChatRoomUsers");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "messedgeUsers");

            migrationBuilder.DropColumn(
                name: "ChatRoomId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessedgeUsersId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessegeUsersId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SendTime",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "chatRoomIdId",
                table: "ChatRoomUsers");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "ChatRoomUsers");

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "messedgeUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChatRoomUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "messedgeUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChatRoomUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "messedgeUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatRoomId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessedgeUsersId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessegeUsersId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendTime",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "chatRoomIdId",
                table: "ChatRoomUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "ChatRoomUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messedgeUsers_ReceiverId",
                table: "messedgeUsers",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessegeUsersId",
                table: "Messages",
                column: "MessegeUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUsers_chatRoomIdId",
                table: "ChatRoomUsers",
                column: "chatRoomIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUsers_userId",
                table: "ChatRoomUsers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_chatRoomIdId",
                table: "ChatRoomUsers",
                column: "chatRoomIdId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_User_userId",
                table: "ChatRoomUsers",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_messedgeUsers_MessegeUsersId",
                table: "Messages",
                column: "MessegeUsersId",
                principalTable: "messedgeUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_messedgeUsers_User_ReceiverId",
                table: "messedgeUsers",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
