using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReplicandoAPI.Migrations
{
    /// <inheritdoc />
    public partial class inicarBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("20769474-d3b8-44c4-a55d-8f22d45e085e"), null, "Personales", 20 },
                    { new Guid("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d"), null, "Laborales", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareId", "Descripcion", "FechaCreacion", "Nombre", "Prioridad", "categoriaId" },
                values: new object[,]
                {
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37210"), null, new DateTime(2023, 9, 12, 13, 44, 50, 544, DateTimeKind.Local).AddTicks(3198), "Ir GYM", 0, new Guid("20769474-d3b8-44c4-a55d-8f22d45e085e") },
                    { new Guid("71c3ac95-768d-4d95-bff8-e523f2a37211"), null, new DateTime(2023, 9, 12, 13, 44, 50, 544, DateTimeKind.Local).AddTicks(3220), "Presentar API", 2, new Guid("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_categoriaId",
                table: "Tarea",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
