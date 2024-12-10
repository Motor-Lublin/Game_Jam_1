using Unity.VisualScripting;
using UnityEngine;

public class PickItUp : MonoBehaviour
{
    [SerializeField] private ObjectsEnums.ELoot _lootType;
    private GameObject _playerTarget;

    void Start()
    {
        _playerTarget = GameObject.FindGameObjectWithTag("Player");
        if (_lootType == null) _lootType = ObjectsEnums.ELoot.Heart;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _playerTarget)
        {
            if (Vector3.Distance(other.transform.position, transform.position) > 10f) return;
            switch (_lootType)
            {
                case ObjectsEnums.ELoot.Heart:
                    _playerTarget.GetComponent<healthSystem>().HealUp(2);
                    break;
                default: break;
                
            }
        Destroy(gameObject);
        }
    }
}
