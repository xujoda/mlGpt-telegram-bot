using Telegram.Bot.Types;
using Telegram.Bot;

namespace mlg_bot
{
    public class TelegramService
    {
        private TelegramBotClient _botClient;

        public TelegramService(string apiToken)
        {
            _botClient = new TelegramBotClient(apiToken);
        }

        public async Task SendMessageAsync(long chatId, string text)
        {
            await _botClient.SendTextMessageAsync(chatId, text);
        }

        public async Task<Update[]> GetUpdatesAsync()
        {
            return await _botClient.GetUpdatesAsync(-1);
        }

        public async Task DeleteChatHistoryAsync(long chatId)
        {
            await _botClient.LeaveChatAsync(chatId);
        }
    }
}
