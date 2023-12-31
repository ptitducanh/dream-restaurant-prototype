using System;
using System.Collections.Generic;
using Scripts.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Components
{
    public class FoodContainerComponent : DataComponent
    {
        [SerializeField] [ReadOnly] 
        public List<FoodType> Foods { get; private set; } = new();

        public Action<FoodType, Vector3> OnFoodAdded;
        public Action<FoodType> OnFoodRemoved;
            
        public void AddFood(FoodType food, Vector3 sourcePosition)
        {
            Foods.Add(food);
            OnFoodAdded?.Invoke(food, sourcePosition);
        }

        public FoodType GetFood(FoodType food)
        {
            foreach (var foodItem in Foods)
            {
                if (foodItem == food)
                {
                    Foods.Remove(foodItem);
                    OnFoodRemoved?.Invoke(foodItem);
                    return foodItem;
                }
            }

            return FoodType.None;
        }
    }
}