namespace WebApplication9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Endereco = new HashSet<Endereco>();
           
        }

        [Key]
        public int codigo { get; set; }

        [StringLength(250)]
        public string nome { get; set; }


        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? data_nascimento { get; set; }

        [StringLength(50)]
        public string sexo { get; set; }

        [StringLength(200)]
        public string profissao { get; set; }

        [StringLength(50)]
        public string nacionalidade { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [StringLength(200)]
        public string pai { get; set; }

        [StringLength(200)]
        public string mae { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? data_cadastro { get; set; }

        public int? tipo_pessoa { get; set; }

        [StringLength(100)]

        public string cpf { get; set; }

        [StringLength(100)]

        public string cnpj { get; set; }

        public int? codigo_tipo_cadastro { get; set; }

        [StringLength(50)]
        public string numero_oab { get; set; }

        public int? codigo_posicao_parte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Endereco { get; set; }

        public virtual Posicao Posicao { get; set; }

        public virtual TipoCadastro TipoCadastro { get; set; }
    }
}
