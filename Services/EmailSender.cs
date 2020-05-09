using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Services
{
    public class EmailSender
    {
        /*para usar com origem da interface do usuário de identidade completa, 
         * que no caso está com erro de sintaxe em:
         *options.AllowAreas = true;
         *services.AddSingleton<IEmailSender, EmailSender>();
         * Considerar a exclução.         
         */
       /* public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }*/
    }
}
