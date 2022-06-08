using efcore_project;
using efcore_project.Models;

public class HomeworksService : IHomeworksService
{
    HomeworksContext context;

    public HomeworksService(HomeworksContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Homework> Get()
    {
        return context.Homeworks;
    }
    public async Task Save(Homework homework)
    {
        context.Add(homework);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Homework homework)
    {
        var currentHomework = context.Homeworks.Find(id);
        if(currentHomework != null){
            currentHomework.Description = homework.Description;
            currentHomework.Title = homework.Title;
            currentHomework.PriorityHomework = homework.PriorityHomework;
            currentHomework.Summary = homework.Summary;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var currentHomework = context.Homeworks.Find(id);

        if(currentHomework != null)
        {
            context.Remove(currentHomework);
            await context.SaveChangesAsync();
        }
    }        
}

public interface IHomeworksService{
    IEnumerable<Homework> Get();
    Task Save(Homework homework);
    Task Update(Guid id, Homework homework);
    Task Delete(Guid id);
}