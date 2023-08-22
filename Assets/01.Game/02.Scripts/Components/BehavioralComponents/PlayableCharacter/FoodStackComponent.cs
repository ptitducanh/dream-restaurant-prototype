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

        private FoodContainerComponent _foodContainer;
        private FoodItemPoolEntity     _foodItemPoolEntity;
        private List<GameObject>       _foodObjects = new();
        private List<FoodType>         _foodTypes   = new();

        public override void OnAwake()
        {
            base.OnAwake();

            _foodContainer      = Entity.GetDataComponent<FoodContainerComponent>();
            _foodItemPoolEntity = EntityManager.Instance.GetEntitiesByType<FoodItemPoolEntity>().FirstOrDefault();

            _foodContainer.OnFoodAdded   += OnAddFood;
            _foodContainer.OnFoodRemoved += OnRemoveFood;
        }

        private void OnAddFood(FoodType food)
        {
            var foodObject = Instantiate(_foodItemPoolEntity.FoodItems[food], container);
            foodObject.transform.localPosition = new Vector3(0, _foodContainer.Foods.Count * itemHeight, 0);
            _foodObjects.Add(foodObject);
            _foodTypes.Add(food);
        }

        private void OnRemoveFood(FoodType food)
        {
            int removeIndex = -1;
            for (int i = _foodTypes.Count - 1; i >= 0; i--)
            {
                if (removeIndex != -1)
                {
                    _foodObjects[i].transform.localPosition -= new Vector3(0, itemHeight, 0);
                }
                else
                {
                    if (_foodTypes[i] == food)
                    {
                        removeIndex = i;
                    }
                }
            }
            
            
            Destroy(_foodObjects[removeIndex]);
            _foodObjects.RemoveAt(removeIndex);
            _foodTypes.RemoveAt(removeIndex);
        }
    }
}