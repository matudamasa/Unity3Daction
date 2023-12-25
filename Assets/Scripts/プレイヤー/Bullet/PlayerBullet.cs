using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int BulletTime;
    int BulletFlag = 0; // 0���Ă�/ 1���ĂȂ�

    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 80f;
    private int count;

    // Update is called once per frame
    void Update()
    {
        
        count++;
        if (BulletFlag == 0 || count >= 150)
        {
            // �X�y�[�X�L�[�������ꂽ���𔻒�
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // �e�𔭎˂���
                LauncherShot();
                BulletFlag = 1;
                count = 0;
            }
        }
        
    }

    /// <summary>
	/// �e�̔���
	/// </summary>
    private void LauncherShot()
    {
        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // �o���������{�[����forward(z������)
        Vector3 direction = newBall.transform.forward;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.5�b��ɏ���
        Destroy(newBall, 0.2f);
    }

}