using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // 40É_ÉÅÅ[ÉWì¸ÇÈ
            var status = collision.gameObject.GetComponent<CharacterStatusScript>();
            status.Damage(40);
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            OnDie();
        }
    }

    void OnDie()
    {
        Destroy(gameObject);
    }
}
