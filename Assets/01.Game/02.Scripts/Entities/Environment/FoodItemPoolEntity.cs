using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;

namespace Scripts.Entities
{
    public class FoodItemPoolEntity : BaseEntity
    {
        public Dictionary<FoodType, GameObject> FoodItems = new Dictionary<FoodType, GameObject>();
    }
}