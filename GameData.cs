using System.Collections;
using System.Collections.Generic;
using teamFourFinalProject;
using UnityEngine;

    [System.Serializable]
    public class GameData
    {
        public KeyData keyData;

        public int curHealth;
        public int playerCheckpoint;

        public int currentLevel;
        public int unlockedLevels;

        public List<string> collectedKeyIDs;
        public List<string> keysCollected = new List<string>();

        //the values defined in this will be default values for when game loads in

        public GameData()
        {
            this.curHealth = 5; //Player health
            this.playerCheckpoint = 0; //Checkpoints reached during levels
            this.currentLevel = 0; //HUB
            this.unlockedLevels = 1; //Level 1 is unlocked
            this.collectedKeyIDs = new List<string>(); //4 Keys
        }
    }
