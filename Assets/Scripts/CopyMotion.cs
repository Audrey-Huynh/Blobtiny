using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    public bool mirror;
    ConfigurableJoint cj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mirror)
        {
            cj.targetRotation = targetLimb.rotation;

        }
        else
        {
            cj.targetRotation = Quaternion.Inverse(targetLimb.rotation);
        }

        //cj.targetRotation = targetLimb.rotation;
    }

}