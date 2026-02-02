using FinancasApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FinancasApp.infra.Messages.Helpers
{
    public class EmailHelper
    {
        public static void EnviarExtratoPorEmail(MovimentacaoResponseDTO movimentacao)
        {
            var culture = new CultureInfo("pt-BR");
            var corValor = movimentacao.Tipo.Equals("Receita",
            StringComparison.OrdinalIgnoreCase) ? "green" : "red";

            var html = new StringBuilder();

            html.Append($@"
            <html>
            <body style='font-family: Arial, Helvetica, sans-serif; color:#333;'>
            <h2 style='color:#2c3e50;'>Extrato de Movimentação</h2>
            <table style='border-collapse:collapse; width:100%;'> 
             
         <tr>
            <th style='border:1px solid #ddd; padding:10px;background-color:#f4f4f4;text-align:left;'>
            Data
            </th>
            
            <td style='border:1px solid #ddd;padding:10px;'>
            {{movimentacao.Data:dd/MM/yyyy}}
            </td>

        </tr>

         <tr> 
<th style='border:1px solid #ddd; padding:10px; background-color:#f4f4f4;
text- align:left;'>Descrição</th>
<td style='border:1px solid #ddd; padding:10px;'>{{movimentacao.Nome}}</td> 
</tr>
<tr> 
<th style='border:1px solid #ddd; padding:10px; background-color:#f4f4f4; text-align:left;'>Tipo</th>
<td style='border:1px solid #ddd; padding:10px;'>{{movimentacao.Tipo}}</td> 
</tr>
<tr>
<th style='border:1px solid #ddd; padding:10px; background-color:#f4f4f4; text- align:left;'>Valor</th> 
<td style='border:1px solid #ddd; padding:10px; font-weight:bold; color:{{corValor}};'> {{movimentacao.Valor.ToString(""C"", culture)}} </td>
</tr>
</table>
<p style='margin-top:20px; font-size:12px; color:#777;'> Este e-mail foi gerado automaticamente pelo sistema FinancasApp. </p>
</body>
</html> 
");

            var mailMessage = new MailMessage
            { 
               From = new MailAddress("no-reply@financasapp.com"),
               Subject = "Extrato de Movimentação Financeira realizada em: "
               + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Body = html.ToString(), IsBodyHtml = true
            };

            mailMessage.To.Add("contato@cotiinformatica.com.br"); 
            var smtpClient = new SmtpClient 
            { 
                Host = "localhost", 
                Port = 1025, 
                EnableSsl = false, 
                Credentials = CredentialCache.DefaultNetworkCredentials 
            };

            smtpClient.Send(mailMessage);

        }
    }
}