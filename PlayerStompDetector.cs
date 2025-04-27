using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace teamFourFinalProject
{
    public class PlayerStompDetector : MonoBehaviour
    {
        public float stompBounceForce = 25f;
        
        

        private void OnTriggerEnter(Collider other)
        {
            IStompable stompable = other.GetComponentInParent<IStompable>();
            if (stompable != null)
            {
                Rigidbody rb = GetComponentInParent<Rigidbody>();
                if (rb != null && rb.velocity.y < 0f)
                {
                    //Bounce
                    rb.velocity = new Vector3(rb.velocity.x, stompBounceForce, rb.velocity.z);

                    stompable.OnStomped();
                    Debug.Log(other);
                    stompable.Die();
                }
            }
        }
    }
}
