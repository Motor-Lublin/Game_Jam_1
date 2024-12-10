using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Generator : MonoBehaviour
{
    private ObjectDB _objectDb;
    private List<GameObject> _spawnedObjects;//might be useless
    private float _enemySpawnMultiplier;
    private bool _canSpawnBoss = false;
    private float _spawnDistance;
    private float _spawnTreshold;
    public float _travledDistance;
    private PlayerMovement _playerMovement;

    private Vector3 _previousPlayerPosition;
    //player movement component;
    [SerializeField] private GameObject _00Object;
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private GameObject _ObjectToSpawnPrefRef;
    [SerializeField] private GameObject _Enemy1Ref;

    void Start()
    {
        _playerMovement = _playerRef.GetComponent<PlayerMovement>();
        _objectDb = new ObjectDB();
        _spawnDistance = 25f;
        _spawnTreshold = 50f;
        _canSpawnBoss = false;
        _enemySpawnMultiplier = 1f;
        _previousPlayerPosition = _00Object.transform.position;
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
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate
        (
            _Enemy1Ref,
            spawnTransform,
            new Quaternion()
        );
        newObjectSpawned.AddComponent<Enemy>();
    }


    private void SpawnRolled(Environment loot)
    {
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate
        (
            _ObjectToSpawnPrefRef,
            spawnTransform,
            new Quaternion()
        );
        newObjectSpawned.AddComponent<Environment>();
    }

    private void SpawnRolled(Loot loot)
    {
        Vector3 spawnTransform = CalcSpawnTransform();
        GameObject newObjectSpawned = Instantiate
            (
                _ObjectToSpawnPrefRef, 
                spawnTransform, 
                new Quaternion()
                );
        newObjectSpawned.AddComponent<Loot>();
    }

    private Vector3 CalcSpawnTransform()
    {
        Vector3 movementDirection = _playerMovement.GetMovementVector().normalized;
        return transform.position + movementDirection * _spawnDistance;
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
