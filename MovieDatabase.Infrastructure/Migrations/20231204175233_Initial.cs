using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    BoxOffice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieActor",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieActor", x => new { x.ActorsId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieMovieActor_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0a3abde0-f162-4db2-a7e7-5643f1d58b4d"), "Ryan", "Gosling" },
                    { new Guid("0da5afee-318b-41ac-ba1e-f8cfff666dd9"), "Bradley", "Cooper" },
                    { new Guid("146effe4-49d6-4ffc-948c-c566cfc64843"), "Bruce", "Willis" },
                    { new Guid("1a55dcfb-a1d3-45ff-ae58-e621e2a424ad"), "Edward", "Norton" },
                    { new Guid("23935d7f-ec38-40d9-9128-2b1bc976205f"), "Rutger", "Hauer" },
                    { new Guid("301011d6-1c02-4d2d-9940-6a0fa45c6f76"), "Leonardo", "DiCaprio" },
                    { new Guid("38bfd380-187c-4448-82a4-f208ef032b6e"), "Colin", "Farrell" },
                    { new Guid("3c7f7291-af01-4187-bd01-3571fc9886df"), "Harrison", "Ford" },
                    { new Guid("45dd20db-823b-4e96-bba4-d7fc36783d18"), "Michael", "Keaton" },
                    { new Guid("4b124488-270d-4a06-9003-dc9a1787b55d"), "Zach", "Galifianakis" },
                    { new Guid("7dc4bf77-61bc-4579-abf1-4d064dce0ed3"), "Brendan", "Gleeson" },
                    { new Guid("88dcbc82-cbc4-4eb9-9739-9a7b74902fd7"), "Jesse", "Plemons" },
                    { new Guid("947a99ac-592e-4a21-bbff-f12ff61826f6"), "Uma", "Thurman" },
                    { new Guid("adea0690-9f31-4d69-a2bb-a2183cf156e5"), "John", "Travolta" },
                    { new Guid("d33fed2e-7e98-4414-8826-ead5f473dd7a"), "Emma", "Stone" },
                    { new Guid("daed329f-1278-4d62-86b1-28e515c7c476"), "Brad", "Pitt" },
                    { new Guid("f2c16575-06b5-405c-add4-25256d5efa95"), "Samuel L.", "Jackson" },
                    { new Guid("f6a21b06-4d74-46f6-8bd5-54a16fdf074b"), "Sean", "Young" },
                    { new Guid("f923c19b-50e4-444a-8dfc-bc490000d1c1"), "Robert", "De Niro" },
                    { new Guid("ff25b94c-dd14-4dc4-8e93-9c8636ce92db"), "Kate", "Winslet" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("64c3c179-2924-48c9-a521-d4e936588fcc"), "Ridley", "Scott" },
                    { new Guid("6a86a3d1-8778-4b23-b774-12a32a9c09d3"), "James", "Cameron" },
                    { new Guid("7d6d7422-343f-4a01-83e4-7f994c89751f"), "Francis", "Ford Coppola" },
                    { new Guid("8c0c48df-4010-4819-90d5-5a9c676052c2"), "Martin", "McDonagh" },
                    { new Guid("bfbd87c3-4fdc-477d-8d25-fb43c7e0f3cc"), "Quentin", "Tarantino" },
                    { new Guid("d8fe0aab-36c2-4a8b-ae50-9230bc84216e"), "Martin", "Scorsese" },
                    { new Guid("e1be7b21-c0c9-4559-9276-7bb290796c4c"), "Damien", "Chazelle" },
                    { new Guid("e1d8672d-2472-4582-9b7d-0f61d6bb841a"), "Alejandro G.", "Inarritu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieActor_MovieId",
                table: "MovieMovieActor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMovieActor");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
