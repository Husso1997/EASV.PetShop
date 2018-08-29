using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    internal class FakeDB
    {
        private int petId;
        private IEnumerable<Pet> petList;

        internal FakeDB()
        {
            petList = Enumerable.Empty<Pet>();
            petId = 1;
            RandomPets();
        }

        public void CreatePet(Pet pet)
        {
            pet.PetID = petId++;
            var petList = this.petList.ToList();
            petList.Add(pet);
            this.petList = petList;
        }

        public void DeletePet(int id)
        {
            Pet pet = GetPetById(id);

            var petList = this.petList.ToList();
            petList.Remove(pet);
            this.petList = petList;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return petList;
        }

        public void UpdatePet(Pet pet)
        {
            Pet PetToUpdate = GetPetById(pet.PetID);
            PetToUpdate.PetName = pet.PetName;
            PetToUpdate.PetPreviousOwner = pet.PetPreviousOwner;
            PetToUpdate.PetPrice = pet.PetPrice;
            PetToUpdate.SoldDate = pet.SoldDate;
        }

        public Pet GetPetById(int id)
        {
            foreach(var pet in petList.ToList())
            {
                if(pet.PetID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public void RandomPets()
        {
            Random random = new Random();
            string[] randomNames = {"Peter", "James", "Arnold", "Muscle", "NoNameDog"};
            var petList = this.petList.ToList();

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
                    SoldDate = new DateTime(1997, 4, 20),
                };
                petList.Add(pet);
            }
            this.petList = petList;
        }

        public MyEnum GetEnumType(int index)
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
