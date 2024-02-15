using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public float distance = 10.0f;
    private Vector3 offset;

    void Start()
    {
        //プレイヤーの初期位置とのオフセットを計算する
        offset = transform.position - player.position;
    }

    void Update()
    {
        //プレイヤーの位置にオブジェクトをスムーズに移動する
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.y += distance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //カメラをプレイヤーの方向に向ける
        transform.LookAt(player);
    }
}