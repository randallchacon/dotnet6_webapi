using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet6_webapi.Models;

public class Category
{
    //[Key] //primary key
    public Guid CategoryId { get; set; }
    //[Required]
    //[MaxLength(150)] //
    public string Name { get; set; }
    public string Description { get; set; }
    public int Effort { get; set; }
    [JsonIgnore]
    public virtual ICollection<Homework> Homeworks { get; set; } //get all category homeworks 
}