using Microsoft.EntityFrameworkCore.Migrations;

namespace bdis_meistrija.Server.Migrations
{
    public partial class NaikintojasRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into AspNetRoles (Id, [Name], NormalizedName) values ('c17bbf9c-230a-4e50-8f65-670834bdd46b', 'naikintojas', 'naikintojas') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetRoles where Id = 'c17bbf9c-230a-4e50-8f65-670834bdd46b'");
        }
    }
}
