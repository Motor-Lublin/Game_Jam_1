using Unity.VisualScripting;
using UnityEngine;

public class LevelUpCards : MonoBehaviour
{
    private bool _destroyPending;
    [SerializeField] private GameObject _treasureRef;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            if (Vector3.Distance(other.transform.position, transform.position) > 3f) return;
            ObjectsEnums.ELevelUpType levelUpType = ObjectsEnums.ELevelUpType.HealthUp; // Hud.PickCard()
            switch (levelUpType)
            {
                case ObjectsEnums.ELevelUpType.HealthUp:
                    other.GetComponent<healthSystem>().AddMaxHealth(2);
                    Destroy(gameObject);
                    break;
            }
        }

        void Start()
        {
        }

        void Update()
        {
        }
        void OnDestroy()
        {
            if (!_destroyPending)
            {
                if (_treasureRef != null)
                    Instantiate(_treasureRef, transform.position, transform.rotation);
                _destroyPending = true;
            }
        }
    }
}