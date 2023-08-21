using System.Collections.Generic;
using Scripts.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Components
{
    public class FoodContainerComponent : DataComponent
    {
        [ReadOnly]public List<FoodType> Foods = new();
    }
}