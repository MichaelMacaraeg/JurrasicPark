using Microsoft.EntityFrameworkCore.Migrations;

namespace JurrasicPark.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPowered = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinosaur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SpeciesTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinosaur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodTypeDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesType",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpeciesTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesType", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "IsPowered", "MaxCapacity" },
                values: new object[] { 1, true, 10 });

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "IsPowered", "MaxCapacity" },
                values: new object[] { 2, true, 5 });

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "IsPowered", "MaxCapacity" },
                values: new object[] { 3, true, 5 });

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "IsPowered", "MaxCapacity" },
                values: new object[] { 4, true, 7 });

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "IsPowered", "MaxCapacity" },
                values: new object[] { 5, true, 10 });

            migrationBuilder.InsertData(
                table: "Dinosaur",
                columns: new[] { "Id", "CageId", "FoodTypeId", "Name", "SpeciesTypeId" },
                values: new object[] { 1, 1, 1, "T-Rex", 8 });

            migrationBuilder.InsertData(
                table: "Dinosaur",
                columns: new[] { "Id", "CageId", "FoodTypeId", "Name", "SpeciesTypeId" },
                values: new object[] { 2, 2, 1, "Raptor", 9 });

            migrationBuilder.InsertData(
                table: "Dinosaur",
                columns: new[] { "Id", "CageId", "FoodTypeId", "Name", "SpeciesTypeId" },
                values: new object[] { 3, 3, 2, "Stego", 2 });

            migrationBuilder.InsertData(
                table: "FoodType",
                columns: new[] { "id", "FoodTypeDescription" },
                values: new object[] { 1, "Carnivore" });

            migrationBuilder.InsertData(
                table: "FoodType",
                columns: new[] { "id", "FoodTypeDescription" },
                values: new object[] { 2, "Herbivore" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 9, "Velociraptor" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 8, "Tyrannosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 7, "Carnotaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 12, "Ceratosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 6, "Triceratops" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 1, "Pachycephalosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 4, "Brachiosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 3, "Tenontosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 2, "Stegosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 10, "Spinosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 5, "Ankylosaurus" });

            migrationBuilder.InsertData(
                table: "SpeciesType",
                columns: new[] { "id", "SpeciesTypeName" },
                values: new object[] { 11, "Megalosaurus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cage");

            migrationBuilder.DropTable(
                name: "Dinosaur");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "SpeciesType");
        }
    }
}
