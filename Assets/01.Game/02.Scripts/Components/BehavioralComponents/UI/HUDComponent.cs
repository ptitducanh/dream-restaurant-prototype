using System.Linq;
using Scripts.Entities;
using TMPro;
using UnityEngine;

namespace Scripts.Components.BehavioralComponents
{
    public class HUDComponent : BehavioralComponent
    {
        [SerializeField] private TMP_Text[] coinTexts;
        
        private InventoryDataComponent _inventoryDataComponent;
        private int _currentCoinAmount;
        
        public override void OnStart()
        {
            base.OnStart();
            
            var characterEntites = EntityManager.Instance.GetEntitiesByType<PlayerCharacterEntity>();
            var characterEntity  = characterEntites.FirstOrDefault();
            if (characterEntity == null) return;
            
            _inventoryDataComponent = characterEntity.GetDataComponent<InventoryDataComponent>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (_inventoryDataComponent.GetIntStat("Coin") == _currentCoinAmount) return;
            _currentCoinAmount = _inventoryDataComponent.GetIntStat("Coin");
            var coinAmountText = _currentCoinAmount.ToString();
            foreach (var text in coinTexts)
            {
                text.text = coinAmountText;
            }
        }
    }
}