using UnityEngine;

public class ObjectsEnums : MonoBehaviour
{
    public enum EObjectTypes
    {
        None,
        Loot,
        Environment,
        Enemy
    }

    public enum ELoot
    {
        None,
        Heart,
        Chest,
        Gun
    }

    public enum EEnemy
    {
        None,
        WeakEnemy,
        MediumEnemy,
        HardEnemy,
        Boss1
    }

    public enum EEnvironment
    {
        None,
        Rock
    }

}
