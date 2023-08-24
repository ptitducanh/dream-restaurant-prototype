using System;
using System.Collections;
using Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.BehavioralComponents
{
    public class UnlockableSlotComponent : BehavioralComponent
    {
        [SerializeField] private Image      progressBar;
        [SerializeField] private GameObject objectToUnlock;

        private UnlockableSlotDataComponent _unlockableSlotDataComponent;
        private InventoryDataComponent      _inventoryDataComponent;
        private Coroutine                   _unlockCoroutine;

        private void OnTriggerEnter(Collider other)
        {
            // if the slot is already unlocked, return
            if (_unlockableSlotDataComponent.IsUnlocked) return;
            
            // if not now we'll try to get the inveo
            if (_inventoryDataComponent == null)
            {
                var entity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
                if (entity is PlayerCharacterEntity playerEntity)
                {
                    _inventoryDataComponent = playerEntity.GetDataComponent<InventoryDataComponent>();
                }
            }

            if (_inventoryDataComponent == null) return;
            
            
            if (_unlockCoroutine != null)
            {
                StopCoroutine(_unlockCoroutine);
                _unlockCoroutine = null;
            }
            _unlockCoroutine = StartCoroutine(IEUnlockSlot());
        }

        private void OnTriggerExit(Collider other)
        {
            var entity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (entity is PlayerCharacterEntity playerEntity)
            {
                if (_unlockCoroutine != null)
                {
                    StopCoroutine(_unlockCoroutine);
                    _unlockCoroutine = null;
                }
            }
        }

        private IEnumerator IEUnlockSlot()
        {
            var wait1Sec = new WaitForSeconds(1);
            while (_unlockableSlotDataComponent.IsUnlocked)
            {
                yield return wait1Sec;
                var playerCoin = _inventoryDataComponent.GetIntStat("Coin");
                if (playerCoin <= 0) yield break;
                _inventoryDataComponent.UpdateIntStat("Coin", -1);
                _unlockableSlotDataComponent.RemainingCoin--;

                if (_unlockableSlotDataComponent.RemainingCoin <= 0)
                {
                    _unlockableSlotDataComponent.IsUnlocked = true;
                    break;
                }
            }
            
            
        }
    }
}