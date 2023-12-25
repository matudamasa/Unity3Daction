using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    private float MoveSpeed = 5.0f;
    private int direction = 1;
    void FixedUpdate()
    {
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
            
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, 3.2f, 0);
    }
    private Transform _transform;

    // 前フレームのワールド位置
    private Vector3 _prevPosition;

    private void Start()
    {
        _transform = transform;

        _prevPosition = _transform.position;
    }

    private void Update()
    {
        // 現在フレームのワールド位置
        var position = _transform.position;

        // 移動量を計算
        var delta = position - _prevPosition;

        // 次のUpdateで使うための前フレーム位置更新
        _prevPosition = position;

        // 静止している状態だと、進行方向を特定できないため回転しない
        if (delta == Vector3.zero)
            return;

        // 進行方向（移動量ベクトル）に向くようなクォータニオンを取得
        var rotation = Quaternion.LookRotation(delta, Vector3.up);

        // オブジェクトの回転に反映
        _transform.rotation = rotation;
    }
}