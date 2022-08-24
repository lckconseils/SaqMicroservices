using System;
using System.Threading.Tasks;
using Commande.Application.Models;

namespace Commande.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
