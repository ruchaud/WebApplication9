namespace WebApplication9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Endereco")]
    public partial class Endereco
    {
        [Key]
        public int codigo { get; set; }

        [StringLength(250)]
        public string rua { get; set; }

        [StringLength(50)]
        public string numero { get; set; }

        [StringLength(50)]
        public string cep { get; set; }

        [StringLength(250)]
        public string complemento { get; set; }

        [StringLength(100)]
        public string telefone_residencial { get; set; }

        [StringLength(100)]
        public string telefone_celular { get; set; }

        [StringLength(50)]
        public string tipo_endereco { get; set; }

        public int? codigo_bairro { get; set; }

        public int? codigo_pessoa { get; set; }

        public int? codigo_cidade { get; set; }

        public int? codigo_estado { get; set; }

        public virtual Bairro Bairro { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
