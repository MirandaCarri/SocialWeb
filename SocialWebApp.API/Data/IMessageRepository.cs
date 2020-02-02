using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWebApp.API.Helpers;
using SocialWebApp.API.Models;

namespace SocialWebApp.API.Data
{
    public interface IMessageRepository
    {
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}