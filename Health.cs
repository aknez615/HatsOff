using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace teamFourFinalProject
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 100;
        //[SerializeField] FloatEventChannel playerHealthChannel; For event system

        int currentHealth;

        public bool isDead => currentHealth <= 0;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Start()
        {
            PublishHealthPercentage();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            PublishHealthPercentage();
        }

        void PublishHealthPercentage()
        {
            /*if (playerHealthChannel != null)
            {
                playerHealthChannel.Invoke(currentHealth / (float)maxHealth);
            }*/
        }
    }
}
