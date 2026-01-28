using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.infra.Messages.Settings
{
    /// <summary>
    /// Classe para configurar os parametros de conexao com o RabbitMQ
    /// </summary>

    public class RabbitMQSettings
    {
        public string Host { get; set; } = "localhost";

        // porta padrão do RabbitMQ que está no docker-compose
        public int Port { get; set; } = 5672;

        //usuario padrao do rabbitmq
        public string User { get; set; } = "guest";

        //senha padrao do rabbitmq
        public string Pass { get; set; } = "guest";

        // nome da fila para onde as mensagens serão enviadas
        public string Queue { get; set; } = "movimentacoes";

    }
}
