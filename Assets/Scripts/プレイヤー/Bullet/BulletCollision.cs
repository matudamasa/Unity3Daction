using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"boss"か"Boss1bullet"のとき
        if (other.CompareTag("Boss") || other.CompareTag("Boss1bullet"))
        {
            //オブジェクトを消す
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトのタグが"boss"か"Boss1bullet"のとき
        if (other.gameObject.tag == "Boss")
        {
            //オブジェクトを消す
            Destroy(this.gameObject);
        }
    }
}
