using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{   
    void OnCollisionEnter(Collision collision)
    {
        // ボスの弾に当たったら
        if (collision.gameObject.CompareTag("Boss1bullet"))
        {
            OnDie();    
        }
        // ボスに当たったら
        if (collision.gameObject.CompareTag("Boss"))
        {
            OnDie();
        }
        // プレイヤーに当たったら
        if (collision.gameObject.CompareTag("player"))
        {
            var status = collision.gameObject.GetComponent<CharacterStatusScript>();
            status.Damage(70);
        }
    }
    
    void OnDie()
    {
        // ボスの弾が消える
        Destroy(gameObject);
    }
}
