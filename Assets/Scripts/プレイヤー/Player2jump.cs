using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2jump : MonoBehaviour
{
    int jumpCount = 0;
    public Rigidbody rb;
 

    void Update()
    {
        if (jumpCount < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0f, 1200f, 0f);
            jumpCount++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }
}