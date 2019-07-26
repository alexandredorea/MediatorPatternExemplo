using MediatR;

namespace MediatorPatternExemple.Notificacoes
{
    /// <summary>
    /// A Classe AcaoNotificacaoCliente (CustomerActionEvent) representa um DTO (Data Transfer Object) que contêm 
    /// informações sobre o registro persistido na base de dados, portanto quando uma ação de persistência é 
    /// executada com sucesso, esse objeto é preenchido e passado para as classes que estão esperando por esse 
    /// objeto.
    /// </summary>
    public class AcaoNotificacaoCliente : INotification
    {
        //public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        //public string Telefone { get; set; }
        public AcaoNotificacao Acao { get; set; }
    }
}
