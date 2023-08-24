using UnityEngine;

namespace Scripts.Components.DataComponents
{
    public class UnlockableSlotDataComponent : DataComponent
    {
        public bool IsUnlocked;
        public int  RequiredCoin;
        public int  RemainingCoin;

        public override void OnAwake()
        {
            base.OnAwake();

            RemainingCoin = RequiredCoin;
        }
    }
}