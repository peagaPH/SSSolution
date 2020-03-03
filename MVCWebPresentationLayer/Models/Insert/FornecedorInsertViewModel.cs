using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class FornecedorInsertViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage ="O nome deve ser informado")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "O nome deve conter 3 e 100 caracteres")]
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public Endereco Endereco { get; set; }
    }
}