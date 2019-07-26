using System;

namespace MediatorPatternExemple.Dominio.Cliente.Entidades
{
    /// <summary>
    /// A Classe Cliente representa uma entidade do domínio Cliente, 
    /// portanto ela possui estado, comportamento e suas regras de negócio (métodos).
    /// </summary>
    public class Cliente
    {
        public Cliente(Guid id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}
