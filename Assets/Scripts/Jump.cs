using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    bool jumpRequest;

    public PlayerController playerController;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerController.isGrounded == true && playerController.left == false && playerController.right == false)
        {
            jumpRequest = true;
        }
    }
    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }
}
