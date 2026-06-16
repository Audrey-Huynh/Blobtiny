using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindFirstObjectByType<PlayerController>();

        Debug.Log("Hi");
        Debug.Log("LimbCollision script found PlayerController: " + (playerController.gameObject.name));
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isGrounded = true;
        Debug.Log("Landed!");
    }
}
