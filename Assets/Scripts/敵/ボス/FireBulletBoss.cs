using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBoss : MonoBehaviour
{
    public BossScript bossScript;

    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾2の発射場所")]
    private GameObject firingPoint2;
    

    [SerializeField]
    [Tooltip("弾")]
    public GameObject BossB;

    private int count;

    // Update is called once per frame
    void Update()
    {
        // 1フレームカウント
        count += 1;
        // 450フレームで一回攻撃する
        if (count % 450 == 0)
        {
           LauncherShot();
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    void LauncherShot()
    {
        int bCount;     // ボスのHPを削った数
        bCount = BossScript.bossHitCount;
        Debug.Log(bCount); 

        // 弾を発射する場所を取得
        GameObject newBall = Instantiate(BossB, firingPoint.transform.position, Quaternion.identity);
        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();
        // 五回当てるまで
        if (bCount <= 4)
        {
            // 弾速は自由に設定
            ballRb.AddForce(transform.forward * 750);
        }
        // 五回以上１０回以下当てた場合
        if (bCount >= 5 && bCount <= 9)
        {
            // 弾速は自由に設定
            ballRb.AddForce(transform.forward * 1500);
        }
        // 10回以上１5回以下当てた場合（最終形態）
        if (bCount >= 10 && bCount <= 14)
        {
            // 弾速は自由に設定
            ballRb.AddForce(transform.forward * 1500);
            // 弾を発射する場所を取得
            GameObject newBall2 = Instantiate(BossB, firingPoint2.transform.position, Quaternion.identity);
            Rigidbody ballRb2 = newBall2.GetComponent<Rigidbody>();
            // 弾速は自由に設定
            ballRb2.AddForce(transform.forward * -900);

            Destroy(newBall2, 2.0f);
        }

        // 出現させたボールを3.7秒後に消す
        Destroy(newBall, 3.7f);
    }

}
  