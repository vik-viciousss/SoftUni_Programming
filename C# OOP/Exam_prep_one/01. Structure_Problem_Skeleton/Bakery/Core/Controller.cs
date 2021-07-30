using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == BakedFoodType.Bread.ToString())
            {
                this.bakedFoods.Add(new Bread(name, price));
            }
            if (type == BakedFoodType.Cake.ToString())
            {
                this.bakedFoods.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == DrinkType.Tea.ToString())
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            if (type == DrinkType.Water.ToString())
            {
                this.drinks.Add(new Water(name, portion, brand));
            }

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == TableType.InsideTable.ToString())
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == TableType.OutsideTable.ToString())
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"Added table number {tableNumber} in the bakery";
        }
        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill() + table.Price;
            this.totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}\r\n" +
                $"Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            string result = "";
            List<ITable> freeTables = this.tables.Where(x => !x.IsReserved).ToList();

            for (int i = 0; i < freeTables.Count; i++)
            {
                if (i != freeTables.Count -1)
                {
                    result += freeTables[i].GetFreeTableInfo() + Environment.NewLine;
                }
                else
                {
                    result += freeTables[i].GetFreeTableInfo();
                }
            }

            return result;
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

    }
}
