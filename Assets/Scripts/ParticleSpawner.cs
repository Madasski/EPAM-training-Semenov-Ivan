using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    private Character _character;

    private void OnEnable()
    {
        _character = GetComponent<Character>();

        if (Settings.ShowBlood)
        {
            _character.Health.OnHealthChange += SpawnParticles;
        }
    }

    private void SpawnParticles(float i, float f)
    {
        ParticleSystem.Play();
    }
}