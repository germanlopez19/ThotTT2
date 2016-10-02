namespace TT2Thot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            Preguntas = new HashSet<Pregunta>();
        }

        public int TestID { get; set; }

        [StringLength(128)]
        public string UsuarioID { get; set; }

        public int? TemaID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] FecharRealizacion { get; set; }

        public int? CalificacionID { get; set; }

        public virtual Calificacion Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregunta> Preguntas { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual Tema Tema { get; set; }
    }
}
