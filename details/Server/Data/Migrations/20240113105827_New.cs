using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace details.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "HotelRooms",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "HotelRooms",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "HotelRooms",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "HotelRooms",
                newName: "RoomNumber");
        }
    }
}
