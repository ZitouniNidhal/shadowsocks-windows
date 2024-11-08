using System;
using System.IO.Pipelines;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Shadowsocks.Protocol
{
    /// <summary>
    /// Interface représentant un client capable de se connecter à un endpoint spécifié
    /// et de gérer la communication entre un client et un serveur via des pipes duplex.
    /// </summary>
    public interface IStreamClient
    {
        /// <summary>
        /// Se connecte à la destination spécifiée et gère la communication entre le client et le serveur.
        /// </summary>
        /// <param name="destination">Le endpoint de destination.</param>
        /// <param name="client">Le pipe duplex côté client.</param>
        /// <param name="server">Le pipe duplex côté serveur.</param>
        /// <param name="cancellationToken">Token pour supporter l'annulation des tâches.</param>
        /// <returns>Une tâche représentant l'opération de connexion asynchrone.</returns>
        Task ConnectAsync(EndPoint destination, IDuplexPipe client, IDuplexPipe server, CancellationToken cancellationToken = default);

        /// <summary>
        /// Se déconnecte de la connexion actuelle et libère les ressources associées.
        /// </summary>
        /// <returns>Une tâche représentant l'opération de déconnexion asynchrone.</returns>
        Task DisconnectAsync();

        /// <summary>
        /// Indique si le client est actuellement connecté.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Récupère le temps total de connexion en secondes.
        /// </summary>
        TimeSpan ConnectionDuration { get; }

        /// <summary>
        /// Journalise les événements et les erreurs liés aux connexions.
        /// </summary>
        /// <param name="message">Le message à journaliser.</param>
        /// <param name="exception">L'exception associée (facultatif).</param>
        void Log(string message, Exception? exception = null);

        /// <summary>
        /// Gère les exceptions spécifiques à la connexion.
        /// </summary>
        /// <param name="exception">L'exception à gérer.</param>
        void HandleConnectionException(Exception exception);
    }
}
