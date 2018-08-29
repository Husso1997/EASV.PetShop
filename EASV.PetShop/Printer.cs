using Easv.PetShop.Core.Application.Services.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace EASV.PetShop
{
    internal class Printer
    {
        private IPetService petService;

        internal Printer(IPetService petService)
        {
            this.petService = petService;
        }
        
        public void WelcomeToThePetShopMsg()
        {
            PrintLine("Welcome To Our PetShop \n");
            PrintLine("Select one of the following options \n \n");
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
