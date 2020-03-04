﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    class UsuarioMapConfig : EntityTypeConfiguration<UsuarioDTO>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIOS");


            this.Property(c => c.Email).HasMaxLength(60);

            this.HasIndex(c => c.Email)
                .IsUnique();

            this.Property(c => c.Nome)
                .HasMaxLength(50);

            this.Property(c => c.Senha)
                .HasMaxLength(30);
        }

    }
}
