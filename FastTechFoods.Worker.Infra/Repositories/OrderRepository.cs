using FastTechFoods.Worker.Domain.Entities;
using FastTechFoods.Worker.Domain.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FastTechFoods.Worker.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _order;

        public OrderRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
        {
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.Database);
            _order = database.GetCollection<Order>("Order");
        }

        public Order GetById(Guid id)
        {
            return _order.Find(c => c.Id == id).FirstOrDefault();
        }

        public void RegisterOrder(Order order)
        {
            try
            {

                // Criando um filtro para buscar pelo Id
                var filterId = Builders<Order>.Filter.Eq(c => c.Id, order.Id);

                // Realizando a busca no banco
                var existing_id = _order.Find(filterId).FirstOrDefault();

                if (existing_id == null)
                {
                    _order.InsertOneAsync(order);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao cancelar o pedido. Erro {ex.Message}");
            }

        }
    }
}
