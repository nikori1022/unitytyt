using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        // Particle System �R���|�[�l���g���擾
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // AWD�L�[�̂����ꂩ��������Ă��邩�`�F�b�N
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            // �p�[�e�B�N���V�X�e�������ɍĐ����łȂ���΍Đ�����
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            // �L�[�������ꂽ��A�p�[�e�B�N���V�X�e�����~����
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}