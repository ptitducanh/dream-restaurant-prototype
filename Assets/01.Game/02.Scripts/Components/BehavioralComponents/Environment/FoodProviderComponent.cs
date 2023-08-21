using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using Scripts.Entities;
using UnityEngine;

namespace Scripts.Components.BehavioralComponents
{
    public class FoodProviderComponent : BehavioralComponent
    {
        private FoodProviderDataComponent _foodData;
        private Coroutine _addFoodToContainerCoroutine;
        
        public override void OnAwake()
        {
            base.OnAwake();
            
            _foodData = Entity.GetDataComponent<FoodProviderDataComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var mainCharacterEntity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (mainCharacterEntity == null) return;

            var foodContainer = mainCharacterEntity.GetDataComponent<FoodContainerComponent>();
            if (foodContainer == null) return;
            
            if (_addFoodToContainerCoroutine != null)
            {
                StopCoroutine(_addFoodToContainerCoroutine);
            }
            _addFoodToContainerCoroutine = StartCoroutine(IEAddFoodToContainer(foodContainer));
        }

        private void OnTriggerExit(Collider other)
        {
            var mainCharacterEntity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (mainCharacterEntity == null) return;
            
            if (_addFoodToContainerCoroutine != null)
            {
                StopCoroutine(_addFoodToContainerCoroutine);
            }
        }
        
        private IEnumerator IEAddFoodToContainer(FoodContainerComponent foodContainer)
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                foodContainer.Foods.Add(_foodData.FoodType);
            }
        }
    }
}
