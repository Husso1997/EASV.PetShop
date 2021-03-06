﻿using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Application.Services.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAllPets();

        bool DeletePet(int petId);

        void CreatePet(Pet pet);

        void UpdatePet(Pet pet);

        Pet GetPetByID(int petId);


    }
}
