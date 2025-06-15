using FastTechFoods.Worker.Domain.Enums;

namespace FastTechFoods.Worker.Application.Dtos;

#nullable disable
public class ItemDto
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }
    public string Notes { get; set; }
}
#nullable restore