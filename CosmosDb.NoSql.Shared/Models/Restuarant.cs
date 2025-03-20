using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CosmosDb.NoSql.Shared.Models;

public record Restuarant
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string CuisineType { get; set; } = string.Empty;

    public Uri? Website { get; set; }

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public Location Address { get; set; } = new Location();
}
