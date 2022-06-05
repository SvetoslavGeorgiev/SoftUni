using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01_Meal_Plan
{
    public class P01_Meal_Plan
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var calories = new Stack<int>(input2);
            var meals = new Queue<string>(input);
            var allMeals = meals.Count;

            var currentMeal = string.Empty;
            var currentDayCalories = 0;
            int mealCalories = 0;
            
            if (meals.Any())
            {
                currentMeal = meals.Dequeue();
                mealCalories = GetEachMealCalories(currentMeal);
            }
            else
            {
                return;
            }
            

            while (calories.Any() && (currentDayCalories = calories.Pop()) != 0)
            {

                if (currentDayCalories > mealCalories)
                {
                    currentDayCalories -= mealCalories;
                    calories.Push(currentDayCalories);
                    if (meals.Any())
                    {
                        currentMeal = meals.Dequeue();
                        mealCalories = GetEachMealCalories(currentMeal);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (currentDayCalories == mealCalories)
                {
                    if (meals.Any())
                    {
                        currentMeal = meals.Dequeue();
                        mealCalories = GetEachMealCalories(currentMeal);
                    }
                    else
                    {
                        break;
                    }
                    
                }
                else
                {
                    mealCalories -= currentDayCalories;
                }
            }

            if (calories.Any())
            {

                Console.WriteLine($"John had {allMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {allMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        private static int GetEachMealCalories(string currentMeal)
        {
            var mealCalories = 0;

            switch (currentMeal)
            {
                case "salad":
                    mealCalories = 350;
                    break;
                case "soup":
                    mealCalories = 490;
                    break;
                case "pasta":
                    mealCalories = 680;
                    break;
                case "steak":
                    mealCalories = 790;
                    break;
                default:
                    break;
            }

            return mealCalories;
        }
    }
}
