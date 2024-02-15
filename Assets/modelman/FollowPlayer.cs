using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public float distance = 10.0f;
    private Vector3 offset;

    void Start()
    {
        //�v���C���[�̏����ʒu�Ƃ̃I�t�Z�b�g���v�Z����
        offset = transform.position - player.position;
    }

    void Update()
    {
        //�v���C���[�̈ʒu�ɃI�u�W�F�N�g���X���[�Y�Ɉړ�����
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.y += distance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //�J�������v���C���[�̕����Ɍ�����
        transform.LookAt(player);
    }
}