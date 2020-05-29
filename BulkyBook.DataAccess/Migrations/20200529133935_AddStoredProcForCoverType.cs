using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class AddStoredProcForCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Tbl_CoverType 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverType 
                                    @CoverTypeId int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Tbl_CoverType  WHERE  (CoverTypeId = @CoverTypeId) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCoverType
	                                @CoverTypeId int,
	                                @CoverTypeName nvarchar(50)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.Tbl_CoverType
                                     SET  CoverTypeName = @CoverTypeName
                                     WHERE  CoverTypeId = @CoverTypeId
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteCoverType
	                                @CoverTypeId int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.Tbl_CoverType
                                     WHERE  CoverTypeId = @CoverTypeId
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateCoverType
                                   @CoverTypeName nvarchar(50)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.Tbl_CoverType(CoverTypeName)
                                    VALUES (@CoverTypeName)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoverType");
        }
    }
}
