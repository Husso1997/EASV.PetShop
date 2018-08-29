using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    public class PetRepository : IPetRepository
    {
        private FakeDB fakeDB;

        public PetRepository()
        {
            fakeDB = new FakeDB();
        }
        
        public void CreatePet(Pet pet)
        {
            fakeDB.CreatePet(pet);
        }

        public void DeletePet(int petId)
        {
            fakeDB.DeletePet(petId);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return fakeDB.GetAllPets();
        }

        public Pet GetPetByID(int petId)
        {
            return fakeDB.GetPetById(petId);
        }

        public void UpdatePet(Pet pet)
        {
            fakeDB.UpdatePet(pet);
        }
    }
}
