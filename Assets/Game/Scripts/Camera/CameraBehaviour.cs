using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] float _cameraSpeed = 1f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localEulerAngles += new Vector3(-Input.mousePositionDelta.y, Input.mousePositionDelta.x, 0)*_cameraSpeed;
    }
}
