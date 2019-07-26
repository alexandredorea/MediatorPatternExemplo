﻿using MediatR;
using System;

namespace MediatorPatternExemple.Dominio.Cliente.Comandos
{
    /// <summary>
    /// A classe ClienteComandoCriar (CustomerCreateCommand) é um Objeto de Tranferência de Dados,
    /// ou seja, DTO (Data Transfer Object) que representa a ação que a aplicação deve realizar ao utilizar 
    /// esse objeto.
    /// </summary>
    public class ComandoCriarCliente : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
