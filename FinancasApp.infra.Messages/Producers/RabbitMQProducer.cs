using FinancasApp.Domain.Interfaces.Messages;
using FinancasApp.infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Infra.Messages.Producers
{
    /// <summary>
    /// Classe para gravar mensagens / dados na fila da mensageria
    /// </summary>
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage(string message)
        {
            //Instanciar a classe que contem as configurações
            //para conexão com o RabbitMQ
            var settings = new RabbitMQSettings();

            //Conectar na fila do RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = settings.Host, //servidor da mensageria
                Port = settings.Port, //porta para conexão
                UserName = settings.User, //usuário para conexão
                Password = settings.Pass //senha de conexão
            };

            //Abrindo conexão com o servidor da mensageria
            using (var connection = connectionFactory.CreateConnection())
            {
                //Acessando a fila
                using (var model = connection.CreateModel())
                {
                    //Criando / conectando na fila
                    model.QueueDeclare(
                            queue: settings.Queue, //Nome da fila
                            durable: true, //Fila não é excluida caso o servidor seja desligado
                            autoDelete: false, //Não remover itens da fila automaticamente
                            exclusive: false, //Fila pode ser acessada por outros producers
                            arguments: null
                        );

                    //Gravar a mensagem na fila
                    model.BasicPublish(
                            exchange: string.Empty, //nenhum intermediário precisa ser definido
                            routingKey: settings.Queue, //nome da fila
                            basicProperties: null,
                            body: Encoding.UTF8.GetBytes(message) //mensagem que será gravada na fila
                        );
                }
            }
        }
    }
}
