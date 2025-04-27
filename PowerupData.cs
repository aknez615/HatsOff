using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace teamFourFinalProject
{
    public abstract class PowerupData : ScriptableObject
    {
        public float duration;

        public abstract void ApplyEffects(PlayerController player);
        public abstract void RemoveEffects(PlayerController player);
    }
}
