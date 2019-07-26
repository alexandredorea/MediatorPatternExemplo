using MediatorPatternExemple.Dominio.Cliente.Comandos;
using MediatorPatternExemple.Infraestrutura;
using MediatorPatternExemple.Notificacoes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternExemple.Dominio.Cliente.Manipuladoras
{
    /// <summary>
    /// A classe ManipuladorCliente (CustomerHandler) tem a responsabilidade de coordenar as ações necessária 
    /// para persistir a entidade no banco de dados, ou seja, é aqui onde fica a implementação do fluxo de dados, 
    /// validações entre outros.
    /// </summary>
    public class ManipuladorCliente :
        IRequestHandler<ComandoCriarCliente, string>,
        IRequestHandler<ComandoAtualizarCliente, string>,
        IRequestHandler<ComandoExcluirCliente, string>
    {
        private readonly IMediator mediator;
        private readonly IRepositorioCliente repositorioCliente;

        public ManipuladorCliente(IMediator mediator, IRepositorioCliente repositorioCliente)
        {
            this.mediator = mediator;
            this.repositorioCliente = repositorioCliente;
        }

        public async Task<string> Handle(ComandoCriarCliente request, CancellationToken cancellationToken)
        {
            var cliente = new Entidades.Cliente(request.Id, request.Nome, request.Email, request.Telefone);
            await repositorioCliente.Criar(cliente);
            await PublicarNotificacao(cliente, cancellationToken, AcaoNotificacao.Criado);

            return await Task.FromResult("Cliente criado com sucesso");
        }

        public async Task<string> Handle(ComandoAtualizarCliente request, CancellationToken cancellationToken)
        {
            var cliente = new Entidades.Cliente(request.Id, request.Nome, request.Email, request.Telefone);
            await repositorioCliente.Atualizar(request.Id, cliente);
            await PublicarNotificacao(cliente, cancellationToken, AcaoNotificacao.Atualizado);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(ComandoExcluirCliente request, CancellationToken cancellationToken)
        {
            var cliente = await repositorioCliente.Selecionar(request.Id);
            await repositorioCliente.Excluir(cliente.Id);
            await PublicarNotificacao(cliente, cancellationToken, AcaoNotificacao.Excluido);

            return await Task.FromResult("Cliente excluido com sucesso");
        }

        /// <summary>
        /// Método responsavél por publicar uma notificação em todo sistema (Publish), onde ele vai procurar a classe 
        /// que possui a herança da interface INotificationHandler<tipo do objeto> e invocar o método Handler() 
        /// para processar aquela notificação; neste caso só há uma que é a ManipuladorEmail, que herda de 
        /// INotificationHandler<AcaoNotificacaoCliente>
        /// </summary>
        /// <param name="cliente">entidade</param>
        /// <param name="cancellationToken"></param>
        /// <param name="acao">ação</param>
        /// <returns></returns>
        private async Task PublicarNotificacao(Entidades.Cliente cliente, CancellationToken cancellationToken, AcaoNotificacao acao)
        {
            await mediator.Publish(new AcaoNotificacaoCliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Acao = acao
            }, cancellationToken);
        }
    }
}
