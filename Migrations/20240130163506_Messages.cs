using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessagingApp.Migrations
{
    /// <inheritdoc />
    public partial class Messages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Group_GroupsId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ReciverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SentById",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SentById",
                table: "Messages",
                newName: "IX_Messages_SentById");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ReciverId",
                table: "Messages",
                newName: "IX_Messages_ReciverId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupId",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupsId",
                table: "GroupUser",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverId",
                table: "Messages",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupsId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReciverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SentById",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SentById",
                table: "Message",
                newName: "IX_Message_SentById");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReciverId",
                table: "Message",
                newName: "IX_Message_ReciverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Message",
                newName: "IX_Message_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Group_GroupsId",
                table: "GroupUser",
                column: "GroupsId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ReciverId",
                table: "Message",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SentById",
                table: "Message",
                column: "SentById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }
    }
}
