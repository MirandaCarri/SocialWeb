using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWebApp.API.Helpers;
using SocialWebApp.API.Models;

namespace SocialWebApp.API.Data
{
    public interface IMainRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         Task<Message> GetMessage(int id);
         Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
         Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);

    }
}