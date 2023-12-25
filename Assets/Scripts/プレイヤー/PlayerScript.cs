using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sceneの操作
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
    // ゲームマネージャー
    private GameManager gameManager;
    //　キャラクターを操作可能かどうか
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
        // プレイヤーのワールド座標
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
        // 接触したオブジェクトのタグがRetryBoardかを比較
        if (other.gameObject.CompareTag("RetryBoard"))
        {
            // Sceneを再読み込み
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
        // 敵に当たったら跳ねる（雑魚１）
        if (collision.gameObject.tag == "enemy")
        {
            float playerRotNum = rot.y;
           
            if (JumpFlag == true)
            {
                rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                if (playerRotNum == 90)
                {
                    // 左に跳ねる
                    rb.AddForce(Vector3.left * playerHitLeft, ForceMode.Impulse);
                    MoveSet();
                }
                if (playerRotNum == -90)
                {
                    // 左に跳ねる
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
