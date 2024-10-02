using AutoMapper;
using Backend.Domain.DTOs.Responses;
using Backend.Domain.DTOs.ViewModels;
using Backend.Domain.Entities;

namespace Backend.Domain.DTOs.Helpers
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressRequest>();
            CreateMap<AddressRequest, Address>();
        }
    }
}
