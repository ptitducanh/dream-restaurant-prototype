using UnityEngine;

namespace Scripts.Entities
{
    public class UnlockableSlotDataComponent : MonoBehaviour
    {
        public bool IsUnlocked;
        public int  RequiredCoin;
        public int  RemainingCoin;
    }
}