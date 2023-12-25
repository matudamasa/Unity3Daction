using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpPower = 10;

    public bool JumpFlag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ƒWƒƒƒ“ƒv‚·‚é
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpFlag == true)
            {
                rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpFlag = true;
        }
 
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpFlag = false;
        }
    }

}