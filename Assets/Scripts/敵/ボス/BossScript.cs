using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    // ダメージの入った数
    public static int bossHitCount = 0;

    private void Update()
    {
        // 五回跳ね返すまで
        if (bossHitCount <= 4)
        {
            // ボスの斜め移動（ループ）
            var amplitude = 5; // 振幅
            var period = 3; // 一往復する周期（秒）
            var t = 4 * amplitude * Time.time / period; // 時間の進行速度を調整

            // 指定された振幅と周期のPingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y座標を往復させて上下運動させる
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }
        // 五回以上１０回以下跳ね返したら
        if (bossHitCount >= 5 && bossHitCount <= 10)
        {
            // ボスの斜め移動（ループ）
            var amplitude = 4; // 振幅
            var period = 2; // 一往復する周期（秒）
            var t = 4 * amplitude * Time.time / period; // 時間の進行速度を調整

            // 指定された振幅と周期のPingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y座標を往復させて上下運動させる
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }
        // 10回以上15回以下跳ね返したら
        if (bossHitCount >= 11 && bossHitCount <= 15)
        {
            // ボスの斜め移動（ループ）
            var amplitude = 4; // 振幅
            var period = 2; // 一往復する周期（秒）
            var t = 4 * amplitude * Time.time / period; // 時間の進行速度を調整

            // 指定された振幅と周期のPingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y座標を往復させて上下運動させる
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // 弾が跳ね返ると消えてダメージが入る
        if (collision.gameObject.CompareTag("Boss1bullet"))
        {
            // 1ダメージ
            bossHitCount += 1;
            Debug.Log(bossHitCount);
        }
    }

}
