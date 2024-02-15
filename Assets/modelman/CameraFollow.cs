using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // �v���C���[�I�u�W�F�N�g

    public float smoothSpeed = 0.125f; // �J�����̈ړ����x

    public Vector3 offset; // �J�����ƃv���C���[�̋���

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player); // �v���C���[������
    }
}