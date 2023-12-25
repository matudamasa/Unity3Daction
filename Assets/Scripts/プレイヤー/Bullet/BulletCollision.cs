using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //�ڐG�����I�u�W�F�N�g�̃^�O��"boss"��"Boss1bullet"�̂Ƃ�
        if (other.CompareTag("Boss") || other.CompareTag("Boss1bullet"))
        {
            //�I�u�W�F�N�g������
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //�ڐG�����I�u�W�F�N�g�̃^�O��"boss"��"Boss1bullet"�̂Ƃ�
        if (other.gameObject.tag == "Boss")
        {
            //�I�u�W�F�N�g������
            Destroy(this.gameObject);
        }
    }
}
