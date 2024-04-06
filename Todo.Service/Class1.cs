using TodoList.Domain.Interface;
using TodoList.Models;

namespace Todo.Service;

public class TodoService(ITodoRepository repository, ICategoryRepository categoryRepository) : ITodoService 
{
    public async Task<bool> Delete(int id)
    {
        repository.Remove(id);
        await repository.SaveChangeAsync(default);
        return true;
    }

    public async Task<bool> MarkAsDone(int id)
    {
        var todo = await repository.GetByIdAsync(id);
        todo.StatusId = "1";
        repository.Update(todo);
        await repository.SaveChangeAsync(default);

        return true;
    }

    public Interface ITodoService
    {
        Task<bool> Delete(int id);
        Task<bool> MarkAsDone(int id);
    }
}