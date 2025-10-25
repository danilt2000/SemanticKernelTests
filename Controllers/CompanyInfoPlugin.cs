using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;

namespace SemanticKernelTests.Controllers;

public class StreamerInfoPlugin
{
    [KernelFunction("get_general_info")]
    [Description("Получает общую информацию о стримере")]
    [return: Description("Объект с общей информацией о стримере")]
    public async Task<GeneralInfoModel> GetGeneralInfoAsync()
    {
        return new GeneralInfoModel
        {
            Name = "Hepatir",
            Description = "Популярный Twitch-стример, создающий развлекательный контент для своей аудитории.",
            TwitchChannel = "https://www.twitch.tv/hepatir",
            Platform = "Twitch",
            ContentType = "Gaming, развлечения, общение с чатом",
            StartYear = 2020 // Укажите реальный год начала стриминга
        };
    }

    [KernelFunction("get_stream_info")]
    [Description("Получает информацию о стримах")]
    [return: Description("Информация о расписании и типах стримов")]
    public async Task<StreamInfo> GetStreamInfoAsync()
    {
        return new StreamInfo
        {
            Schedule = "Регулярные стримы по вечерам",
            AverageStreamDuration = "4-6 часов",
            PopularGames = new List<string>
            {
                "Valorant",
                "CS2",
                "Just Chatting",
                "Variety Games"
            },
            Language = "Русский"
        };
    }

    [KernelFunction("get_community_info")]
    [Description("Получает информацию о сообществе стримера")]
    [return: Description("Информация о сообществе и взаимодействии")]
    public async Task<CommunityInfo> GetCommunityInfoAsync()
    {
        return new CommunityInfo
        {
            CommunityName = "Семья Hepatir",
            Moderators = new List<string>
            {
                "Модератор1",
                "Модератор2",
                "Модератор3"
            },
            SubscriberPerks = new List<string>
            {
                "Уникальные эмоуты",
                "Бейджи подписчика",
                "Приоритет в чате",
                "Доступ к закрытым дискорд-каналам"
            },
            DiscordAvailable = true
        };
    }

    [KernelFunction("get_social_media")]
    [Description("Получает ссылки на социальные сети стримера")]
    [return: Description("Список социальных сетей и ссылок")]
    public async Task<List<SocialMedia>> GetSocialMediaAsync()
    {
        return new List<SocialMedia>
        {
            new SocialMedia { Platform = "Twitch", Url = "https://www.twitch.tv/hepatir" },
            new SocialMedia { Platform = "Discord", Url = "Ссылка на Discord сервер" },
            new SocialMedia { Platform = "VK", Url = "Ссылка на VK" },
            new SocialMedia { Platform = "Telegram", Url = "Ссылка на Telegram канал" }
        };
    }

    [KernelFunction("get_achievements")]
    [Description("Получает достижения стримера")]
    [return: Description("Список достижений")]
    public async Task<List<Achievement>> GetAchievementsAsync()
    {
        return new List<Achievement>
        {
            new Achievement { Date = "2023-06-15", Description = "Достиг 10,000 фолловеров на Twitch" },
            new Achievement { Date = "2023-12-01", Description = "Провел 24-часовой благотворительный стрим" },
            new Achievement { Date = "2024-03-20", Description = "Получил партнерство Twitch" }
        };
    }

    [KernelFunction("get_recent_highlights")]
    [Description("Получает последние яркие моменты со стримов")]
    [return: Description("Список последних хайлайтов")]
    public async Task<List<Highlight>> GetRecentHighlightsAsync()
    {
        return new List<Highlight>
        {
            new Highlight { Date = "2025-01-15", Description = "Эпичная победа в Valorant с камбэком 3-12" },
            new Highlight { Date = "2025-01-10", Description = "Смешной момент с донатом, взорвавший чат" },
            new Highlight { Date = "2025-01-05", Description = "Коллаборация с популярным стримером" }
        };
    }
}

public class GeneralInfoModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("twitch_channel")]
    public string TwitchChannel { get; set; }

    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }

    [JsonPropertyName("start_year")]
    public int StartYear { get; set; }
}

public class StreamInfo
{
    [JsonPropertyName("schedule")]
    public string Schedule { get; set; }

    [JsonPropertyName("average_stream_duration")]
    public string AverageStreamDuration { get; set; }

    [JsonPropertyName("popular_games")]
    public List<string> PopularGames { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }
}

public class CommunityInfo
{
    [JsonPropertyName("community_name")]
    public string CommunityName { get; set; }

    [JsonPropertyName("moderators")]
    public List<string> Moderators { get; set; }

    [JsonPropertyName("subscriber_perks")]
    public List<string> SubscriberPerks { get; set; }

    [JsonPropertyName("discord_available")]
    public bool DiscordAvailable { get; set; }
}

public class SocialMedia
{
    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Achievement
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class Highlight
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}