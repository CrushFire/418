using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "idanamnesiscreater");

            migrationBuilder.CreateSequence(
                name: "idcreater");

            migrationBuilder.CreateSequence(
                name: "idtreatmentcreater");

            migrationBuilder.CreateTable(
                name: "human",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false, defaultValueSql: "nextval('idcreater'::regclass)"),
                    role = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("human_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ward",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    count_place = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ward_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false, defaultValueSql: "nextval('idcreater'::regclass)"),
                    fio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qualification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctor_pkey", x => x.id);
                    table.ForeignKey(
                        name: "doctor_id_fkey",
                        column: x => x.id,
                        principalTable: "human",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false, defaultValueSql: "nextval('idcreater'::regclass)"),
                    gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    passport = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    omc = table.Column<string>(type: "character(16)", fixedLength: true, maxLength: 16, nullable: false),
                    cnils = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    second_name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    otchestvo = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("patient_pkey", x => x.id);
                    table.ForeignKey(
                        name: "patient_id_fkey",
                        column: x => x.id,
                        principalTable: "human",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    day = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    ward = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    id_patient = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("place_pkey", x => new { x.id, x.day, x.ward, x.time });
                    table.ForeignKey(
                        name: "place_id_patient_fkey",
                        column: x => x.id_patient,
                        principalTable: "human",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "place_ward_fkey",
                        column: x => x.ward,
                        principalTable: "ward",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anamnesis",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false, defaultValueSql: "nextval('idanamnesiscreater'::regclass)"),
                    complaint = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    prediagnosis = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id_doctor = table.Column<decimal>(type: "numeric", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    id_patient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("anamnesis_pkey", x => x.id);
                    table.ForeignKey(
                        name: "anamnesis_id_doctor_fkey",
                        column: x => x.id_doctor,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "anamnesis_id_patient_fkey",
                        column: x => x.id_patient,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "treatment",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false, defaultValueSql: "nextval('idtreatmentcreater'::regclass)"),
                    drug = table.Column<string>(type: "text", nullable: false),
                    recomendation = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    health = table.Column<string>(type: "text", nullable: false),
                    analysis = table.Column<string>(type: "text", nullable: false),
                    diagnosis = table.Column<string>(type: "text", nullable: false),
                    duration_health = table.Column<int>(type: "integer", nullable: false),
                    id_patient = table.Column<decimal>(type: "numeric", nullable: false),
                    id_doctor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("treatment_pkey", x => x.id);
                    table.ForeignKey(
                        name: "treatment_id_patient_fkey",
                        column: x => x.id_patient,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analisis",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric", nullable: false),
                    data_downoald = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    wave = table.Column<string>(type: "text", nullable: false),
                    id_treatment = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("analisis_pkey", x => x.id);
                    table.ForeignKey(
                        name: "analisis_id_treatment_fkey",
                        column: x => x.id_treatment,
                        principalTable: "treatment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_analisis_id_treatment",
                table: "analisis",
                column: "id_treatment");

            migrationBuilder.CreateIndex(
                name: "IX_anamnesis_id_doctor",
                table: "anamnesis",
                column: "id_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_anamnesis_id_patient",
                table: "anamnesis",
                column: "id_patient");

            migrationBuilder.CreateIndex(
                name: "IX_place_id_patient",
                table: "place",
                column: "id_patient");

            migrationBuilder.CreateIndex(
                name: "IX_place_ward",
                table: "place",
                column: "ward");

            migrationBuilder.CreateIndex(
                name: "IX_treatment_id_patient",
                table: "treatment",
                column: "id_patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analisis");

            migrationBuilder.DropTable(
                name: "anamnesis");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "treatment");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "ward");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "human");

            migrationBuilder.DropSequence(
                name: "idanamnesiscreater");

            migrationBuilder.DropSequence(
                name: "idcreater");

            migrationBuilder.DropSequence(
                name: "idtreatmentcreater");
        }
    }
}
