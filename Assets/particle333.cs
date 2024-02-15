using UnityEngine;

public class particle333 : MonoBehaviour
{
    ParticleSystem particleSystem;

    void Start()
    {
        // Get the Particle System component
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Check if the NumPad7 key is being pressed
        if (Input.GetKey(KeyCode.Keypad7))
        {
            // If the particle system is not playing, play it
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            // If the particle system is playing and the NumPad7 key is not being pressed, stop it
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}