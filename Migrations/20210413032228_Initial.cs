using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BYU_FEG.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burial",
                columns: table => new
                {
                    burial_ID = table.Column<int>(nullable: false),
                    burial_concat = table.Column<string>(maxLength: 30, nullable: true),
                    burial_location_NS = table.Column<string>(maxLength: 1, nullable: true),
                    burial_location_EW = table.Column<string>(maxLength: 1, nullable: true),
                    low_pair_NS = table.Column<int>(nullable: true),
                    high_pair_NS = table.Column<int>(nullable: true),
                    low_pair_EW = table.Column<int>(nullable: true),
                    high_pair_EW = table.Column<int>(nullable: true),
                    burial_subplot = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial", x => x.burial_ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    IsResearcher = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Byufeg",
                columns: table => new
                {
                    ByufegId = table.Column<int>(nullable: false),
                    Burial_ID = table.Column<int>(nullable: true),
                    burial_depth = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    south_to_head = table.Column<int>(nullable: true),
                    south_to_feet = table.Column<int>(nullable: true),
                    east_to_head = table.Column<int>(nullable: true),
                    east_to_feet = table.Column<int>(nullable: true),
                    burial_situation = table.Column<string>(maxLength: 1500, nullable: true),
                    length_of_remains = table.Column<int>(nullable: true),
                    burial_number = table.Column<int>(nullable: true),
                    sample_number = table.Column<int>(nullable: true),
                    gender_GE = table.Column<string>(maxLength: 20, nullable: true),
                    GE_function_total = table.Column<decimal>(type: "numeric(8, 4)", nullable: true),
                    gender_body_col = table.Column<string>(maxLength: 20, nullable: true),
                    basilar_suture = table.Column<string>(maxLength: 6, nullable: true),
                    ventral_arc = table.Column<int>(nullable: true),
                    subpubic_angle = table.Column<int>(nullable: true),
                    sciatic_notch = table.Column<int>(nullable: true),
                    pubic_bone = table.Column<int>(nullable: true),
                    preaur_sulcus = table.Column<int>(nullable: true),
                    medial_IP_ramus = table.Column<int>(nullable: true),
                    dorsal_pitting = table.Column<int>(nullable: true),
                    foreman_magnum = table.Column<int>(nullable: true),
                    femur_head = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    humerus_head = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    osteophytosis = table.Column<string>(maxLength: 8, nullable: true),
                    pubic_symphysis = table.Column<string>(maxLength: 2, nullable: true),
                    bone_length = table.Column<int>(nullable: true),
                    medial_clavicle = table.Column<int>(nullable: true),
                    iliac_crest = table.Column<int>(nullable: true),
                    femur_diameter = table.Column<int>(nullable: true),
                    humerus = table.Column<int>(nullable: true),
                    femur_length = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    humerus_length = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    tibia_length = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    robust = table.Column<int>(nullable: true),
                    supraorbital_ridges = table.Column<int>(nullable: true),
                    orbit_edge = table.Column<int>(nullable: true),
                    parietal_bossing = table.Column<int>(nullable: true),
                    gonian = table.Column<int>(nullable: true),
                    nuchal_crest = table.Column<int>(nullable: true),
                    zygomatic_crest = table.Column<int>(nullable: true),
                    cranial_suture = table.Column<string>(maxLength: 13, nullable: true),
                    maximum_cranial_length = table.Column<decimal>(type: "numeric(6, 2)", nullable: true),
                    maximum_cranial_breadth = table.Column<decimal>(type: "numeric(6, 2)", nullable: true),
                    basion_bregma_height = table.Column<decimal>(type: "numeric(6, 2)", nullable: true),
                    basion_nasion = table.Column<decimal>(type: "numeric(6, 2)", nullable: true),
                    basion_prosthion_length = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    bizygomatic_diameter = table.Column<decimal>(type: "numeric(6, 2)", nullable: true),
                    nasion_prosthion = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    maximum_nasal_breadth = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    interorbital_breadth = table.Column<decimal>(type: "numeric(5, 2)", nullable: true),
                    artifacts_description = table.Column<string>(maxLength: 200, nullable: true),
                    hair_color = table.Column<string>(maxLength: 10, nullable: true),
                    preservation_index = table.Column<string>(maxLength: 3, nullable: true),
                    hair_taken = table.Column<string>(maxLength: 5, nullable: true),
                    soft_tissue_taken = table.Column<string>(maxLength: 5, nullable: true),
                    bone_taken = table.Column<string>(maxLength: 5, nullable: true),
                    tooth_taken = table.Column<string>(maxLength: 5, nullable: true),
                    textile_taken = table.Column<string>(maxLength: 5, nullable: true),
                    description_of_taken = table.Column<string>(maxLength: 200, nullable: true),
                    artifact_found = table.Column<string>(maxLength: 5, nullable: true),
                    estimate_age = table.Column<decimal>(type: "numeric(3, 1)", nullable: true),
                    estimate_living_stature = table.Column<decimal>(type: "numeric(6, 3)", nullable: true),
                    tooth_attrition = table.Column<string>(maxLength: 3, nullable: true),
                    tooth_eruption = table.Column<string>(maxLength: 42, nullable: true),
                    pathology_anomalies = table.Column<string>(maxLength: 169, nullable: true),
                    epiphyseal_union = table.Column<string>(maxLength: 12, nullable: true),
                    head_direction = table.Column<string>(maxLength: 5, nullable: true),
                    date_found = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: true),
                    Rack = table.Column<string>(maxLength: 30, nullable: true),
                    Shelf = table.Column<string>(maxLength: 30, nullable: true),
                    Skull_Trauma = table.Column<string>(maxLength: 5, nullable: true),
                    Postcrania_Trauma = table.Column<string>(maxLength: 5, nullable: true),
                    Cribra_Orbitala = table.Column<string>(maxLength: 5, nullable: true),
                    Porotic_Hyperostosis_Location = table.Column<string>(maxLength: 5, nullable: true),
                    Metopic_Suture = table.Column<string>(maxLength: 5, nullable: true),
                    Button_Osteoma = table.Column<string>(maxLength: 5, nullable: true),
                    Postcrania_Trauma_1 = table.Column<string>(maxLength: 5, nullable: true),
                    Osteology_unknown_comment = table.Column<string>(maxLength: 5, nullable: true),
                    Temporal_Mandibular_Joint_Osteoarthritis_TMJ_OA = table.Column<string>(maxLength: 5, nullable: true),
                    Linear_Hypoplasia_Enamel = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Byufeg", x => x.ByufegId);
                    table.ForeignKey(
                        name: "FK__Byufeg__Burial_I__571DF1D5",
                        column: x => x.Burial_ID,
                        principalTable: "Burial",
                        principalColumn: "burial_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false),
                    ByufegId = table.Column<int>(nullable: true),
                    AttachmentUrl = table.Column<string>(maxLength: 200, nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK__Attachmen__Byufe__5CD6CB2B",
                        column: x => x.ByufegId,
                        principalTable: "Byufeg",
                        principalColumn: "ByufegId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ByufegId",
                table: "Attachment",
                column: "ByufegId");

            migrationBuilder.CreateIndex(
                name: "IX_Byufeg_Burial_ID",
                table: "Byufeg",
                column: "Burial_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "Byufeg");

            migrationBuilder.DropTable(
                name: "Burial");
        }
    }
}
