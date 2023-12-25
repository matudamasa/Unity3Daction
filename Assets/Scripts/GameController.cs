using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
    // canvasを非表示にする
      canvas.enabled = false;

    }

    // ゴール処理
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがGoalなら
        if (collision.gameObject.CompareTag("player"))
        {
            // canvasを表示する
            canvas.enabled = true;

        
        }
    }


}
