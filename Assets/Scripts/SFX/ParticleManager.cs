using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField] List<GameObject> particlesList = new List<GameObject>();

    private void Start()
    {
        Instance = this;
    }

    public void ShotgunParticles(int index, Transform particleHolder)
    {
        Instantiate(particlesList[index], particleHolder);
    }

}
