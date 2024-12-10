using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : SpawnableObject
{
    public ObjectsEnums.EEnemy _enemyType;
    public float _spawnChance;
    private bool _isBoss = false;
    private float _timer;
    private float _weakSpawnChance = 0.7f;
    private float _mediumSpawnChance = 0.4f;
    private float _hardSpawnChance = 0.15f;
    private float _bossSpawnChance = 0.03f;
    private string _pathToChariotController = "Assets/Models/Chariot";

    public Enemy(ObjectsEnums.EEnemy enemyType) : base(ObjectsEnums.EObjectTypes.Enemy)
    {
        _enemyType = enemyType;
        switch (enemyType)
        {
            case ObjectsEnums.EEnemy.WeakEnemy:
                _spawnChance = _weakSpawnChance;
                break;
            case ObjectsEnums.EEnemy.MediumEnemy:
                _spawnChance = _mediumSpawnChance;
                break;
            case ObjectsEnums.EEnemy.HardEnemy:
                _spawnChance = _hardSpawnChance;
                break;
            case ObjectsEnums.EEnemy.Boss1:
                _spawnChance = _bossSpawnChance;
                //more init for boss
                break;
            default: break;
        }
    }
    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
