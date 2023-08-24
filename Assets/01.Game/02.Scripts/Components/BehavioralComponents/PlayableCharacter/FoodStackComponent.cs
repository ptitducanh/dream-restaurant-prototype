using System.Collections.Generic;
using System.Linq;
using Scripts.Data;
using Scripts.Entities;
using Scripts.Others;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Components.BehavioralComponents
{
    public class FoodStackComponent : BehavioralComponent
    {
        public  Transform Container;
        [SerializeField] private float     itemHeight;

        private FoodContainerComponent _foodContainer;
        private List<GameObject>       _foodObjects = new();
        private List<FoodType>         _foodTypes   = new();

        public override void OnAwake()
        {
            base.OnAwake();

            _foodContainer      = Entity.GetDataComponent<FoodContainerComponent>();

            _foodContainer.OnFoodAdded   += OnAddFood;
            _foodContainer.OnFoodRemoved += OnRemoveFood;
        }

        private void OnAddFood(FoodType food)
        {
            var foodObject = ObjectPool.Instance.Get(food.ToString());
            foodObject.SetActive(true);
            foodObject.transform.SetParent(Container);
            
            foodObject.transform.localPosition = new Vector3(0, _foodContainer.Foods.Count * itemHeight, 0);
            _foodObjects.Add(foodObject);
            _foodTypes.Add(food);
        }

        private void OnRemoveFood(FoodType food)
        {
            int removeIndex = -1;
            for (int i = 0; i < _foodObjects.Count; i++)
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
            
            
            ObjectPool.Instance.Return(_foodObjects[removeIndex]);
            _foodObjects.RemoveAt(removeIndex);
            _foodTypes.RemoveAt(removeIndex);
        }
    }
}