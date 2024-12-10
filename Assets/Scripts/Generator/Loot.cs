using UnityEngine;

public class Loot : SpawnableObject
{
    public ObjectsEnums.ELoot _lootType;
    public float _spawnChance;
    private float _heartSpawnChance = 0.2f;
    private float _chestSpawnChance = 0.2f;
    private float _gunSpawnChance = 0.1f;
    private Mesh _lootMesh;
    private Material _lootMaterial;

    public Loot(ObjectsEnums.ELoot lootType) : base(ObjectsEnums.EObjectTypes.Loot) {
        _lootType = lootType;
        switch (lootType)
        {
            case ObjectsEnums.ELoot.Heart:
                _spawnChance = _heartSpawnChance;
                //_lootMesh = new Mesh();//insert mesh ref
                _lootMaterial = null;
                break;
            case ObjectsEnums.ELoot.Chest:
                _spawnChance = _chestSpawnChance;
                //_lootMesh = new Mesh();//insert mesh ref
                _lootMaterial = null;
                break;
            case ObjectsEnums.ELoot.Gun:
                _spawnChance = _gunSpawnChance;
                //_lootMesh = new Mesh();//insert mesh ref
                _lootMaterial = null;
                break;
            default:
                break;
        }
    }

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        InitiateLoot();


    }

    private void InitiateLoot()
    {
        this.gameObject.GetComponent<MeshFilter>().mesh = _lootMesh;
        this.gameObject.GetComponent<MeshRenderer>().material = _lootMaterial;
        CapsuleCollider meshCollider = this.gameObject.GetComponent<CapsuleCollider>();
        meshCollider.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
