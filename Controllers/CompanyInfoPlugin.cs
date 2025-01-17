using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel;

namespace SemanticKernelTests.Controllers;

public class CompanyInfoPlugin
{
        [KernelFunction("get_general_info")]
        [Description("Gets general information about the company")]
        [return: Description("An object containing general company details")]
        public async Task<GeneralInfoModel> GetGeneralInfoAsync()
        {
                return new GeneralInfoModel
                {
                        Name = "ElysiumCasino",
                        Description = "A top-tier project aiming to revolutionize the industry with quality and innovation.",
                        Founders = new List<string> { "Hepatica", "Rafaello", "Gobnik" },
                        EstablishedYear = 2024,
                        Mission = "To create a product that generates income and improves career opportunities for its team members."
                };
        }

        [KernelFunction("get_team_members")]
        [Description("Gets information about the team members")]
        [return: Description("A list of team members with their roles and responsibilities")]
        public async Task<List<TeamMember>> GetTeamMembersAsync()
        {
                return new List<TeamMember>
        {
            new TeamMember { Role = "Backend", Name = "Rafaello", Responsibilities = "Develops and maintains backend services." },
            new TeamMember { Role = "Scrum Master", Name = "Hepatica", Responsibilities = "Oversees the Scrum process and facilitates team collaboration." },
            new TeamMember { Role = "Frontend", Name = "Madara", Responsibilities = "Designs and implements the user interface." },
            new TeamMember { Role = "Designer", Name = "Mayzito", Responsibilities = "Creates designs and ensures visual consistency." },
            new TeamMember { Role = "PR & Marketing", Name = "Gobnik", Responsibilities = "Manages public relations and marketing campaigns." },
            new TeamMember { Role = "Tester", Name = "BogyBuda", Responsibilities = "Ensures software quality through testing." },
            new TeamMember { Role = "Tech Support", Name = "Gedpool", Responsibilities = "Provides technical support and troubleshooting." }
        };
        }

        [KernelFunction("get_core_values")]
        [Description("Gets the core values of the company")]
        [return: Description("A list of core values")]
        public async Task<List<string>> GetCoreValuesAsync()
        {
                return new List<string>
        {
            "Innovation",
            "Quality",
            "Teamwork",
            "Integrity"
        };
        }

        [KernelFunction("get_current_projects")]
        [Description("Gets the list of current projects")]
        [return: Description("A list of current projects")]
        public async Task<List<string>> GetCurrentProjectsAsync()
        {
                return new List<string>
        {
            "Elysium Platform",
            "Lucky Diamond Real Life Extension",
            "Marketing Outreach Campaign 2025"
        };
        }

        [KernelFunction("get_news")]
        [Description("Gets the latest news about the company")]
        [return: Description("A list of news items")]
        public async Task<List<NewsItem>> GetNewsAsync()
        {
                return new List<NewsItem>
        {
            new NewsItem { Date = "2024-12-16", Content = "We have a new designer, Fuper, as Bobrito departs." },
            new NewsItem { Date = "2024-12-25", Content = "Skutls steps down as frontend lead, and Hepatica temporarily fills the role." },
            new NewsItem { Date = "2025-01-09", Content = "Madara joins as the new frontend lead, with Hepatica transitioning to a full-stack support role." }
        };
        }
}

public class GeneralInfoModel
{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("founders")]
        public List<string> Founders { get; set; }

        [JsonPropertyName("established_year")]
        public int EstablishedYear { get; set; }

        [JsonPropertyName("mission")]
        public string Mission { get; set; }
}

public class TeamMember
{
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("responsibilities")]
        public string Responsibilities { get; set; }
}

public class NewsItem
{
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
}
