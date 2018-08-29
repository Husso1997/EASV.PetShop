using Easv.PetShop.Core.Application.Services.ApplicationService;
using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EASV.PetShop
{
    internal class Printer
    {
        private IPetService petService;

        internal Printer(IPetService petService)
        {
            this.petService = petService;

            WelcomeToThePetShopMsg();
            UserSelection();
        }
        
        public void WelcomeToThePetShopMsg()
        {
            PrintLine("Welcome To Our PetShop \n");
            PrintLine("Select one of the following options \n");
            OptionMessage();
            

        }

        public void UserSelection()
        {
            int selection;
            while(!int.TryParse(Console.ReadLine(), out selection) || selection<8 || selection>1)
            {
                switch (selection)
                {
                    case 1:
                        PrintAllPets();
                        break;
                    case 2:
                        PrintAllPetsByType();
                        break;
                    default:
                        PrintLine("\nInvalid input - Choose between 1-7 and no letters \n");
                        break;
                }
                OptionMessage();
            }
        }
        // Method call for five cheapest. To be used.
        public void PrintFiveCheapestPets()
        {
            foreach(var pet in petService.GetFiveCheapestPets())
            {
                PrintLine(pet.PetPrice +"");
            }
        }

        public void PrintAllPets()
        {
            foreach(var pet in petService.GetAllPets().ToList())
            {
                PrintPetInfo(pet);
            }
        }

        public MyEnum GetPetTypeEnum(string type)
        {
            string petType = type.ToLower();
            switch(type)
            {
                case "cat":
                    return MyEnum.Cat;
                case "dog":
                    return MyEnum.Dog;
                case "goat":
                    return MyEnum.Goat;
            }
            return MyEnum.Unknown;
        }

        public void PrintAllPetsByType()
        {

                PrintLine("What type of pet-type do you wanna search for?");
                PrintMyEnumsToString();

                List<Pet> petListType = petService.GetAllPetByType(GetPetTypeEnum(Console.ReadLine()));

                foreach(var pet in petListType)
                {
                PrintPetInfo(pet);
                };
        }

        public void PrintPetInfo(Pet pet)
        {
            PrintLine($"Pet-ID: {pet.PetID} Name: {pet.PetName} BirthDate: {pet.PetBirthDate}" +
            $" Price: {pet.PetPrice} \n\nPet-Type: {pet.PetType} Color: {pet.PetColor} Sold-Date:" +
            $" {pet.SoldDate} PreviousOwner: {pet.PetPreviousOwner} \n ----------------------------" +
            $"----------------------------------------------------- \n");
        }

        public void PrintMyEnumsToString()
        {
            var values = Enum.GetValues(typeof(MyEnum));
            foreach (var value in values)
            {
                PrintLine(value.ToString() + " ");
            }
            PrintLine("\n");
        }

        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        public void OptionMessage()
        {
            var optionCounter = 1;
            PrintLine($"{optionCounter++}: Show all pets");
            PrintLine($"{optionCounter++}: Search pets by specfic pet-type");
            PrintLine($"{optionCounter++}: Sort pets by price");
            PrintLine($"{optionCounter++}: Get the 5 cheapest pets");
            PrintLine($"{optionCounter++}: Create new pet");
            PrintLine($"{optionCounter++}: Delete pet");
            PrintLine($"{optionCounter++}: Update pet");

        }
    }
}
