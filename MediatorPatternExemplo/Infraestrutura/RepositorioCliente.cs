using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorPatternExemple.Dominio.Cliente.Entidades;

namespace MediatorPatternExemple.Infraestrutura
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public List<Cliente> Clientes { get; }

        public RepositorioCliente()
        {
            Clientes = new List<Cliente>();
        }

        public async Task<Cliente> Selecionar(Guid id)
        {
            var cliente = Clientes.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(cliente);
        }

        public async Task<IEnumerable<Cliente>> Selecionar()
        {
            return await Task.FromResult(Clientes);
        }

        public async Task Criar(Cliente entidade)
        {
            await Task.Run(() => Clientes.Add(entidade));
        }

        public async Task Atualizar(Guid id, Cliente entidade)
        {
            int indice = Clientes.FindIndex(x => x.Id == id);
            if (indice >= 0)
                await Task.Run(() => Clientes[indice] = entidade);
        }

        public async Task Excluir(Guid id)
        {
            int indice = Clientes.FindIndex(x => x.Id == id);
            await Task.Run(() => Clientes.RemoveAt(indice));
        }
    }
}
