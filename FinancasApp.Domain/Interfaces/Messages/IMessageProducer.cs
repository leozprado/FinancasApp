using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para definir o padrão de métodos que 
    /// irá gravar mensagens na fila do RabbitMQ
    /// </summary>
    public interface IMessageProducer
    {
        void SendMessage(string message);
    }
}
