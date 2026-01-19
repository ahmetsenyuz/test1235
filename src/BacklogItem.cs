using System;
using System.Text.Json.Serialization;

namespace BacklogApp.Models
{
    public class BacklogItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        
        [JsonPropertyName("status")]
        public Status Status { get; set; } = Status.ToDo;
        
        [JsonPropertyName("priority")]
        public Priority Priority { get; set; } = Priority.Medium;
        
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}