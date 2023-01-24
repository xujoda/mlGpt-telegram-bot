using OpenAI_API;
using Telegram.Bot.Types;
//string apiTelegram = "5967585356:AAFvzXv1wZnpyYaAs03yKplYNrvxUJZIt5c";
//string apiGpt = "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";
namespace mlg_bot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiTelegram = "token";
            string apiGpt = "apikey";
            var telegramService = new TelegramService(apiTelegram);
            var openAiClient = new OpenAIAPI(apiGpt);
            while (true)
            {
                var updates = await telegramService.GetUpdatesAsync();
                foreach (var update in updates)
                {
                    if (update.Message != null)
                    {
                        await Task.Delay(2000);
                        var response = await openAiClient.Completions.CreateCompletionAsync(
                        model: "text-davinci-003",
                        prompt: update.Message.Text,
                        temperature: 0.9,
                        max_tokens: 250,
                        top_p: 1,
                        frequencyPenalty: 0.0,
                        presencePenalty: 0.0,
                        stopSequences: new string[] { "\n" }
                        );
                        var responseText = response.Completions[0].Text;
                        if (!string.IsNullOrEmpty(responseText))
                            await telegramService.SendMessageAsync(update.Message.Chat.Id, responseText);
                    }
                }
            }
        }
    }
}