using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum rotationAxes
    {
        mouseXandY = 0,
        mouseX = 1,
        mouseY = 2
    }

    public rotationAxes axes = rotationAxes.mouseXandY;
    [SerializeField] private float sensitivityX = 1f;
    [SerializeField] private float sensitivityY = 1f;
    [SerializeField] private float maximumVertical = 45f;
    [SerializeField] private float minimumVertical = -45f;
    private float rotationX = 0f;

    private void Update()
    {
        if(axes == rotationAxes.mouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else if(axes == rotationAxes.mouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, minimumVertical, maximumVertical);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, minimumVertical, maximumVertical);
            float delta = Input.GetAxis("Mouse X") * sensitivityX;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
