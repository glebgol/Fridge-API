using Entities.DataTransferObjects;
using Entities.Models;

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
                        Id = new Guid("dbfc4f30-8cc4-47e5-b543-08dab08812cc"),
                        Name = "Холодильник у бабушки",
                        OwnerName = "Бабушка и Дедушка",
                        ModelId = new Guid("8cbe08ff-a185-4c9f-0494-08daaee05b68"),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid("5a9c69e9-7e67-4790-b544-08dab08812cc"),
                        Name = "На свалку",
                        OwnerName = "БОМЖ",
                        ModelId = new Guid("f10698f8-2d7b-4095-eb3d-08daaee09009"),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid("46aad042-fa8d-49ea-b545-08dab08812cc"),
                        Name = "Дима",
                        OwnerName = "Домашний",
                        ModelId = new Guid("97e8aa83-ba12-4226-d1ab-08dab0876da4"),
                    },
                    new Entities.Models.Fridge
                    {
                        Id = new Guid("c6c8dcce-2c5b-44f4-b546-08dab08812cc"),
                        Name = "Оля",
                        OwnerName = "Дом2",
                        ModelId = new Guid("97e8aa83-ba12-4226-d1ab-08dab0876da4"),
                    }
                };
            }
        }
        public static FridgeForCreationDto FridgeForCreation
        {
            get
            {
                return new FridgeForCreationDto
                {
                    Name = "Холодильник у бабушки",
                    OwnerName = "Бабушка и Дедушка",
                };
            }
        }
        public static IEnumerable<FridgeModel> FridgeModels
        {
            get
            {
                return new List<FridgeModel>()
                {
                    new FridgeModel
                    {
                        Id = new Guid("8cbe08ff-a185-4c9f-0494-08daaee05b68"),
                        Name = "Atlant-2022",
                        Year = 2022
                    },
                    new FridgeModel
                    {
                        Id = new Guid("97e8aa83-ba12-4226-d1ab-08dab0876da4"),
                        Name = "LG",
                        Year = 2018
                    },
                    new FridgeModel
                    {
                        Id = new Guid("19d6f605-7596-4cd9-d1ac-08dab0876da4"),
                        Name = "Bosch",
                        Year = 2022
                    }
                };
            }
        }

        public static Guid ExistingFridgeModelId
        {
            get
            {
                return new Guid("8cbe08ff-a185-4c9f-0494-08daaee05b68");
            }
        }
        public static Guid NotExistingFridgeModelId
        {
            get
            {
                return new Guid("87ea011e-6d52-42a3-b547-08dab08812cc");
            }
        }
    }
}
