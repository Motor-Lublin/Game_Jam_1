using Unity.VisualScripting;
using UnityEngine;

public class PickItUp : MonoBehaviour
{
    [SerializeField] private ObjectsEnums.ELoot _lootType;
    [SerializeField] private GameObject _treasureRef;
    private GameObject _playerTarget;
    private bool _destroyPending;


    void Awake()
    {
        //FRANEK
        _playerTarget = GameObject.FindGameObjectWithTag("Player");
        //FRANEK
        if (_lootType == null) _lootType = ObjectsEnums.ELoot.Heart;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            switch (_lootType)
            {
                case ObjectsEnums.ELoot.Heart:
                    if (Vector3.Distance(other.transform.position, transform.position) > 10f)
                        break;
                    _playerTarget.GetComponent<healthSystem>().HealUp(1);
                    Destroy(gameObject);
                    break;
                default: break;
                
            }
        }
    }

    void OnDestroy()
    {
        if (!_destroyPending&& _lootType != ObjectsEnums.ELoot.Chest)
        {
            if (_treasureRef != null)
                Instantiate(_treasureRef, transform.position, transform.rotation);
            _destroyPending = true;
        }

    }
}
