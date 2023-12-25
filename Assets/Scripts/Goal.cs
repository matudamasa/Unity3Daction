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

    //プレイヤーが当たり判定に入った時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            //gameManager.NextStage();
        }
    }
}
