using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Components
{
    public enum NPCState
    {
        Initial,
        MovingIn,
        WaitingForFood,
        Eating,
        FinishedEating,
        MovingOut
    }

    public class NPCDataComponent : DataComponent
    {
        [ReadOnly] public NPCState State;
        [ReadOnly] public float    RemainingEatingTime;

        public float EatingDuration;
        public FoodRequestConfiguration FoodRequestConfiguration;
    }
}