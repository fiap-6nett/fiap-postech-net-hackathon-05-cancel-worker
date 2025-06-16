using FastTechFoods.Worker.Domain.Enums;

namespace FastTechFoods.Worker.Application.Dtos
{
    public class ChangeStatusDto
    {
        public Guid OrderId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Justification { get; set; }
    }
}