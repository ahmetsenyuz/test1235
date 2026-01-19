using System.Text.Json.Serialization;

namespace BacklogApp.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}