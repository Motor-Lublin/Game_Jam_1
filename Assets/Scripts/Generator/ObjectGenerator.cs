using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Generator : MonoBehaviour
{
    private ObjectDB _objectDb = new ObjectDB();
    private List<GameObject> _spawnedObjects;//might be useless
    private float _enemySpawnMultiplier = 1f;
    private bool _canSpawnBoss = false;
    private float _spawnDistance = 300f;
    private float _spawnTreshold = 200f;
    private float _travledDistance = 0f;
    //player movement component;
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private GameObject _ObjectToSpawnPrefRef;


    void Start()
    {
        //player movement component = _playerRef.getComponent<MovementComponent>
    }
    void Update()
    {
        if (_travledDistance >= _spawnTreshold * Random.Range(0.85f, 1.2f))
        {
            _travledDistance = 0f;
            SpawnEntity();

        }
    }

    private void SpawnEntity()
    {
        switch (Random.Range(1, 1000))
        {
            case <= 199:
                RollFromtable(ObjectsEnums.EObjectTypes.Loot);
                break;
            case <= 699:
                RollFromtable(ObjectsEnums.EObjectTypes.Environment);
                break;
            case <= 1000:
                RollFromtable(ObjectsEnums.EObjectTypes.Enemy);
                if (Random.Range(1, 1000) >= 900) RollFromtable(ObjectsEnums.EObjectTypes.Loot);
                break;
            default: break;
        }
    }

    private void RollFromtable(ObjectsEnums.EObjectTypes objectType)
    {
        bool success = false;
        switch (objectType)
        {
            case ObjectsEnums.EObjectTypes.Loot:
                foreach (var loot in _objectDb.lootList)
                {
                    if (loot._spawnChance >= Random.Range(0f, 1f))
                    {
                        success = true;
                        _objectDb.lootList.Remove(loot);
                        _objectDb.lootList.Add(loot);
                        SpawnRolled(loot);
                        break;
                    }
                }
                break;
            case ObjectsEnums.EObjectTypes.Environment:
                foreach (var env in _objectDb.environmentList)
                {
                    if (env._spawnChance >= Random.Range(0f, 1f))
                    {
                        success = true;
                        _objectDb.environmentList.Remove(env);
                        _objectDb.environmentList.Add(env);
                        SpawnRolled(env);
                        break;
                    }
                }
                break;
            case ObjectsEnums.EObjectTypes.Enemy:
                foreach (var enemy in _objectDb.enemyList)
                {
                    if (enemy._spawnChance >= Random.Range(0f, 1f))
                    {
                        success = true;
                        _objectDb.enemyList.Remove(enemy);
                        _objectDb.enemyList.Add(enemy);
                        SpawnRolled(enemy);
                        break;
                    }
                }
                break;
            default: success = true;
                break;
        }
        if (success == false) RollFromtable(objectType);
    }

    private void SpawnRolled(Enemy enemy)
    {
        Transform spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate(_ObjectToSpawnPrefRef, spawnTransform);
        newObjectSpawned.AddComponent<Enemy>();
    }


    private void SpawnRolled(Environment loot)
    {
        Transform spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate(_ObjectToSpawnPrefRef, spawnTransform);
        newObjectSpawned.AddComponent<Environment>();
    }

    private void SpawnRolled(Loot loot)
    {
        Transform spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate(_ObjectToSpawnPrefRef, spawnTransform);
        newObjectSpawned.AddComponent<Loot>();
    }

    private Transform CalcSpawnTransform()
    {
        Vector2 movementDirection = Vector2.zero;//_movementComponentRef.GetMovementDirection()
        Vector3 playerPosition = _playerRef.transform.position;
        while (movementDirection.Equals(Vector2.zero))
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        float angle = math.atan2(movementDirection.x, movementDirection.y) * 180 / Mathf.PI;
        float x = playerPosition.x + (_spawnDistance * Mathf.Cos(angle / (180f / Mathf.PI)));
        float y = playerPosition.y;
        float z = playerPosition.z + (_spawnDistance * Mathf.Sin(angle / (180f / Mathf.PI)));
        Transform spawnTransform = _playerRef.transform;
        spawnTransform.position = new Vector3(x, y, z);
        return spawnTransform;
    }

    public void AddBossToSpawnPool(bool addOrNot)
    {
        _canSpawnBoss = addOrNot;
    }

    public void SetEnemyMultiplier(float newMultiplier)
    {
        _enemySpawnMultiplier = newMultiplier;
    }

    public void AddToEnemyMultiplier(float addThis)
    {
        _enemySpawnMultiplier += addThis;
    }

    public void ReduceFromEnemyMultiplier(float subThis)
    {
        _enemySpawnMultiplier -= subThis;
    }


    
}
