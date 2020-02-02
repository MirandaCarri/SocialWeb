using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialWebApp.API.Helpers;
using SocialWebApp.API.Models;

namespace SocialWebApp.API.Data
{
    public class MessageRepository : IMessageRepository
    {

        private readonly DataContext _context;
        public MessageRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages
                .Include(u => u.Sender).ThenInclude(p =>p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .AsQueryable();

            switch(messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId);
                    break;
                    case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId);
                    break;
                    default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Message>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }
    public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
            {
                var messages = await _context.Messages
                    .Include(u => u.Sender).ThenInclude(p =>p.Photos)
                    .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                    .Where(m => m.RecipientId == userId && m.SenderId == recipientId || m.RecipientId == recipientId && m.SenderId == userId)
                            .OrderByDescending(m => m.MessageSent)
                            .ToListAsync();

                return messages;
            }
        }
}