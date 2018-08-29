using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;


namespace Easv.PetShop.Core.Application.Services.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;

        }
        
        public List<Pet> GetAllPetByType(MyEnum enumType)
        {
            List<Pet> petSpecificType = GetAllPets().Where(pet => pet.PetType == enumType).ToList();
            
            return petSpecificType;
        }

        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> petSpecificType = GetAllPets().OrderBy(pet => pet.PetPrice).ToList();
            return petSpecificType.Take(5).ToList();
        }

        public void CreatePet(Pet pet)
        {
            petRepository.CreatePet(pet);
        }

        public void DeletePet(int petId)
        {
            petRepository.DeletePet(petId);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return petRepository.GetAllPets();
        }

        public Pet GetPetByID(int petId)
        {
            return petRepository.GetPetByID(petId);
        }

        public void UpdatePet(Pet pet)
        {
            petRepository.UpdatePet(pet);
        }
    }
}
