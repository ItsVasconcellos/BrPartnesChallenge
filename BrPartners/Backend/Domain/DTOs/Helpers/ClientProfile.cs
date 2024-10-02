using AutoMapper;
using Backend.Domain.DTOs.Responses;
using Backend.Domain.DTOs.ViewModels;
using Backend.Domain.Entities; 

namespace Backend.Domain.DTOs.Helpers
{
    public class ClientProfile : Profile  
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientRequest>();
            CreateMap<ClientRequest, Client>();
        }
    }
}
