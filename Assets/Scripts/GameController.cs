using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
    // canvas���\���ɂ���
      canvas.enabled = false;

    }

    // �S�[������
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g��Goal�Ȃ�
        if (collision.gameObject.CompareTag("player"))
        {
            // canvas��\������
            canvas.enabled = true;

        
        }
    }


}
