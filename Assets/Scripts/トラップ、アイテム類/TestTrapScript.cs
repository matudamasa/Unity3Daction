using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrapScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            var status = other.GetComponent<CharacterStatusScript>();
            status.Damage(1);
        }
  
    }
}