namespace WebApplication9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bairro")]
    public partial class Bairro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bairro()
        {
            Endereco = new HashSet<Endereco>();
        }

        [Key]
        public int codigo { get; set; }

        [StringLength(250)]
        public string descricao { get; set; }

        public int? codigo_cidade { get; set; }

        public virtual Cidade Cidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
