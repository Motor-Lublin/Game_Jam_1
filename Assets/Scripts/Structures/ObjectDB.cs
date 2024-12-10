using System.Collections.Generic;
using UnityEngine;

public class ObjectDB : MonoBehaviour
{
    public List<Loot> lootList = new List<Loot>();
    public List<Environment> environmentList = new List<Environment>();
    public List<Enemy> enemyList = new List<Enemy>();

    public ObjectDB()
    {
        //premade list of Objects
        lootList.Add(new Loot(ObjectsEnums.ELoot.Heart));
        lootList.Add(new Loot(ObjectsEnums.ELoot.Chest));
        lootList.Add(new Loot(ObjectsEnums.ELoot.Gun));
        environmentList.Add(new Environment(ObjectsEnums.EEnvironment.Rock));
        enemyList.Add(new Enemy(ObjectsEnums.EEnemy.WeakEnemy));
        enemyList.Add(new Enemy(ObjectsEnums.EEnemy.MediumEnemy));
        enemyList.Add(new Enemy(ObjectsEnums.EEnemy.HardEnemy));
        enemyList.Add(new Enemy(ObjectsEnums.EEnemy.Boss1));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
