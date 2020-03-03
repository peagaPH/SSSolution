using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebPresentationLayer.Models
{
    public class CategoriaInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(maximumLength: 70,ErrorMessage = "O nome deve ter entre 2 e 70 caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
    }
}