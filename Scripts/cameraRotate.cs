using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    public Transform target;

    private float _smoothness = 0.5f;
    private Vector3 _cameraOffset;

    public float rotationSpeedTouch = 5;
    public float zoomSpeedTouch = 0.5f;

    void Start()
    {
        _cameraOffset = transform.position - target.position;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        if (Input.touchCount == 1)
        {
            float touchDelta = Mathf.Clamp(Input.GetTouch(0).deltaPosition.x, -1.0f, 1.0f);
            Quaternion camAngle = Quaternion.AngleAxis(touchDelta * rotationSpeedTouch, Vector3.up);

            Vector3 newPos = target.position + _cameraOffset;
            _cameraOffset = camAngle * _cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, _smoothness);
            transform.LookAt(target);
        }

    }


}