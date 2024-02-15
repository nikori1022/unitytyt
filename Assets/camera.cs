using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // 追従するターゲット

    public float smoothSpeed = 0.125f; // カメラの追従速度

    public Vector3 offset; // 追従時のオフセット

    public float horizontalSpeed = 2.0f; // 水平方向の移動速度
    public float verticalSpeed = 2.0f; // 垂直方向の移動速度

    private void Start()
    {
        // ターゲットが設定されていない場合は警告を表示する
        if (target == null)
        {
            Debug.LogWarning("Target not set for CameraFollow script.");
            return;
        }
    }

    private void LateUpdate()
    {
        // ターゲットが設定されていない場合は何もしない
        if (target == null)
        {
            return;
        }

        // 矢印キーの入力に応じてカメラを移動する
        float horizontalInput = 0.0f;
        float verticalInput = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1.0f;
        }

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.x += horizontalInput * horizontalSpeed * Time.deltaTime;
        desiredPosition.y += verticalInput * verticalSpeed * Time.deltaTime;

        // カメラの位置を滑らかに追従させる
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // カメラの注視点をターゲットに向ける
        transform.LookAt(target);
    }
}