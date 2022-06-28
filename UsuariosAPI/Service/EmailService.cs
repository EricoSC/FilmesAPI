using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Model;
namespace UsuariosAPI.Service;


public class EmailService
{
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void EnviarEmail(string[] email, string code, string assunto, int iduser)
    {
        Mensagem mensagem = new Mensagem(email, assunto, iduser, code);
        var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
        Enviar(mensagemDeEmail);
    }

    private void Enviar(MimeMessage mensagemDeEmail)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"),true);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),_configuration.GetValue<string>("EmailSettings:Password"));
                //TODO auth email
                client.Send(mensagemDeEmail);
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                client.Disconnect(true);
                client?.Dispose();
            }

        }
    }

    private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
    {
        var mensagemDeEmail = new MimeMessage();
        mensagemDeEmail.From.Add(new MailboxAddress("",_configuration.GetValue<string>("EmailSettings:From")));
        mensagemDeEmail.To.AddRange(mensagem.Destinatario);
        mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = mensagem.Conteudo
        };
        return mensagemDeEmail;
    }
}
