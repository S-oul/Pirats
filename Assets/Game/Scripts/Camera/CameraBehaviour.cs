using System;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] float _cameraSpeed = .1f;

    [ShowNonSerializedField,Range(0,1)] private float _percentToEvaluate = 0f;

    Quaternion startRotation;
    private Quaternion EndQuat = new Quaternion(0.0443139039f, 0.954057932f, -0.236105442f, 0.179064199f);
    private void Start()
    {
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _percentToEvaluate += Input.GetAxis("Horizontal") * _cameraSpeed * Time.deltaTime;
        _percentToEvaluate = Mathf.Clamp01(_percentToEvaluate);
        transform.localRotation = Quaternion.Lerp(startRotation,EndQuat,_percentToEvaluate);
    }
}
