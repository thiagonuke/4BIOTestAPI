﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public Contatos Contatos { get; set; } 
        public Enderecos Enderecos { get; set; }

        public Cliente() 
        { 
            Contatos = new Contatos();
            Enderecos = new Enderecos();

        }

    }
}
