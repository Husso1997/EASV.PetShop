using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    internal class FakeDB
    {
        private IEnumerable<Pet> petList;

        internal FakeDB()
        {
            List<Pet> petList = this.petList.ToList();
            this.petList = petList;
        }


    }
}
