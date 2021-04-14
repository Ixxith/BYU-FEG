﻿// <auto-generated />
using System;
using BYU_FEG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BYU_FEG.Migrations
{
    [DbContext(typeof(BYUFEGContext))]
    [Migration("20210414033527_Update10")]
    partial class Update10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BYU_FEG.Models.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentUrl")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("ByufegId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("AttachmentId");

                    b.HasIndex("ByufegId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("BYU_FEG.Models.Burial", b =>
                {
                    b.Property<int>("BurialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("burial_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BurialConcat")
                        .HasColumnName("burial_concat")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("BurialLocationEw")
                        .HasColumnName("burial_location_EW")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("BurialLocationNs")
                        .HasColumnName("burial_location_NS")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("BurialSubplot")
                        .HasColumnName("burial_subplot")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int?>("HighPairEw")
                        .HasColumnName("high_pair_EW")
                        .HasColumnType("int");

                    b.Property<int?>("HighPairNs")
                        .HasColumnName("high_pair_NS")
                        .HasColumnType("int");

                    b.Property<int?>("LowPairEw")
                        .HasColumnName("low_pair_EW")
                        .HasColumnType("int");

                    b.Property<int?>("LowPairNs")
                        .HasColumnName("low_pair_NS")
                        .HasColumnType("int");

                    b.HasKey("BurialId");

                    b.ToTable("Burial");
                });

            modelBuilder.Entity("BYU_FEG.Models.Byufeg", b =>
                {
                    b.Property<int>("ByufegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtifactFound")
                        .HasColumnName("artifact_found")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("ArtifactsDescription")
                        .HasColumnName("artifacts_description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("BasilarSuture")
                        .HasColumnName("basilar_suture")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<decimal?>("BasionBregmaHeight")
                        .HasColumnName("basion_bregma_height")
                        .HasColumnType("numeric(6, 2)");

                    b.Property<decimal?>("BasionNasion")
                        .HasColumnName("basion_nasion")
                        .HasColumnType("numeric(6, 2)");

                    b.Property<decimal?>("BasionProsthionLength")
                        .HasColumnName("basion_prosthion_length")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<decimal?>("BizygomaticDiameter")
                        .HasColumnName("bizygomatic_diameter")
                        .HasColumnType("numeric(6, 2)");

                    b.Property<int?>("BoneLength")
                        .HasColumnName("bone_length")
                        .HasColumnType("int");

                    b.Property<string>("BoneTaken")
                        .HasColumnName("bone_taken")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal?>("BurialDepth")
                        .HasColumnName("burial_depth")
                        .HasColumnType("numeric(4, 1)");

                    b.Property<int?>("BurialId")
                        .HasColumnName("Burial_ID")
                        .HasColumnType("int");

                    b.Property<int?>("BurialNumber")
                        .HasColumnName("burial_number")
                        .HasColumnType("int");

                    b.Property<string>("BurialSituation")
                        .HasColumnName("burial_situation")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("ButtonOsteoma")
                        .HasColumnName("Button_Osteoma")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("CranialSuture")
                        .HasColumnName("cranial_suture")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("CribraOrbitala")
                        .HasColumnName("Cribra_Orbitala")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime?>("DateFound")
                        .HasColumnName("date_found")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfTaken")
                        .HasColumnName("description_of_taken")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("DorsalPitting")
                        .HasColumnName("dorsal_pitting")
                        .HasColumnType("int");

                    b.Property<int?>("EastToFeet")
                        .HasColumnName("east_to_feet")
                        .HasColumnType("int");

                    b.Property<int?>("EastToHead")
                        .HasColumnName("east_to_head")
                        .HasColumnType("int");

                    b.Property<string>("EpiphysealUnion")
                        .HasColumnName("epiphyseal_union")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<decimal?>("EstimateAge")
                        .HasColumnName("estimate_age")
                        .HasColumnType("numeric(3, 1)");

                    b.Property<decimal?>("EstimateLivingStature")
                        .HasColumnName("estimate_living_stature")
                        .HasColumnType("numeric(6, 3)");

                    b.Property<int?>("FemurDiameter")
                        .HasColumnName("femur_diameter")
                        .HasColumnType("int");

                    b.Property<decimal?>("FemurHead")
                        .HasColumnName("femur_head")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<decimal?>("FemurLength")
                        .HasColumnName("femur_length")
                        .HasColumnType("numeric(4, 1)");

                    b.Property<int?>("ForemanMagnum")
                        .HasColumnName("foreman_magnum")
                        .HasColumnType("int");

                    b.Property<decimal?>("GeFunctionTotal")
                        .HasColumnName("GE_function_total")
                        .HasColumnType("numeric(8, 4)");

                    b.Property<string>("GenderBodyCol")
                        .HasColumnName("gender_body_col")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("GenderGe")
                        .HasColumnName("gender_GE")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("Gonian")
                        .HasColumnName("gonian")
                        .HasColumnType("int");

                    b.Property<string>("HairColor")
                        .HasColumnName("hair_color")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("HairTaken")
                        .HasColumnName("hair_taken")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("HeadDirection")
                        .HasColumnName("head_direction")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int?>("Humerus")
                        .HasColumnName("humerus")
                        .HasColumnType("int");

                    b.Property<decimal?>("HumerusHead")
                        .HasColumnName("humerus_head")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<decimal?>("HumerusLength")
                        .HasColumnName("humerus_length")
                        .HasColumnType("numeric(4, 1)");

                    b.Property<int?>("IliacCrest")
                        .HasColumnName("iliac_crest")
                        .HasColumnType("int");

                    b.Property<decimal?>("InterorbitalBreadth")
                        .HasColumnName("interorbital_breadth")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<int?>("LengthOfRemains")
                        .HasColumnName("length_of_remains")
                        .HasColumnType("int");

                    b.Property<string>("LinearHypoplasiaEnamel")
                        .HasColumnName("Linear_Hypoplasia_Enamel")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal?>("MaximumCranialBreadth")
                        .HasColumnName("maximum_cranial_breadth")
                        .HasColumnType("numeric(6, 2)");

                    b.Property<decimal?>("MaximumCranialLength")
                        .HasColumnName("maximum_cranial_length")
                        .HasColumnType("numeric(6, 2)");

                    b.Property<decimal?>("MaximumNasalBreadth")
                        .HasColumnName("maximum_nasal_breadth")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<int?>("MedialClavicle")
                        .HasColumnName("medial_clavicle")
                        .HasColumnType("int");

                    b.Property<int?>("MedialIpRamus")
                        .HasColumnName("medial_IP_ramus")
                        .HasColumnType("int");

                    b.Property<string>("MetopicSuture")
                        .HasColumnName("Metopic_Suture")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal?>("NasionProsthion")
                        .HasColumnName("nasion_prosthion")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<int?>("NuchalCrest")
                        .HasColumnName("nuchal_crest")
                        .HasColumnType("int");

                    b.Property<int?>("OrbitEdge")
                        .HasColumnName("orbit_edge")
                        .HasColumnType("int");

                    b.Property<string>("OsteologyUnknownComment")
                        .HasColumnName("Osteology_unknown_comment")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Osteophytosis")
                        .HasColumnName("osteophytosis")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<int?>("ParietalBossing")
                        .HasColumnName("parietal_bossing")
                        .HasColumnType("int");

                    b.Property<string>("PathologyAnomalies")
                        .HasColumnName("pathology_anomalies")
                        .HasColumnType("nvarchar(169)")
                        .HasMaxLength(169);

                    b.Property<string>("PoroticHyperostosisLocation")
                        .HasColumnName("Porotic_Hyperostosis_Location")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("PostcraniaTrauma")
                        .HasColumnName("Postcrania_Trauma")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("PostcraniaTrauma1")
                        .HasColumnName("Postcrania_Trauma_1")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int?>("PreaurSulcus")
                        .HasColumnName("preaur_sulcus")
                        .HasColumnType("int");

                    b.Property<string>("PreservationIndex")
                        .HasColumnName("preservation_index")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<int?>("PubicBone")
                        .HasColumnName("pubic_bone")
                        .HasColumnType("int");

                    b.Property<string>("PubicSymphysis")
                        .HasColumnName("pubic_symphysis")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Rack")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("Robust")
                        .HasColumnName("robust")
                        .HasColumnType("int");

                    b.Property<int?>("SampleNumber")
                        .HasColumnName("sample_number")
                        .HasColumnType("int");

                    b.Property<int?>("SciaticNotch")
                        .HasColumnName("sciatic_notch")
                        .HasColumnType("int");

                    b.Property<string>("Shelf")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SkullTrauma")
                        .HasColumnName("Skull_Trauma")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("SoftTissueTaken")
                        .HasColumnName("soft_tissue_taken")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int?>("SouthToFeet")
                        .HasColumnName("south_to_feet")
                        .HasColumnType("int");

                    b.Property<int?>("SouthToHead")
                        .HasColumnName("south_to_head")
                        .HasColumnType("int");

                    b.Property<int?>("SubpubicAngle")
                        .HasColumnName("subpubic_angle")
                        .HasColumnType("int");

                    b.Property<int?>("SupraorbitalRidges")
                        .HasColumnName("supraorbital_ridges")
                        .HasColumnType("int");

                    b.Property<string>("TemporalMandibularJointOsteoarthritisTmjOa")
                        .HasColumnName("Temporal_Mandibular_Joint_Osteoarthritis_TMJ_OA")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("TextileTaken")
                        .HasColumnName("textile_taken")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<decimal?>("TibiaLength")
                        .HasColumnName("tibia_length")
                        .HasColumnType("numeric(4, 1)");

                    b.Property<string>("ToothAttrition")
                        .HasColumnName("tooth_attrition")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("ToothEruption")
                        .HasColumnName("tooth_eruption")
                        .HasColumnType("nvarchar(42)")
                        .HasMaxLength(42);

                    b.Property<string>("ToothTaken")
                        .HasColumnName("tooth_taken")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("VentralArc")
                        .HasColumnName("ventral_arc")
                        .HasColumnType("int");

                    b.Property<int?>("ZygomaticCrest")
                        .HasColumnName("zygomatic_crest")
                        .HasColumnType("int");

                    b.HasKey("ByufegId");

                    b.HasIndex("BurialId");

                    b.ToTable("Byufeg");
                });

            modelBuilder.Entity("BYU_FEG.Models.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsResearcher")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserPermission");
                });

            modelBuilder.Entity("BYU_FEG.Models.Attachment", b =>
                {
                    b.HasOne("BYU_FEG.Models.Byufeg", "Byufeg")
                        .WithMany("Attachment")
                        .HasForeignKey("ByufegId")
                        .HasConstraintName("FK__Attachmen__Byufe__5CD6CB2B");
                });

            modelBuilder.Entity("BYU_FEG.Models.Byufeg", b =>
                {
                    b.HasOne("BYU_FEG.Models.Burial", "Burial")
                        .WithMany("Byufeg")
                        .HasForeignKey("BurialId")
                        .HasConstraintName("FK__Byufeg__Burial_I__571DF1D5");
                });
#pragma warning restore 612, 618
        }
    }
}
