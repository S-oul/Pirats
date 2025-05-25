using System;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
