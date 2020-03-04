using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class UsuarioInsertViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        
        public Permissao Permissao { get; set; }
    }
}