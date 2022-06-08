using Microsoft.EntityFrameworkCore;
using dotnet6_webapi.Models;

namespace dotnet6_webapi;

public class HomeworksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Homework> Homeworks { get; set; } //collection must be plural

    public HomeworksContext(DbContextOptions<HomeworksContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Instead Data Annotations
    {
        List<Category> categoryList = new List<Category>();
        categoryList.Add(new Category() { CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), Name = "Pending activities", Effort = 20});
        categoryList.Add(new Category() { CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), Name = "Personal activities", Effort = 50});

        modelBuilder.Entity<Category>(cat =>{
            cat.ToTable("Category");
            cat.HasKey(p => p.CategoryId);
            cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
            cat.Property(p => p.Description).IsRequired(false);
            cat.Property(p => p.Effort);
            cat.HasData(categoryList);
        });

        List<Homework> homeworkList = new List<Homework>();
        homeworkList.Add(new Homework() {HomeworkId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"), 
                                        CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),
                                        PriorityHomework = Priority.Mid,
                                        Title = "Payment of public services",
                                        CreationDate = DateTime.Now});
        homeworkList.Add(new Homework() {HomeworkId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"), 
                                        CategoryId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),
                                        PriorityHomework = Priority.Low,
                                        Title = "Finish watching movie",
                                        CreationDate = DateTime.Now});                                        

        modelBuilder.Entity<Homework>(h => {
            h.ToTable("Homework");
            h.HasKey(p => p.HomeworkId);
            h.HasOne(p=> p.Category).WithMany(p => p.Homeworks).HasForeignKey(p => p.CategoryId);
            h.Property(p => p.Title).IsRequired().HasMaxLength(200);
            h.Property(p => p.Description).IsRequired(false);
            h.Property(p => p.PriorityHomework);
            h.Property(p => p.CreationDate);       
            h.Ignore(p => p.Summary);    
            h.HasData(homeworkList);
        });
    }
}