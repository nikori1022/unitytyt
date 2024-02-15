using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        // Particle System コンポーネントを取得
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // AWDキーのいずれかが押されているかチェック
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            // パーティクルシステムが既に再生中でなければ再生する
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            // キーが離されたら、パーティクルシステムを停止する
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}