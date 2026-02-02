using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.infra.Messages.Helpers;
using FinancasApp.infra.Messages.Settings;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FinancasApp.infra.Messages.Consumers
{
    /// <summary>
    /// Classe para ler e processar os itens que estão na fila do RabbitMQ
    /// </summary>
    public class RabbitMQConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Instanciar a classe que contem as configurações 
            //para conexão com o RabbitMQ
            var settings = new RabbitMQSettings();

            //conectar na fila do RabbitMQ
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
            {
                HostName = settings.Host,
                Port = settings.Port,
                UserName = settings.User,
                Password = settings.Pass
            };

            //Conectando no servidor da mensageria
            var connection = connectionFactory.CreateConnection();
            //Acessando a fila
            var model = connection.CreateModel();
            model.QueueDeclare(queue: settings.Queue,
                               durable: true,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

            //Criando o consumer (ler os itens da fila)
            var consumer = new EventingBasicConsumer(model);

            //desenvolvendo a rotina de leitura e processamento dos itens da fila
            consumer.Received += (sender, args) =>
            {
                //ler a mensagem contida na fila
                var content = Encoding.UTF8.GetString(args.Body.ToArray());
                //deserealizar os dados em JSON
                var movimentacao = JsonSerializer.Deserialize<MovimentacaoResponseDTO>(content);
                //enviar por email...

                EmailHelper.EnviarExtratoPorEmail(movimentacao);
                //Finalizar o processamento da mensagem na fila
                model.BasicAck(args.DeliveryTag, false);
            };


            //remover cada mensagem processada da fila
            model.BasicConsume(settings.Queue, true, consumer); return Task.CompletedTask;
            

        }
    }
}
