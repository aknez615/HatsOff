using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace teamFourFinalProject
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] Vector3 moveTo = Vector3.zero;
        [SerializeField] float moveTime = 1f;
        [SerializeField] Ease ease = Ease.InOutQuad;

        Vector3 startPosition;

        private void Start()
        {
            startPosition = transform.position;
            Move();
        }

        private void Move()
        {
            transform.DOMove(endValue: startPosition + moveTo, moveTime)
                .SetEase(ease)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
