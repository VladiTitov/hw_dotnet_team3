using System.Collections.Generic;
using HM12.Task1.Models;

namespace HM12.Task1.Services.ModelsServices.Interfaces
{
    interface IMotorcycleService
    {
        IEnumerable<Motorcycle> GetItems();
        void CreateItem();
        void UpdateItem(Motorcycle item);
        void DeleteItem();
        Motorcycle GetItemById(int id);
        void ShowItems();
    }
}
