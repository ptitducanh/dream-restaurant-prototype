using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;

namespace Scripts.Entities
{
    public class FoodItemPoolEntity : BaseEntity
    {
        public List<FoodPrefab>                 FoodPrefabs = new List<FoodPrefab>();
        public Dictionary<FoodType, GameObject> FoodItems   = new Dictionary<FoodType, GameObject>();

        protected override void OnAwake()
        {
            base.OnAwake();

            foreach (var foodPrefab in FoodPrefabs)
            {
                FoodItems.Add(foodPrefab.FoodType, foodPrefab.gameObject);
            }
        }
    }
}