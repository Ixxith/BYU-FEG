using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    [Table("BYUFEG")]
    public partial class Byufeg
    {
        [Column("BYUFEGId")]
        [Key]
        [Required]
        public int? Byufegid { get; set; }
        [Column("Burial_ID")]
        [StringLength(26)]
        public string BurialId { get; set; }
        [Column("burial_location_NS")]
        [StringLength(1)]
        public string BurialLocationNs { get; set; }
        [Column("burial_location_EW")]
        [StringLength(1)]
        public string BurialLocationEw { get; set; }
        [Column("low_pair_NS")]
        public int? LowPairNs { get; set; }
        [Column("high_pair_NS")]
        public int? HighPairNs { get; set; }
        [Column("low_pair_EW")]
        public int? LowPairEw { get; set; }
        [Column("high_pair_EW")]
        public int? HighPairEw { get; set; }
        [Column("burial_subplot")]
        [StringLength(2)]
        public string BurialSubplot { get; set; }
        [Column("burial_depth", TypeName = "numeric(4, 1)")]
        public decimal? BurialDepth { get; set; }
        [Column("south_to_head")]
        public int? SouthToHead { get; set; }
        [Column("south_to_feet")]
        public int? SouthToFeet { get; set; }
        [Column("east_to_head")]
        public int? EastToHead { get; set; }
        [Column("east_to_feet")]
        public int? EastToFeet { get; set; }
        [Column("burial_situation")]
        [StringLength(1092)]
        public string BurialSituation { get; set; }
        [Column("length_of_remains")]
        public int? LengthOfRemains { get; set; }
        [Column("burial_number")]
        public int? BurialNumber { get; set; }
        [Column("sample_number")]
        public int? SampleNumber { get; set; }
        [Column("gender_GE")]
        [StringLength(12)]
        public string GenderGe { get; set; }
        [Column("GE_function_total", TypeName = "numeric(7, 4)")]
        public decimal? GeFunctionTotal { get; set; }
        [Column("gender_body_col")]
        [StringLength(12)]
        public string GenderBodyCol { get; set; }
        [Column("basilar_suture")]
        [StringLength(6)]
        public string BasilarSuture { get; set; }
        [Column("ventral_arc")]
        public int? VentralArc { get; set; }
        [Column("subpubic_angle")]
        public int? SubpubicAngle { get; set; }
        [Column("sciatic_notch")]
        public int? SciaticNotch { get; set; }
        [Column("pubic_bone")]
        public int? PubicBone { get; set; }
        [Column("preaur_sulcus")]
        public int? PreaurSulcus { get; set; }
        [Column("medial_IP_ramus")]
        public int? MedialIpRamus { get; set; }
        [Column("dorsal_pitting")]
        public int? DorsalPitting { get; set; }
        [Column("foreman_magnum")]
        public int? ForemanMagnum { get; set; }
        [Column("femur_head", TypeName = "numeric(4, 2)")]
        public decimal? FemurHead { get; set; }
        [Column("humerus_head", TypeName = "numeric(4, 2)")]
        public decimal? HumerusHead { get; set; }
        [Column("osteophytosis")]
        [StringLength(8)]
        public string Osteophytosis { get; set; }
        [Column("pubic_symphysis")]
        [StringLength(2)]
        public string PubicSymphysis { get; set; }
        [Column("bone_length")]
        public int? BoneLength { get; set; }
        [Column("medial_clavicle")]
        public int? MedialClavicle { get; set; }
        [Column("iliac_crest")]
        public int? IliacCrest { get; set; }
        [Column("femur_diameter")]
        public int? FemurDiameter { get; set; }
        [Column("humerus")]
        public int? Humerus { get; set; }
        [Column("femur_length", TypeName = "numeric(3, 1)")]
        public decimal? FemurLength { get; set; }
        [Column("humerus_length", TypeName = "numeric(3, 1)")]
        public decimal? HumerusLength { get; set; }
        [Column("tibia_length", TypeName = "numeric(3, 1)")]
        public decimal? TibiaLength { get; set; }
        [Column("robust")]
        public int? Robust { get; set; }
        [Column("supraorbital_ridges")]
        public int? SupraorbitalRidges { get; set; }
        [Column("orbit_edge")]
        public int? OrbitEdge { get; set; }
        [Column("parietal_bossing")]
        public int? ParietalBossing { get; set; }
        [Column("gonian")]
        public int? Gonian { get; set; }
        [Column("nuchal_crest")]
        public int? NuchalCrest { get; set; }
        [Column("zygomatic_crest")]
        public int? ZygomaticCrest { get; set; }
        [Column("cranial_suture")]
        [StringLength(13)]
        public string CranialSuture { get; set; }
        [Column("maximum_cranial_length", TypeName = "numeric(5, 2)")]
        public decimal? MaximumCranialLength { get; set; }
        [Column("maximum_cranial_breadth", TypeName = "numeric(5, 2)")]
        public decimal? MaximumCranialBreadth { get; set; }
        [Column("basion_bregma_height", TypeName = "numeric(5, 2)")]
        public decimal? BasionBregmaHeight { get; set; }
        [Column("basion_nasion", TypeName = "numeric(5, 2)")]
        public decimal? BasionNasion { get; set; }
        [Column("basion_prosthion_length", TypeName = "numeric(4, 2)")]
        public decimal? BasionProsthionLength { get; set; }
        [Column("bizygomatic_diameter", TypeName = "numeric(5, 2)")]
        public decimal? BizygomaticDiameter { get; set; }
        [Column("nasion_prosthion", TypeName = "numeric(4, 2)")]
        public decimal? NasionProsthion { get; set; }
        [Column("maximum_nasal_breadth", TypeName = "numeric(4, 2)")]
        public decimal? MaximumNasalBreadth { get; set; }
        [Column("interorbital_breadth", TypeName = "numeric(4, 2)")]
        public decimal? InterorbitalBreadth { get; set; }
        [Column("artifacts_description")]
        [StringLength(119)]
        public string ArtifactsDescription { get; set; }
        [Column("hair_color")]
        [StringLength(6)]
        public string HairColor { get; set; }
        [Column("preservation_index")]
        [StringLength(3)]
        public string PreservationIndex { get; set; }
        [Column("hair_taken")]
        [StringLength(5)]
        public string HairTaken { get; set; }
        [Column("soft_tissue_taken")]
        [StringLength(5)]
        public string SoftTissueTaken { get; set; }
        [Column("bone_taken")]
        [StringLength(5)]
        public string BoneTaken { get; set; }
        [Column("tooth_taken")]
        [StringLength(5)]
        public string ToothTaken { get; set; }
        [Column("textile_taken")]
        [StringLength(5)]
        public string TextileTaken { get; set; }
        [Column("description_of_taken")]
        [StringLength(94)]
        public string DescriptionOfTaken { get; set; }
        [Column("artifact_found")]
        [StringLength(5)]
        public string ArtifactFound { get; set; }
        [Column("estimate_age", TypeName = "numeric(3, 1)")]
        public decimal? EstimateAge { get; set; }
        [Column("estimate_living_stature", TypeName = "numeric(6, 3)")]
        public decimal? EstimateLivingStature { get; set; }
        [Column("tooth_attrition")]
        [StringLength(3)]
        public string ToothAttrition { get; set; }
        [Column("tooth_eruption")]
        [StringLength(42)]
        public string ToothEruption { get; set; }
        [Column("pathology_anomalies")]
        [StringLength(169)]
        public string PathologyAnomalies { get; set; }
        [Column("epiphyseal_union")]
        [StringLength(12)]
        public string EpiphysealUnion { get; set; }
        [Column("year_found")]
        public int? YearFound { get; set; }
        [Column("month_found")]
        [StringLength(3)]
        public string MonthFound { get; set; }
        [Column("day_found")]
        public int? DayFound { get; set; }
        [Column("head_direction")]
        [StringLength(4)]
        public string HeadDirection { get; set; }
    }
}
