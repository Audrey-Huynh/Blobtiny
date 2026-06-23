using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{

    [Header("References")]
    public CameraControl cameraScript;
    public Transform root;

    [Header("Settings")]
    public float rotationSpeed = 100f;
    
    void FixedUpdate()
    {
        bool isMoving = IsPlayerMoving();

        if (isMoving)
        {
            float targetYaw = cameraScript.CurrentYaw;
            Quaternion targetRotation = Quaternion.Euler(0, targetYaw, 0);
            root.rotation = Quaternion.Slerp(root.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private bool IsPlayerMoving()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            return true;
        }
        return false;
    }
}
