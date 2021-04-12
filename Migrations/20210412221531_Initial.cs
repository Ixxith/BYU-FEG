using Microsoft.EntityFrameworkCore.Migrations;

namespace BYU_FEG.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateIndex(
                name: "IX_ActivityToPerson_ActivityId",
                table: "ActivityToPerson",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityToPerson_PersonId",
                table: "ActivityToPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ByufegId",
                table: "Attachment",
                column: "ByufegId");

            migrationBuilder.CreateIndex(
                name: "IX_Byufeg_ActivityId",
                table: "Byufeg",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Byufeg_Burial_ID",
                table: "Byufeg",
                column: "Burial_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityToPerson");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Byufeg");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Burial");
        }
    }
}
