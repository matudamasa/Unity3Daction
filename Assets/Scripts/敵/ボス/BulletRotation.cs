using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{   
    void OnCollisionEnter(Collision collision)
    {
        // �{�X�̒e�ɓ���������
        if (collision.gameObject.CompareTag("Boss1bullet"))
        {
            OnDie();    
        }
        // �{�X�ɓ���������
        if (collision.gameObject.CompareTag("Boss"))
        {
            OnDie();
        }
        // �v���C���[�ɓ���������
        if (collision.gameObject.CompareTag("player"))
        {
            var status = collision.gameObject.GetComponent<CharacterStatusScript>();
            status.Damage(70);
        }
    }
    
    void OnDie()
    {
        // �{�X�̒e��������
        Destroy(gameObject);
    }
}
