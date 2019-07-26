using MediatorPatternExemple.Dominio.Cliente.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorPatternExemple.Infraestrutura
{
    /// <summary>
    /// A interface IRepositorioCliente é onde ficam os contratos de acesso a dados (repositório), note que 
    /// utilizei acesso a dados, portanto não necessariamente precisa ser utilizado um banco de dados e a 
    /// classe RepositorioCliente (CustomerRepository) contem as implementações desses contratos.
    /// </summary>
    public interface IRepositorioCliente
    {
        Task Criar(Cliente entidade);
        Task Atualizar(Guid id, Cliente entidade);
        Task Excluir(Guid id);
        Task<Cliente> Selecionar(Guid id);
        Task<IEnumerable<Cliente>> Selecionar();
    }
}
