using System.Text.Json.Serialization;

namespace BacklogApp.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }
}