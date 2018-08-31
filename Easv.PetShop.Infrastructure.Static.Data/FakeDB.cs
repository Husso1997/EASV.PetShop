using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    internal class FakeDB
    {
        internal static int petId;
        internal static IEnumerable<Pet> petList;

        internal FakeDB()
        {
            petList = Enumerable.Empty<Pet>();
            petId = 1;
            RandomPets();
        }

        internal void RandomPets()
        {
            Random random = new Random();
            string[] randomNames = {"Peter", "James", "Arnold", "Muscle", "NoNameDog"};
            var petList = FakeDB.petList.ToList();

            for (int i = 0;i<10;i++)
            {
                Pet pet = new Pet
                {
                PetID = petId++,
                    PetName = randomNames[random.Next(0, 4)],
                    PetType = GetEnumType(random.Next(0, 3)),
                    PetPrice = random.NextDouble(),
                    PetPreviousOwner = "None",
                    PetBirthDate = new DateTime(1995, 2, 20),
                    SoldDate = DateTime.Today,
                };
                petList.Add(pet);
            }
            FakeDB.petList = petList;
        }

        internal MyEnum GetEnumType(int index)
        {
            switch(index)
            {
                case 0:
                    return MyEnum.Dog;
                case 1:
                    return MyEnum.Cat;
                case 2:
                    return MyEnum.Goat;
                default:
                    break;
            }
            return MyEnum.Unknown;
        }


    }
}
