using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace teamFourFinalProject
{
    [CreateAssetMenu(fileName = "KeyData", menuName = "Platformer/Keys")]
    public class KeyData : ScriptableObject
    {
        public string keyID; //eg key0, key1
        public string levelName; //eg level1
    }
}
