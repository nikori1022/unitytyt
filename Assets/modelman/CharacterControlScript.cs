using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterControlScript : MonoBehaviour
{
    public float MoveSpeed; // �ړ����x
    public float JumpForce; // �W�����v��
    public float RotationSpeed; // ��]���x
    public float speed = 1.0f;
    public Transform target; // �����������I�u�W�F�N�g���w��
    public PhotonView myPV;
    public PhotonTransformView myPTV;
    private Camera mainCam;
    public CharacterController controller;

    private Rigidbody _rigidbody;
    private bool _isRotated180 = false; // �I�u�W�F�N�g��180�x��]���Ă��邩�̃t���O

    private void Start()
    {
        if(myPV.isMine)
        {
            mainCam = Camera.main;
           
        }
        // Rigidbody���擾����
        if (target != null) // targetTransform���ݒ肳��Ă��邩�m�F
        {
            _rigidbody = target.GetComponent<Rigidbody>();
            if (_rigidbody == null) // Rigidbody��������Ȃ��ꍇ�̓G���[���b�Z�[�W��\��
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
        if (target == null || _rigidbody == null) return; // �K�v�ȃR���|�[�l���g���Ȃ��ꍇ�͏������s��Ȃ�

        // �e���L�[��2�������ꂽ�Ƃ��̏���
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            // _isRotated180�̒l�𔽓]������
            _isRotated180 = !_isRotated180;
            // Y���ɑ΂���180�x�܂���0�x�ɉ�]������
            target.eulerAngles = new Vector3(0, _isRotated180 ? 180 : 0, 0);
        }

        // �ړ��ʂ��v�Z����
        float verticalInput = Input.GetAxis("Vertical"); // �O������̓���
        float horizontalInput = Input.GetAxis("Horizontal"); // ���E�����̓���

        // Y����180�x��]���Ă���ꍇ�A���͂𔽓]
        if (_isRotated180)
        {
            verticalInput *= -1;
            horizontalInput *= -1;
        }

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // �ړ�����
        _rigidbody.AddForce(moveDirection * MoveSpeed, ForceMode.Force);

        // �W�����v����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        // �e���L�[��4�������ꂽ�ꍇ�AX���̈ʒu�𑝉�������
        if (Input.GetKey(KeyCode.Keypad4))
        {
            float moveAmount = _isRotated180 ? -speed : speed;
            target.position += new Vector3(0, 0, moveAmount * Time.deltaTime);
        }

        // �e���L�[��6�������ꂽ�ꍇ�AX���̈ʒu������������
        if (Input.GetKey(KeyCode.Keypad6))
        {
            float moveAmount = _isRotated180 ? speed : -speed;
            target.position += new Vector3(0, 0, moveAmount * Time.deltaTime);
        }
        controller.Move(moveDirection * Time.deltaTime);
        
        Vector3 velocity = controller.velocity;
        myPTV.SetSynchronizedValues(velocity, 0);
    }

    //�ړ�����֐�MOOVE�Ɉړ��n�͂��ׂĈڂ��āA
    //Update �ɃI�����C���n������āAWeb�ɏ���Ă��ɑΉ���������

}


//�^�C�}�[�̎���
//�p�[�e�B�N���̓����蔻��
//�I�u�W�F�N�g�𐁂���΂�����