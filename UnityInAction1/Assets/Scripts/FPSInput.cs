using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private const float baseSpeed = 7f;
    private float gravity = -9.8f;
    private CharacterController characterController;

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement = new Vector3(movement.x, gravity * Time.deltaTime, movement.z);
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        moveSpeed = baseSpeed * value;
    }
}
