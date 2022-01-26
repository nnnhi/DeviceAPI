using System;
using System.Linq;
using DeviceAPI.Data.Models;

namespace DeviceAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Devices.Any())
            {
                return;   // DB has been seeded
            }

            //sample data get from https://www.dominos.ca/en/pages/order/menu#!/menu/category/entrees/
            var devices = new Device[]
              {
                new Device {
                    Id = 1,
                    Name = "Device 1",
                    Temperature = 10.0f,
                    Type = Enums.DeviceType.Mobile,
                    Status = Enums.DeviceStatus.Available,
                    DataUsage = "123, 234, 343"
                   },
                new Device {
                    Id = 2,
                    Name = "Device 2",
                    Temperature = 15.0f,
                    Type = Enums.DeviceType.Tablet,
                    Status = Enums.DeviceStatus.Offline,
                    DataUsage = "123, 234, 343"
                },
                new Device {
                    Id = 3,
                    Name = "Device 3",
                    Temperature = 12.0f,
                    Type = Enums.DeviceType.Screen,
                    Status = Enums.DeviceStatus.Available,
                    DataUsage = "123, 234, 343"
                    },
                new Device {
                    Id = 4,
                    Name = "Device 4",
                    Temperature = 13.0f,
                    Type = Enums.DeviceType.Mobile,
                    Status = Enums.DeviceStatus.Available,
                    DataUsage = "123, 234, 343"
                    }

              };

            var relations = new Relation[]
            {
                new Relation
                {
                    FromId = 1,
                    ToId = 2
                },
                new Relation
                {
                    FromId = 1,
                    ToId = 3
                },
                new Relation
                {
                    FromId = 1,
                    ToId = 4
                },
                new Relation
                {
                    FromId = 2,
                    ToId = 3
                },
                new Relation
                {
                    FromId = 4,
                    ToId = 2
                },
                new Relation
                {
                    FromId = 4,
                    ToId = 3
                }
            };

            foreach (var d in devices)
            {
                context.Devices.Add(d);
            }

            foreach (var r in relations)
            {
                context.Relations.Add(r);
            }


            context.SaveChanges();

        }
    }
}
