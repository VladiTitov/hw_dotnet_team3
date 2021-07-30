using System.Collections.Generic;
using HM12.Task1.Models;

namespace HM12.Task1.Services.ModelsServices.Interfaces
{
    interface IMotorcycleService
    {
        IEnumerable<Motorcycle> GetItems();
        void CreateItem(Motorcycle item);
        void UpdateItem(Motorcycle item);
        void DeleteItem(Motorcycle item);
        Motorcycle GetItemById(Motorcycle item);
        void ShowItems();
    }
}
