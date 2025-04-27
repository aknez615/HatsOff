using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace teamFourFinalProject
{
    public class PowerupPickup : MonoBehaviour
    {
        [SerializeField] PowerupData powerup;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player))
            {
                player.PickupPowerup(powerup);
                
                var respawner = GetComponent<PowerupRespawner>();
                if (respawner != null)
                {
                    respawner.OnPickedUp();
                }

                else
                {
                    //Destroy(gameObject);
                }
            }
        }
    }
}
