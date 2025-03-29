using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatingCategoryNameAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"   
        UPDATE Categories SET Name = 'Intelligence' WHERE Id = 1;
        UPDATE Categories SET Name = 'Fiction' WHERE Id = 2;
        UPDATE Categories SET Name = 'Fantasy' WHERE Id = 3;
        -- Add more as needed ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
