using AutoMapper;
using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Mapper
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<TaskPostModel, TaskModel>(); //de para

        }
    }
}
