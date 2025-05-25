using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Serialization;

public class Canons : MonoBehaviour
{
    [SerializeField] private ReloadCanon _task;
    public bool isLoaded = false;

    public void Shoot()
    {
        if (!isLoaded) return;
        print("SHOOT");
        _task.EnableTask();
        Instantiate(Resources.Load<GameObject>("CanonBall"), transform.position, Quaternion.identity).GetComponent<Rigidbody>().linearVelocity = transform.forward * 50f;
        isLoaded = false; 
    }

    private void Awake()
    {
        
    }
}
