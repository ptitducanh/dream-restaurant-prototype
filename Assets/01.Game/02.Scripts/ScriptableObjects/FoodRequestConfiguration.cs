using System;
using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(fileName = "FoodRequestSO", menuName = "Data/Food Request", order = 0)]
    public class FoodRequestConfiguration : ScriptableObject
    {  
        public FoodRequest[] Requests;
        
        public FoodType GetRandomFoodType()
        {
            var randomIndex = UnityEngine.Random.Range(0, Requests.Length);
            return Requests[randomIndex].FoodType;
        }
    }

    [Serializable]
    public class FoodRequest
    {
        public FoodType FoodType;
        public int      Amount;
        public float    Factor;
    }

    public enum FoodType
    {
        Burger,
        Pizza
    }
}