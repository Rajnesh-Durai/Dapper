using AutoMapper;
using SampleProject.Application.Features.OrderDetail.Command;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Models;

namespace SampleProject.Application.Mapper
{
    public class OrderItemsMappingProfile : Profile
    {
        public OrderItemsMappingProfile()
        {
            CreateMap<OrderItems, OrderItemsResponse>().ReverseMap();
            CreateMap<OrderItems, CheckoutOrderItemsCommand>().ReverseMap();
            CreateMap<OrderItems, UpdateOrderItemsCommand>().ReverseMap();
        }
    }
}
