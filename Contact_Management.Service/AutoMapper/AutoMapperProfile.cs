using AutoMapper;
using Contact_Management.DTOs;
using Contact_Management.DTOS;
using Contact_Management.Models;

namespace Contact_Management.Service;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Contact, ContactDTO>().ReverseMap();
        CreateMap<Contact, RegisterDTO>().ReverseMap();
    }
}