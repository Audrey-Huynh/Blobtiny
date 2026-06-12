using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed; // (speed for moving left and right)
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
        isGrounded = true; // DELETE when add the following code below to a different script
        /*
        public PlayerController playerController;

    private void Start()
    {
        playerController = GetGomponent<PlayerController>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isGrounded = true;
    }
         */
    }

    private void FixedUpdate()
    {
        Vector3 forwardDir = hips.transform.forward;
        forwardDir.y = 0; // prevent vertical movement when moving forward
        Vector3 rightDir = hips.transform.right;
        rightDir.y = 0;

        if (Keyboard.current.wKey.isPressed) // forward
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                hips.AddRelativeForce(forwardDir.normalized * speed * 1.5f, ForceMode.Force); // sprinting

            }
            else
            {
                hips.AddRelativeForce(forwardDir.normalized * speed, ForceMode.Force);
            }
        }

        if (Keyboard.current.sKey.isPressed) // backward
        {
            hips.AddRelativeForce(-forwardDir.normalized * speed, ForceMode.Force);
        }

        if (Keyboard.current.aKey.isPressed) // left
        {
            hips.AddRelativeForce(-rightDir.normalized * strafeSpeed, ForceMode.Force);
        }

        if (Keyboard.current.dKey.isPressed) // right
        {
            hips.AddRelativeForce(rightDir.normalized * strafeSpeed, ForceMode.Force);
        }


        if (Keyboard.current.spaceKey.isPressed)
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                //isGrounded = false;
                Debug.Log("Jumped!");
            }
        }
    }

}
