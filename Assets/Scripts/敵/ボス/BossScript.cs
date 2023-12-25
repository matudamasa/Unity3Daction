using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    // �_���[�W�̓�������
    public static int bossHitCount = 0;

    private void Update()
    {
        // �܉񒵂˕Ԃ��܂�
        if (bossHitCount <= 4)
        {
            // �{�X�̎΂߈ړ��i���[�v�j
            var amplitude = 5; // �U��
            var period = 3; // �ꉝ����������i�b�j
            var t = 4 * amplitude * Time.time / period; // ���Ԃ̐i�s���x�𒲐�

            // �w�肳�ꂽ�U���Ǝ�����PingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y���W�����������ď㉺�^��������
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }
        // �܉�ȏ�P�O��ȉ����˕Ԃ�����
        if (bossHitCount >= 5 && bossHitCount <= 10)
        {
            // �{�X�̎΂߈ړ��i���[�v�j
            var amplitude = 4; // �U��
            var period = 2; // �ꉝ����������i�b�j
            var t = 4 * amplitude * Time.time / period; // ���Ԃ̐i�s���x�𒲐�

            // �w�肳�ꂽ�U���Ǝ�����PingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y���W�����������ď㉺�^��������
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }
        // 10��ȏ�15��ȉ����˕Ԃ�����
        if (bossHitCount >= 11 && bossHitCount <= 15)
        {
            // �{�X�̎΂߈ړ��i���[�v�j
            var amplitude = 4; // �U��
            var period = 2; // �ꉝ����������i�b�j
            var t = 4 * amplitude * Time.time / period; // ���Ԃ̐i�s���x�𒲐�

            // �w�肳�ꂽ�U���Ǝ�����PingPong
            var value = Mathf.PingPong(t, 2 * amplitude) - amplitude;
            // y���W�����������ď㉺�^��������
            transform.localPosition = new Vector3(value + 1375, value + 10, 0);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // �e�����˕Ԃ�Ə����ă_���[�W������
        if (collision.gameObject.CompareTag("Boss1bullet"))
        {
            // 1�_���[�W
            bossHitCount += 1;
            Debug.Log(bossHitCount);
        }
    }

}
