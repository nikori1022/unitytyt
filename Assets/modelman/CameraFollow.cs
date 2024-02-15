using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーオブジェクト

    public float smoothSpeed = 0.125f; // カメラの移動速度

    public Vector3 offset; // カメラとプレイヤーの距離

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player); // プレイヤーを向く
    }
}