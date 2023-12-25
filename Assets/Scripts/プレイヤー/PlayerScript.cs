using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scene�̑���
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;
    private float speed = 10.0f;
    public float JumpPower = 100;
    public float playerHitRight = 10.0f;
    public float playerHitLeft = -10.0f;
    public bool JumpFlag = false;

    int MoveFlag = 0;
    public Rigidbody rb;
    // �Q�[���}�l�[�W���[
    private GameManager gameManager;
    //�@�L�����N�^�[�𑀍�\���ǂ���
    private bool canControl;

    Vector3 rot = Vector3.zero;
    // Start is called before the first frame update

    // Update is called once per frame

    void Start()
    {
      
    }
    void Update()
    {
        Move();
        Rotation();
        Camera.transform.position = transform.position;
      
    }

    void Move()
    {
        // �v���C���[�̃��[���h���W
        Vector3 pos = transform.position;

        rot = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            rot.y = 90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            rot.y = -90;
            MoveSet();
        }
    }
    void MoveSet()
    {
        transform.eulerAngles = Camera.transform.eulerAngles + rot;
    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -RotationSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed;
        }

        Camera.transform.eulerAngles += speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // �ڐG�����I�u�W�F�N�g�̃^�O��RetryBoard�����r
        if (other.gameObject.CompareTag("RetryBoard"))
        {
            // Scene���ēǂݍ���
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.gameObject.tag == "Goal")
        {
            MoveFlag = 1;
            if (MoveFlag == 1)
            {
                transform.position = new Vector3(1190, 4, 0);

                MoveFlag = 0;
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        // �G�ɓ��������璵�˂�i�G���P�j
        if (collision.gameObject.tag == "enemy")
        {
            float playerRotNum = rot.y;
           
            if (JumpFlag == true)
            {
                rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                if (playerRotNum == 90)
                {
                    // ���ɒ��˂�
                    rb.AddForce(Vector3.left * playerHitLeft, ForceMode.Impulse);
                    MoveSet();
                }
                if (playerRotNum == -90)
                {
                    // ���ɒ��˂�
                    rb.AddForce(Vector3.right * playerHitRight, ForceMode.Impulse);
                    MoveSet();
                }
            }
        
        }

        if (collision.gameObject.tag == "Ground")
        {
            JumpFlag = true;
        }
    }

}
