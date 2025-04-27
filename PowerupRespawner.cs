using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace teamFourFinalProject
{
    public class PowerupRespawner : MonoBehaviour
    {
        [SerializeField] private float respawnDelay = 20f;
        private Vector3 originalPosition;
        private Quaternion originalRotation;
        private Renderer[] renderers;
        private Collider[] colliders;

        private void Awake()
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;

            renderers = GetComponentsInChildren<Renderer>(true);
            colliders = GetComponentsInChildren<Collider>(true);

            Debug.Log($"[Respawner] Initialized at {originalPosition} with delay of {respawnDelay}");
        }

        public void OnPickedUp()
        {
            Debug.Log("[Respawner] Powerup picked up. Starting respawn timer");
            StartCoroutine(RespawnCoroutine());
        }

        private IEnumerator RespawnCoroutine()
        {
            SetPowerupVisible(false);
            Debug.Log("[Respawner] Powerup hidden", this);

            yield return new WaitForSeconds(respawnDelay);

            transform.position = originalPosition;
            transform.rotation = originalRotation;

            SetPowerupVisible(true);
            Debug.Log("[Respawner] Powerup respawned", this);
        }

        private void SetPowerupVisible(bool visible)
        {
            foreach (var r in renderers)
            {
                if (r != null)
                {
                    r.gameObject.SetActive(visible);
                    r.enabled = visible;

                    Debug.Log($"[Respawner] Renderer {r.name} enabled: {r.enabled} | GameObject Active: {r.gameObject.activeSelf}", this);
                }
            }

            foreach (var c in colliders)
            {
                if (c != null)
                {
                    c.enabled = visible;
                    Debug.Log($"[Respawner] Renderer {c.name} enabled: {c.enabled}", this);
                }
            }

            Debug.Log($"[Respawner] Set visibility: {visible}", this);
        }
    }
}
