using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Generator : MonoBehaviour
{
    //FRANEK
    public static Generator Instance;
    //FRANEK


    private ObjectDB _objectDb;
    private List<GameObject> _spawnedObjects; //might be useless
    private float _enemySpawnMultiplier;
    private bool _canSpawnBoss = false;
    private float _spawnDistance;
    private float _spawnTreshold;
    private float _spawnVariation;
    public float _travledDistance;
    private PlayerMovement _playerMovement;

    private Vector3 _previousPlayerPosition;

    //player movement component;
    [SerializeField] private GameObject _00Object;
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private GameObject _objectToSpawnPrefRef;
    [SerializeField] private GameObject _enemy1Ref;
    [SerializeField] private GameObject _enemy2Ref;
    [SerializeField] private GameObject _enemy3Ref;
    [SerializeField] private GameObject _heartRef;
    [SerializeField] private GameObject _chestRef;
    [SerializeField] private GameObject _gunRef;
    [SerializeField] private GameObject _environ1Ref;
    [SerializeField] private GameObject _bossRef;

    void Start()
    {
        //FRANEK
        Instance = this;
        //FRANEK
        _playerMovement = _playerRef.GetComponent<PlayerMovement>();
        _objectDb = new ObjectDB();
        _spawnDistance = 30f;
        _spawnTreshold = 40f; //enemies spawn around 0.85 and 1.2 units traveled of this value
        _canSpawnBoss = false;
        _enemySpawnMultiplier = 1f;
        _previousPlayerPosition = _00Object.transform.position;
        _spawnVariation = 15f;
    }

    void Update()
    {
        if (_travledDistance >= _spawnTreshold * Random.Range(0.85f, 1.2f))
        {
            _travledDistance = 0f;
            SpawnEntity();
        }
        else
        {
            _travledDistance +=
                Mathf.Abs
                    ((_previousPlayerPosition.x - _00Object.transform.position.x)) +
                Mathf.Abs
                (
                    (_previousPlayerPosition.z - _00Object.transform.position.z));
            _previousPlayerPosition = _00Object.transform.position;
        }

        //CalcSpawnTransform();
    }

    private void SpawnEntity()
    {
        switch (Random.Range(1, 1000))
        {
            case <= 199:
                RollFromtable(ObjectsEnums.EObjectTypes.Loot);
                break;
            case <= 600:
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
        float newRandom;
        switch (objectType)
        {
            case ObjectsEnums.EObjectTypes.Loot:
                foreach (var loot in _objectDb.lootList)
                {
                    newRandom = Random.Range(0f, 1f);
                    if (loot._spawnChance >= newRandom)
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
                    newRandom = Random.Range(0f, 1f);
                    if (env._spawnChance >= newRandom)
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
                    newRandom = Random.Range(0f, 1f);
                    if (enemy._spawnChance >= newRandom)
                    {
                        if (!_canSpawnBoss && enemy._enemyType == ObjectsEnums.EEnemy.Boss1) break;
                        success = true;
                        _objectDb.enemyList.Remove(enemy);
                        _objectDb.enemyList.Add(enemy);
                        SpawnRolled(enemy);
                        break;
                    }
                }

                break;
            default:
                success = true;
                break;
        }

        if (success == false) RollFromtable(objectType);
    }

    private void SpawnRolled(Enemy enemy)
    {
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject toSpawn = null;
        switch (enemy._enemyType)
        {
            case ObjectsEnums.EEnemy.WeakEnemy:
                toSpawn = _enemy1Ref;
                break;
            case ObjectsEnums.EEnemy.MediumEnemy:
                toSpawn = _enemy2Ref;
                break;
            case ObjectsEnums.EEnemy.HardEnemy:
                toSpawn = _enemy3Ref;
                break;
            case ObjectsEnums.EEnemy.Boss1:
                toSpawn = _bossRef;
                break;
            default:
                toSpawn = _objectToSpawnPrefRef;
                break;
        }

        GameObject newObjectSpawned = Instantiate
        (
            toSpawn,
            spawnTransform,
            new Quaternion()
        );
        newObjectSpawned.AddComponent<Enemy>();
    }


    private void SpawnRolled(Environment environment)
    {
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject toSpawn = null;
        switch (environment._environmentType)
        {
            case ObjectsEnums.EEnvironment.Rock:
                toSpawn = _environ1Ref;
                break;
            default:
                toSpawn = _objectToSpawnPrefRef;
                break;
        }

        GameObject newObjectSpawned = Instantiate
        (
            toSpawn,
            spawnTransform,
            new Quaternion()
        );
        newObjectSpawned.AddComponent<Environment>();
    }

    private void SpawnRolled(Loot loot)
    {
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject toSpawn = null;
        switch (loot._lootType)
        {
            case ObjectsEnums.ELoot.Heart:
                toSpawn = _heartRef;
                break;
            case ObjectsEnums.ELoot.Chest:
                toSpawn = _chestRef;
                break;
            case ObjectsEnums.ELoot.Gun:
                toSpawn = _gunRef;
                break;
            default:
                toSpawn = _objectToSpawnPrefRef;
                break;
        }

        GameObject newObjectSpawned = Instantiate
        (
            toSpawn,
            spawnTransform,
            new Quaternion()
        );
        newObjectSpawned.AddComponent<Loot>();
    }

    private Vector3 CalcSpawnTransform()
    {
        Vector3 movementDirection = _playerMovement.GetMovementVector().normalized;
        return
            transform.position +
            movementDirection * _spawnDistance +
            _spawnVariation * new Vector3(
                Random.Range(-1f, 1f),
                0,
                Random.Range(-1f, 1f)
            );
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