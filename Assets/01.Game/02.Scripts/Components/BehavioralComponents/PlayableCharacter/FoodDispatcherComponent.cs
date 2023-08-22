﻿using System;
using System.Linq;
using Scripts.Data;
using Scripts.Entities;
using UnityEngine;

namespace Scripts.Components.BehavioralComponents
{
    public class FoodDispatcherComponent : BehavioralComponent
    {
        private FoodContainerComponent _foodContainer;

        public override void OnAwake()
        {
            base.OnAwake();

            _foodContainer = Entity.GetDataComponent<FoodContainerComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var chairEntity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (chairEntity == null) return;

            var chairComponent = chairEntity.GetDataComponent<ChairStatComponent>();
            if (chairComponent == null) return;

            if (!chairComponent.IsOccupied) return;

            var occupant = chairComponent.Occupant;
            if (occupant == null) return;

            if (occupant is NPCEntity npcEntity)
            {
                var aiControlledComponent = npcEntity.GetBehavioralComponent<AIControlledComponent>();
                var requestFoodType       = npcEntity.GetDataComponent<NPCDataComponent>().RequestedFoodType;
                var npcState              = npcEntity.GetDataComponent<NPCDataComponent>().State;

                if (npcState != NPCState.WaitingForFood) return;

                var foodForNPC = _foodContainer.GetFood(requestFoodType);
                if (foodForNPC != FoodType.None)
                {
                    aiControlledComponent.Eat();
                }
            }
        }
    }
}