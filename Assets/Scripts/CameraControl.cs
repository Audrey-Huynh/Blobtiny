using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [Header("References")]
    public Transform root;
    public InputActionProperty lookAction;

    [Header("Settings")]
    public float mouseSensitivity = 0.1f;
    public float distanceFromRoot = 5.0f;
    public Vector2 pitchMinMax = new Vector2(-40, 85); // limits for looking up and down

    private float _yaw;
    private float _pitch;

    public float CurrentYaw => _yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lookAction.action.Enable();
    }

    void LateUpdate() // prevents camera jittering by updating after all other updates
    {
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

        _yaw += lookInput.x * mouseSensitivity;
        _pitch -= lookInput.y * mouseSensitivity;

        _pitch = Mathf.Clamp(_pitch, pitchMinMax.x, pitchMinMax.y);

        /*Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        transform.position = root.position - rotation * Vector3.forward * distanceFromRoot;

        transform.rotation = rotation;*/
        Vector3 rootRotation = new Vector3(_pitch, _yaw);
        transform.eulerAngles = rootRotation;
        transform.position = root.position - transform.forward * distanceFromRoot;
    }



    /*public float rotationSpeed = 1;
    public Transform root;

    float mouseX, mouseY;

    public ConfigurableJoint hipJoint;

    float moveX;
    float moveY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        moveX = Mouse.current.delta.ReadValue().x;
        moveY = Mouse.current.delta.ReadValue().y;

        mouseX += moveX * rotationSpeed;
        mouseY -= moveY * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -15, 30); //constrain looking up and down

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);

        root.rotation = rootRotation;

        hipJoint.targetRotation = Quaternion.Euler(-mouseY, -mouseX, 0);
    }*/
}
