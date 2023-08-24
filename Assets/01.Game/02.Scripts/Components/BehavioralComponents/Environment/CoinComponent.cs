using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Entities;
using UnityEngine;
using Scripts.Others;

namespace Scripts.Components.BehavioralComponents
{
    public class CoinComponent : BehavioralComponent
    {
        private CoinDataComponent _coinDataComponent;

        public override void OnAwake()
        {
            base.OnAwake();
            
            _coinDataComponent = Entity.GetDataComponent<CoinDataComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var entity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (entity is PlayerCharacterEntity playerEntity)
            {
                var inventoryComponent = playerEntity.GetDataComponent<InventoryDataComponent>();
                inventoryComponent.UpdateIntStat("Coin", _coinDataComponent.Ammount);
                
                ObjectPool.Instance.Return(Entity.gameObject);
            }
        }
    }
}
