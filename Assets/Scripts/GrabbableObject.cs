using UnityEngine;

public class GrabbableObject : MonoBehaviour
{

    private Transform currentTarget;
    private float pullSpeed = 5.0f;
    private bool isLevitating = false;
    private Rigidbody rb;
    //private bool isGrabbed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartLevitating(Transform target, float speed)
    {
        currentTarget = target;
        pullSpeed = speed;
        isLevitating = true;
        
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
        }
        
    }

    void Update()
    {
        if (isLevitating && currentTarget != null)
        {
            // move to the target hand
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, pullSpeed * Time.deltaTime);


            // stop object at current target's position when close enough distance
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                transform.position = currentTarget.position;
                //isGrabbed = true;
            }
        }
    }
}
