using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterControlScript : MonoBehaviour
{
    public float MoveSpeed; // 移動速度
    public float JumpForce; // ジャンプ力
    public float RotationSpeed; // 回転速度
    public float speed = 1.0f;
    public Transform target; // 動かしたいオブジェクトを指定
    public PhotonView myPV;
    public PhotonTransformView myPTV;
    private Camera mainCam;
    public CharacterController controller;

    private Rigidbody _rigidbody;
    private bool _isRotated180 = false; // オブジェクトが180度回転しているかのフラグ

    private void Start()
    {
        if(myPV.isMine)
        {
            mainCam = Camera.main;
           
        }
        // Rigidbodyを取得する
        if (target != null) // targetTransformが設定されているか確認
        {
            _rigidbody = target.GetComponent<Rigidbody>();
            if (_rigidbody == null) // Rigidbodyが見つからない場合はエラーメッセージを表示
            {
                Debug.LogError("No Rigidbody component found on the target object.");
            }
        }
        else
        {
            Debug.LogError("Target Transform is not set. Please set the target object in the inspector.");
        }
    }



    private void Update()
    {
        if(!myPV.isMine)
        {
            return;
        }
        if (target == null || _rigidbody == null) return; // 必要なコンポーネントがない場合は処理を行わない

        // テンキーの2が押されたときの処理
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            // _isRotated180の値を反転させる
            _isRotated180 = !_isRotated180;
            // Y軸に対して180度または0度に回転させる
            target.eulerAngles = new Vector3(0, _isRotated180 ? 180 : 0, 0);
        }

        // 移動量を計算する
        float verticalInput = Input.GetAxis("Vertical"); // 前後方向の入力
        float horizontalInput = Input.GetAxis("Horizontal"); // 左右方向の入力

        // Y軸が180度回転している場合、入力を反転
        if (_isRotated180)
        {
            verticalInput *= -1;
            horizontalInput *= -1;
        }

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // 移動する
        _rigidbody.AddForce(moveDirection * MoveSpeed, ForceMode.Force);

        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        // テンキーの4が押された場合、X軸の位置を増加させる
        if (Input.GetKey(KeyCode.Keypad4))
        {
            float moveAmount = _isRotated180 ? -speed : speed;
            target.position += new Vector3(0, 0, moveAmount * Time.deltaTime);
        }

        // テンキーの6が押された場合、X軸の位置を減少させる
        if (Input.GetKey(KeyCode.Keypad6))
        {
            float moveAmount = _isRotated180 ? speed : -speed;
            target.position += new Vector3(0, 0, moveAmount * Time.deltaTime);
        }
        controller.Move(moveDirection * Time.deltaTime);
        
        Vector3 velocity = controller.velocity;
        myPTV.SetSynchronizedValues(velocity, 0);
    }

    //移動する関数MOOVEに移動系はすべて移して、
    //Update にオンライン系をいれて、Webに乗ってるやつに対応させたい

}


//タイマーの実装
//パーティクルの当たり判定
//オブジェクトを吹き飛ばす判定