using FastTechFoods.Worker.Application.Dtos;

namespace FastTechFoods.Worker.Application.Interfaces;

public interface IOrderAppService
{
     Task UpdateOrder(ChangeStatusDto dto);
}