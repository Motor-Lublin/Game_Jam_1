using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    public ObjectsEnums.EObjectTypes _objectType;
    public float _typeSpawnChance;

    public SpawnableObject(ObjectsEnums.EObjectTypes objectType)
    {
        _objectType = objectType;
        switch (objectType)
        {
            case ObjectsEnums.EObjectTypes.Loot:
                _typeSpawnChance = 0.1f;
                break;
            case ObjectsEnums.EObjectTypes.Environment:
                _typeSpawnChance = 0.7f;
                break;
            case ObjectsEnums.EObjectTypes.Enemy:
                _typeSpawnChance = 0.2f;
                break;
            default: break;
        }
    }

    void Start()
    {
        Movable movableRef = GetComponent<Movable>();
        movableRef.SetCenterObject(GameObject.FindWithTag("Player"));
        movableRef.AddToMovableList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //on destroy remove from movable list
}
