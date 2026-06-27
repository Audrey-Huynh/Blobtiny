using UnityEngine;

public class Grab : MonoBehaviour
{
    /*public Animator animator;
    GameObject grabedObj;
    public Rigidbody rb;
    public int isLeftOrRight;
    public bool alreadyGrabbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(isLeftOrRight))
        {
            if (isLeftOrRight == 0)
            {
                animator.SetBool("isLeftHandUp", true);
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetBool("isRightHandUp", true);
            }

            FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 10000;
        }
        else if (Input.GetMouseButtonUp(isLeftOrRight))
        {
            if (isLeftOrRight == 0)
            {
                animator.SetBool("isLeftHandUp", false);
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetBool("isRightHandUp", false);
            }

            if (grabbedObj != null)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint>());
            }
            grabbedObj = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            grabbedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabbedObj = null;
    }*/
}
