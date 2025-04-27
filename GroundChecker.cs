using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace teamFourFinalProject
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] float groundDistance = 0.08f;
        [SerializeField] LayerMask groundLayers;
        [SerializeField] LayerMask cardLayers;

        public bool isGrounded {  get; private set; }
        public bool isCardGrounded { get; private set; }
        public bool IsGrounded => isGrounded || isCardGrounded;

        private void Update()
        {
            Vector3 origin = transform.position + Vector3.up * 0.1f;

            isGrounded = Physics.SphereCast(origin: transform.position, radius: groundDistance, direction: Vector3.down, out _, groundDistance, (int)groundLayers);
            isCardGrounded = Physics.SphereCast(origin: transform.position, radius: groundDistance, direction: Vector3.down, out _, groundDistance, cardLayers);
        }

        private void OnDrawGizmos()
        {
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;
            float radius = 0.5f;
            float maxDistance = 10f;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(origin, radius);
            Gizmos.DrawWireSphere(origin + direction * maxDistance, radius);
            Gizmos.DrawLine(origin + Vector3.up * radius, origin + direction * maxDistance + Vector3.up * radius);
            Gizmos.DrawLine(origin - Vector3.up * radius, origin + direction * maxDistance - Vector3.up * radius);
            Gizmos.DrawLine(origin + Vector3.right * radius, origin + direction * maxDistance + Vector3.right * radius);
            Gizmos.DrawLine(origin - Vector3.right * radius, origin + direction * maxDistance - Vector3.right * radius);
        }
    }
}
