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
        [ReadOnly] public FoodType RequestedFoodType;
        [ReadOnly] public int      CoinAmount;

        public float                    EatingDuration;
        public FoodRequestConfiguration FoodRequestConfiguration;
        public bool                     IsDoneEating;
        public bool                     DidPayForFood;

        public override void OnAwake()
        {
            base.OnAwake();

            RequestedFoodType = FoodRequestConfiguration.GetRandomFoodType();
        }
    }
}