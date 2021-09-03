using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class ThreadProfile : Profile
    {
        //Profile used by automapper to map objects
        public ThreadProfile()
        {
            CreateMap<ThreadCreateDTO, Thread>()
                .ForMember(dest => dest.CategoryFK, opt=> opt.MapFrom(src=> src.Category));
            CreateMap<Thread, ThreadsListDTO>();
            CreateMap<Thread, ThreadReadDTO>();
            CreateMap<Comment, CommentReadDTO>();
            CreateMap<CommentCreateDTO, Comment>();
        }
    }
}
