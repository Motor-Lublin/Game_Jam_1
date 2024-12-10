using UnityEngine;

public class Environment : SpawnableObject
{
    public ObjectsEnums.EEnvironment _environmentType;
    public float _spawnChance;
    private float _rockSpawnChance = 0.8f;

    public Environment(ObjectsEnums.EEnvironment environmentType) : base(ObjectsEnums.EObjectTypes.Environment)
    {
        _environmentType = environmentType;
        switch (environmentType)
        {
            case ObjectsEnums.EEnvironment.Rock:
                _spawnChance = _rockSpawnChance;
                break;
            default: break;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
