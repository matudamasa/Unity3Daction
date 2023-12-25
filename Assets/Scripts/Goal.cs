using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //ƒvƒŒƒCƒ„[‚ª“–‚½‚è”»’è‚É“ü‚Á‚½‚Ìˆ—
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            //gameManager.NextStage();
        }
    }
}
