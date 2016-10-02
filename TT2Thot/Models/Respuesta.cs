namespace TT2Thot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Respuesta")]
    public partial class Respuesta
    {
        public int RespuestaID { get; set; }

        public int? PreguntaID { get; set; }

        [Column("Respuesta")]
        public string Respuesta1 { get; set; }

        public bool? IsCorrect { get; set; }

        public virtual Pregunta Pregunta { get; set; }
    }
}
