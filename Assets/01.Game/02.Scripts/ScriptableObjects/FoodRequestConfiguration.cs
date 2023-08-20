using System;
using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(fileName = "FoodRequestSO", menuName = "Data/Food Request", order = 0)]
    public class FoodRequestConfiguration : ScriptableObject
    {  
        public FoodRequest[] Requests;
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