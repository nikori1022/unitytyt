using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // �Ǐ]����^�[�Q�b�g

    public float smoothSpeed = 0.125f; // �J�����̒Ǐ]���x

    public Vector3 offset; // �Ǐ]���̃I�t�Z�b�g

    public float horizontalSpeed = 2.0f; // ���������̈ړ����x
    public float verticalSpeed = 2.0f; // ���������̈ړ����x

    private void Start()
    {
        // �^�[�Q�b�g���ݒ肳��Ă��Ȃ��ꍇ�͌x����\������
        if (target == null)
        {
            Debug.LogWarning("Target not set for CameraFollow script.");
            return;
        }
    }

    private void LateUpdate()
    {
        // �^�[�Q�b�g���ݒ肳��Ă��Ȃ��ꍇ�͉������Ȃ�
        if (target == null)
        {
            return;
        }

        // ���L�[�̓��͂ɉ����ăJ�������ړ�����
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

        // �J�����̈ʒu�����炩�ɒǏ]������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // �J�����̒����_���^�[�Q�b�g�Ɍ�����
        transform.LookAt(target);
    }
}