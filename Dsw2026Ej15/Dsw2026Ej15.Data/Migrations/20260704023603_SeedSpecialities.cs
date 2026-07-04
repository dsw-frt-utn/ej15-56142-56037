using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dsw2026Ej15.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecialities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1b9c5d7e-8a42-4f63-9d8e-3c7a1f5b2e64"), "Especialidad médica que trata los trastornos del sistema nervioso central y periférico.", "Neurología" },
                    { new Guid("2f7b6c1a-9d34-4a85-b7e2-8c5d1f9a3b97"), "Especialidad médica encargada de la prevención, diagnóstico y tratamiento de enfermedades de los ojos y la visión.", "Oftalmología" },
                    { new Guid("4a6e2b9c-8d15-4f73-b1c8-9e7a3d5f2b19"), "Especialidad médica dedicada al diagnóstico, tratamiento y prevención de trastornos mentales y emocionales.", "Psiquiatría" },
                    { new Guid("5e2a8c1d-4b73-4d96-a1f5-7c9b2e6d8a75"), "Área médica dedicada al diagnóstico y tratamiento de lesiones y enfermedades del sistema musculoesquelético.", "Traumatología" },
                    { new Guid("6b1f9d3a-5c47-4e82-a7d5-2f8c6b1e3a20"), "Especialidad que aborda las enfermedades del oído, nariz, garganta y estructuras relacionadas.", "Otorrinolaringología" },
                    { new Guid("7c3d8e5a-1f62-4b94-a9d3-6e2b7c1f4a08"), "Rama de la medicina que estudia y trata trastornos hormonales y enfermedades de las glándulas endocrinas.", "Endocrinología" },
                    { new Guid("8a1f3b78-3f66-4d68-8d6e-1c5b9c7a2f41"), "Especialidad médica dedicada al diagnóstico, tratamiento y prevención de enfermedades del corazón y del sistema cardiovascular.", "Cardiología" },
                    { new Guid("9d4f1a7b-2c85-4e31-b6d7-5a8c3f2e9b86"), "Especialidad orientada a la salud del aparato reproductor femenino y la prevención de enfermedades asociadas.", "Ginecología" },
                    { new Guid("c7e8d4b2-5f91-4a37-b8d4-9e2c6f1a7b53"), "Especialidad enfocada en el estudio, diagnóstico y tratamiento de enfermedades de la piel, cabello y uñas.", "Dermatología" },
                    { new Guid("f4d2c9a1-7b3e-4f8d-9c61-2e7a5d8b3c12"), "Rama de la medicina que se ocupa de la salud integral de niños, niñas y adolescentes.", "Pediatría" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("1b9c5d7e-8a42-4f63-9d8e-3c7a1f5b2e64"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("2f7b6c1a-9d34-4a85-b7e2-8c5d1f9a3b97"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("4a6e2b9c-8d15-4f73-b1c8-9e7a3d5f2b19"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("5e2a8c1d-4b73-4d96-a1f5-7c9b2e6d8a75"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("6b1f9d3a-5c47-4e82-a7d5-2f8c6b1e3a20"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("7c3d8e5a-1f62-4b94-a9d3-6e2b7c1f4a08"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("8a1f3b78-3f66-4d68-8d6e-1c5b9c7a2f41"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("9d4f1a7b-2c85-4e31-b6d7-5a8c3f2e9b86"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("c7e8d4b2-5f91-4a37-b8d4-9e2c6f1a7b53"));

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("f4d2c9a1-7b3e-4f8d-9c61-2e7a5d8b3c12"));
        }
    }
}
