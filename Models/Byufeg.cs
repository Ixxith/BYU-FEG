using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BYU_FEG.Models
{
    public partial class Byufeg
    {
        public Byufeg()
        {
            Attachment = new HashSet<Attachment>();
        }

        [Key]
        public int ByufegId { get; set; }
        [Column("Burial_ID")]
        public int? BurialId { get; set; }
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
        [StringLength(1500)]
        public string BurialSituation { get; set; }
        [Column("length_of_remains")]
        public int? LengthOfRemains { get; set; }
        [Column("burial_number")]
        public int? BurialNumber { get; set; }
        [Column("sample_number")]
        public int? SampleNumber { get; set; }
        [Column("gender_GE")]
        [StringLength(20)]
        public string GenderGe { get; set; }
        [Column("GE_function_total", TypeName = "numeric(8, 4)")] //CHANGE***************** 7
        public decimal? GeFunctionTotal { get; set; }
        [Column("gender_body_col")]
        [StringLength(20)]
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
        [Column("femur_head", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
        public decimal? FemurHead { get; set; }
        [Column("humerus_head", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
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
        [Column("femur_length", TypeName = "numeric(4, 1)")]  //CHANGE***************** 3
        public decimal? FemurLength { get; set; }
        [Column("humerus_length", TypeName = "numeric(4, 1)")]  //CHANGE***************** 3
        public decimal? HumerusLength { get; set; }
        [Column("tibia_length", TypeName = "numeric(4, 1)")]  //CHANGE***************** 3
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
        [Column("maximum_cranial_length", TypeName = "numeric(6, 2)")]  //CHANGE***************** 5
        public decimal? MaximumCranialLength { get; set; }
        [Column("maximum_cranial_breadth", TypeName = "numeric(6, 2)")]  //CHANGE***************** 5
        public decimal? MaximumCranialBreadth { get; set; }
        [Column("basion_bregma_height", TypeName = "numeric(6, 2)")]  //CHANGE***************** 5
        public decimal? BasionBregmaHeight { get; set; }
        [Column("basion_nasion", TypeName = "numeric(6, 2)")]  //CHANGE***************** 5
        public decimal? BasionNasion { get; set; }
        [Column("basion_prosthion_length", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
        public decimal? BasionProsthionLength { get; set; }
        [Column("bizygomatic_diameter", TypeName = "numeric(6, 2)")]  //CHANGE*****************  5
        public decimal? BizygomaticDiameter { get; set; }
        [Column("nasion_prosthion", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
        public decimal? NasionProsthion { get; set; }
        [Column("maximum_nasal_breadth", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
        public decimal? MaximumNasalBreadth { get; set; }
        [Column("interorbital_breadth", TypeName = "numeric(5, 2)")]  //CHANGE***************** 4
        public decimal? InterorbitalBreadth { get; set; }
        [Column("artifacts_description")]
        [StringLength(200)]
        public string ArtifactsDescription { get; set; }
        [Column("hair_color")]
        [StringLength(10)]
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
        [StringLength(200)]
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
        [StringLength(5)]
        public string HeadDirection { get; set; }
        [Column("date_found")]
        [StringLength(19)]
        public string DateFound { get; set; }
        public int? ActivityId { get; set; }
        [StringLength(30)]
        public string Rack { get; set; }
        [StringLength(30)]
        public string Shelf { get; set; }
        [Column("Skull_Trauma")]
        [StringLength(5)]
        public string SkullTrauma { get; set; }
        [Column("Postcrania_Trauma")]
        [StringLength(5)]
        public string PostcraniaTrauma { get; set; }
        [Column("Cribra_Orbitala")]
        [StringLength(5)]
        public string CribraOrbitala { get; set; }
        [Column("Porotic_Hyperostosis_Location")]
        [StringLength(5)]
        public string PoroticHyperostosisLocation { get; set; }
        [Column("Metopic_Suture")]
        [StringLength(5)]
        public string MetopicSuture { get; set; }
        [Column("Button_Osteoma")]
        [StringLength(5)]
        public string ButtonOsteoma { get; set; }
        [Column("Postcrania_Trauma_1")]
        [StringLength(5)]
        public string PostcraniaTrauma1 { get; set; }
        [Column("Osteology_unknown_comment")]
        [StringLength(5)]
        public string OsteologyUnknownComment { get; set; }
        [Column("Temporal_Mandibular_Joint_Osteoarthritis_TMJ_OA")]
        [StringLength(5)]
        public string TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
        [Column("Linear_Hypoplasia_Enamel")]
        [StringLength(5)]
        public string LinearHypoplasiaEnamel { get; set; }

        [ForeignKey(nameof(ActivityId))]
        [InverseProperty("Byufeg")]
        public virtual Activity Activity { get; set; }
        [ForeignKey(nameof(BurialId))]
        [InverseProperty("Byufeg")]
        public virtual Burial Burial { get; set; }
        [InverseProperty("Byufeg")]
        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
