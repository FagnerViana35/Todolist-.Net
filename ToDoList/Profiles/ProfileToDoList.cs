using AutoMapper;
using ToDoList.Data.Dtos.DtoListaTarefa;
using ToDoList.Data.Dtos.DtoUser;
using ToDoList.Models;

namespace ToDoList.Profiles
{
    public class ProfileToDoList : Profile
    {
        public ProfileToDoList() 
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, ReadUserDto>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<CreateListaTarefaDto, ListaTarefa>();
            CreateMap<UpdateListaTarefaDto, ListaTarefa>();
            CreateMap<ListaTarefa, ReadListaTarefaDto>();
            CreateMap<UpdateListaTarefaDto, ListaTarefa>();

        }
    }
}
