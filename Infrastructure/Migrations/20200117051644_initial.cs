using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    username = table.Column<string>(type: "varchar(255)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 20, nullable: false),
                    state = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", nullable: false),
                    secondname = table.Column<string>(type: "varchar(50)", nullable: true),
                    first_lastname = table.Column<string>(type: "varchar(50)", nullable: false),
                    second_lastname = table.Column<string>(type: "varchar(50)", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_at", "password", "state", "updated_at", "username" },
                values: new object[] { 1, 0L, "AR4uQBbIGbJZh/snXG5ozGIWcow4/zlRBdUh6Do8Z32F33oWGNcVBzCHNwoBxSWk/Q==", (short)1, 0L, "zeros" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_at", "password", "state", "updated_at", "username" },
                values: new object[] { 2, 0L, "AYINXkIRKuCWM8HRdIQma04OeOOs5JLGBLZ0jtM4HLdWuIIR4taIqcaJV6RDkI9xKQ==", (short)1, 0L, "test" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "created_at", "first_lastname", "firstname", "second_lastname", "secondname", "updated_at", "user_id" },
                values: new object[] { 1, 0L, "Andrés", "Carlos", "García", "Castilla", 0L, 1 });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "created_at", "first_lastname", "firstname", "second_lastname", "secondname", "updated_at", "user_id" },
                values: new object[] { 2, 0L, "Test", "Test", "Test", "Test", 0L, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_persons_user_id",
                table: "persons",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_username",
                table: "user",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
