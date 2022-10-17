
namespace Fridge.API.Tests
{
    static class GetTestItems
    {
        public static IEnumerable<Entities.Models.Fridge> Fridges
        {
            get
            {
                return new List<Entities.Models.Fridge>()
                {
                    new Entities.Models.Fridge
                    {
                        Id = new Guid(),
                        Name = "Холодильник у бабушки",
                        OwnerName = "Бабушка и Дедушка",
                        ModelId = new Guid(),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid(),
                        Name = "На свалку",
                        OwnerName = "БОМЖ",
                        ModelId = new Guid(),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid(),
                        Name = "Дима",
                        OwnerName = "Домашний",
                        ModelId = new Guid(),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid(),
                        Name = "Оля",
                        OwnerName = "Дом2",
                        ModelId = new Guid(),
                    }
                };
            }
        }
    }
}
