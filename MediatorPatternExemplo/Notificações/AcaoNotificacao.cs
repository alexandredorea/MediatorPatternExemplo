namespace MediatorPatternExemple.Notificacoes
{
    /// <summary>
    /// AcaoNotificacao (ActionNotification) é uma enum que representa a ação daquela notificação, como por exemplo: 
    /// Salvar, Atualizar e Excluir. Este enum representa a ação que o cliente sofreu naquela requisição.
    /// </summary>
    public enum AcaoNotificacao
    {
        Criado = 1,
        Atualizado = 2,
        Excluido = 3
    }
}
