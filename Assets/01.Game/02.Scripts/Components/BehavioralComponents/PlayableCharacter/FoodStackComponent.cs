using System.Collections.Generic;
using System.Linq;
using Scripts.Data;
using Scripts.Entities;
using UnityEngine;

namespace Scripts.Components.BehavioralComponents
{
    public class FoodStackComponent : BehavioralComponent
    {
        [SerializeField] private Transform container;
        [SerializeField] private float     itemHeight;

        private FoodItemPoolEntity _foodItemPoolEntity;
        private List<FoodType>     _foods = new();  

        public override void OnAwake()
        {
            base.OnAwake();

            _foodItemPoolEntity = EntityManager.Instance.GetEntitiesByType<FoodItemPoolEntity>().FirstOrDefault();
        }

        public void AddFood(FoodType food)
        {
        }
    }
}