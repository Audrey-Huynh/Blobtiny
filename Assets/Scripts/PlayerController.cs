using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Regular Movement Settings")]
    public float speed;
    public float strafeSpeed; // (speed for moving left and right)
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    [Header("Animation Settings")]
    public Animator anim;

    int heading;
    int strafe;

    [Header("Hand Target Transforms")]
    public Transform leftHandTarget;
    public Transform rightHandTarget;

    [Header("Levitation Settings")]
    public float pullSpeed = 6.0f;

    [Header("Other Levitation Controls")]
    bool mouseLeftPressed;
    bool mouseRightPressed;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            heading = (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0) - (Keyboard.current.shiftKey.isPressed ? 3 : 0);
            strafe = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);

            anim.SetBool("isWalk", heading == 1 || heading == -1);
            anim.SetBool("isRun", heading <= -2);
            anim.SetBool("isWalkLeft", strafe == -1);
            anim.SetBool("isWalkRight", strafe == 1);
        }
        
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
                hips.AddForce(forwardDir.normalized * speed * 1.5f, ForceMode.Force); // sprinting

            }
            else
            {
                hips.AddForce(forwardDir.normalized * speed, ForceMode.Force);
            }
        }

        if (Keyboard.current.sKey.isPressed) // backward
        {
            hips.AddForce(-forwardDir.normalized * speed, ForceMode.Force);
        }

        if (Keyboard.current.aKey.isPressed) // left
        {
            hips.AddForce(-rightDir.normalized * strafeSpeed, ForceMode.Force);
        }

        if (Keyboard.current.dKey.isPressed) // right
        {
            hips.AddForce(rightDir.normalized * strafeSpeed, ForceMode.Force);
        }


        if (Keyboard.current.spaceKey.isPressed)
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isGrounded = false;
                Debug.Log("Jumped!");
            }
        }


        // for levitation controls, check if the left or right mouse button is pressed
        if (Mouse.current.leftButton.isPressed)
        {
            mouseLeftPressed = true;
        }
        else
        {
            mouseLeftPressed = false;
        }

        if (Mouse.current.rightButton.isPressed)
        {
            mouseRightPressed = true;
        }
        else {
            mouseRightPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            GrabbableObject levObject = other.GetComponent<GrabbableObject>();
            // ^^ idk what that is just delete??

            if (levObject != null)
            {
                Transform chosenHand = DetermineClosestHand(other.transform.position);

                // if left mouse button is pressed, levitate object to left hand target IF the object is in range??
                // if right mouse button is pressed, levitate object to right hand target IF the object is in range
                if ((chosenHand == leftHandTarget && mouseLeftPressed) || (chosenHand == rightHandTarget && mouseRightPressed))
                {
                    levObject.StartLevitating(chosenHand, pullSpeed);
                }
                else
                {
                    // If neither hand is pressed, do not start levitating
                    return;
                }
            }
        }
    }

    private Transform DetermineClosestHand(Vector3 objectPosition)
    {
        float distanceToLeft = Vector3.Distance(objectPosition, leftHandTarget.position);
        float distanceToRight = Vector3.Distance(objectPosition, rightHandTarget.position);

        return (distanceToLeft < distanceToRight) ? leftHandTarget : rightHandTarget;
    }

}
