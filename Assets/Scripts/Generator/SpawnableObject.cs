using Unity.VisualScripting;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    public ObjectsEnums.EObjectTypes _objectType;
    public float _typeSpawnChance;
    private Movable _movableRef;
    private float _despawnTreshold;

    public SpawnableObject(ObjectsEnums.EObjectTypes objectType)
    {
        _despawnTreshold = 20f;
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
        _movableRef = GetComponent<Movable>();
        _movableRef.SetCenterObject(GameObject.FindWithTag("Player"));
        _movableRef.AddToMovableList();

    }

    void OnTriggerExit(Collider other)
    {
        if (gameObject.IsDestroyed()) return;
        if (other.GetType() != typeof(SphereCollider)) return;
        if (_movableRef!=null)
            _movableRef.RemoveFromMovableList(transform);
        Destroy(gameObject);
    }
    void Update()
    {
        
    }

    void OnDestroy()
    {

    }
    //on destroy remove from movable list
}
