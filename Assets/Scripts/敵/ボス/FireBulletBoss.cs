using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBoss : MonoBehaviour
{
    public BossScript bossScript;

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e2�̔��ˏꏊ")]
    private GameObject firingPoint2;
    

    [SerializeField]
    [Tooltip("�e")]
    public GameObject BossB;

    private int count;

    // Update is called once per frame
    void Update()
    {
        // 1�t���[���J�E���g
        count += 1;
        // 450�t���[���ň��U������
        if (count % 450 == 0)
        {
           LauncherShot();
        }
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    void LauncherShot()
    {
        int bCount;     // �{�X��HP���������
        bCount = BossScript.bossHitCount;
        Debug.Log(bCount); 

        // �e�𔭎˂���ꏊ���擾
        GameObject newBall = Instantiate(BossB, firingPoint.transform.position, Quaternion.identity);
        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();
        // �܉񓖂Ă�܂�
        if (bCount <= 4)
        {
            // �e���͎��R�ɐݒ�
            ballRb.AddForce(transform.forward * 750);
        }
        // �܉�ȏ�P�O��ȉ����Ă��ꍇ
        if (bCount >= 5 && bCount <= 9)
        {
            // �e���͎��R�ɐݒ�
            ballRb.AddForce(transform.forward * 1500);
        }
        // 10��ȏ�P5��ȉ����Ă��ꍇ�i�ŏI�`�ԁj
        if (bCount >= 10 && bCount <= 14)
        {
            // �e���͎��R�ɐݒ�
            ballRb.AddForce(transform.forward * 1500);
            // �e�𔭎˂���ꏊ���擾
            GameObject newBall2 = Instantiate(BossB, firingPoint2.transform.position, Quaternion.identity);
            Rigidbody ballRb2 = newBall2.GetComponent<Rigidbody>();
            // �e���͎��R�ɐݒ�
            ballRb2.AddForce(transform.forward * -900);

            Destroy(newBall2, 2.0f);
        }

        // �o���������{�[����3.7�b��ɏ���
        Destroy(newBall, 3.7f);
    }

}
  