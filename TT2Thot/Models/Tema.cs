namespace TT2Thot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tema")]
    public partial class Tema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tema()
        {
            Tests = new HashSet<Test>();
        }

        public int TemaID { get; set; }

        [StringLength(50)]
        public string Numero { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        public int? UnidadID { get; set; }

        public string Contenido { get; set; }

        [StringLength(200)]
        public string Bibliografia { get; set; }

        public virtual Unidad Unidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests { get; set; }
    }
}
