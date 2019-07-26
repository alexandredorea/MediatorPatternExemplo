using MediatorPatternExemple.Notificacoes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternExemple.EventsHandlers
{
    /// <summary>
    /// A classe ManipuladorEmail (EmailHandler) é a classe responsável por receber a notificação do registro de um novo 
    /// cliente e executar o fluxo de envio do email.
    /// </summary>
    public class ManipuladorEmail : INotificationHandler<AcaoNotificacaoCliente>
    {
        /// <summary>
        /// Médoto Handler é responsável por receber a notificação e executar a lógica de envio do email. 
        /// Nesse caso, será exibido apenas uma mensagem de console para facilitar o entendimento.
        /// </summary>
        /// <param name="notificacaoCliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(AcaoNotificacaoCliente notificacaoCliente, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"O cliente {notificacaoCliente.Nome} foi {notificacaoCliente.Acao.ToString().ToLower()} com sucesso");
            });
        }
    }
}
