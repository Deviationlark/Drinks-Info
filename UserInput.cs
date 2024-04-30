using System.ComponentModel.DataAnnotations;

namespace DrinksInfo
{
    public class UserInput
    {
        DrinkDB drinkDB = new();
        DrinkService drinkService = new();

        internal void GetCategoryInput()
        {
            List<Category> categories = drinkService.GetCategories();

            Console.WriteLine("Enter the id of the Category: ");
            string userInput = Console.ReadLine();

            while (!Validation.CategoryValidation(categories, userInput))
            {
                Console.WriteLine("Invalid Category.");
                Console.WriteLine("Enter the id of the Category: ");
                userInput = Console.ReadLine();
            }
            if (userInput == "11") GetDrinkInput("Favorite Drinks");

            else GetDrinkInput(categories[int.Parse(userInput)].strCategory);
        }

        internal void GetDrinkInput(string category)
        {
            FavoriteDrinks favoriteDrinks = new();
            List<DrinkDB> favDrinks = new();
            List<Drink> drinks2 = new();
            if (category == "Favorite Drinks") favDrinks = favoriteDrinks.Get();
            else drinks2 = drinkService.GetDrinks(category);
            SearchedDrinks searchedDrinks = new();

            Console.WriteLine("Enter the id of the drink: ");
            string userInput = Console.ReadLine();

            while (!Validation.DrinkValidation(favDrinks, category, drinks2, userInput))
            {
                Console.WriteLine("Invalid Drink");
                Console.WriteLine("Enter the id of the Drink: ");
                userInput = Console.ReadLine();
            }


            DrinkDetail drinkDetails = drinkService.GetDrinkDetail(userInput);
            drinkDB.Id = userInput;
            drinkDB.Name = drinkDetails.strDrink;
            drinkDB.Category = category;
            FavoriteDrink(drinkDB);

            searchedDrinks.Write(drinkDB);
        }

        private void FavoriteDrink(DrinkDB drinkDB, int num = 0)
        {
            if (num == 0)
            {
                Console.WriteLine("0. Category Menu");
                Console.WriteLine("1. Add drink to favorites");
                Console.WriteLine("Choose an option: ");
                string userInput = Console.ReadLine();

                if (userInput == "0") GetCategoryInput();

                else if (userInput == "1")
                {
                    FavoriteDrinks favoriteDrinks = new();
                    favoriteDrinks.Write(drinkDB);
                }

                else
                    Console.WriteLine("Invalid option");
            }
            else
            {
                
            }

        }
    }
}