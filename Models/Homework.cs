using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet6_webapi.Models;

public class Homework
{
    //[Key]
    public Guid HomeworkId { get; set; }
    //[ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    //[Required]
    //[MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority PriorityHomework { get; set; }
    public DateTime CreationDate { get; set; }    
    public virtual Category Category { get; set; }
    //[NotMapped] //mapping ignore
    public string Summary { get; set; }
}

public enum Priority{
    Low,
    Mid,
    High
}