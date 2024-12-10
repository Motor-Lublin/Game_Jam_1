using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChestInteract : MonoBehaviour
{
    public Button dmg;
    
    public SpriteRenderer[] ChestLoot;
    [SerializeField] playerDamage PlayerDamage;
    [SerializeField] healthSystem HealthSystem;
    [SerializeField] int damageToAddFromChest = 10;
    [SerializeField] int hpToAddFromChest = 1;

    private void Start()
    {
        PlayerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<playerDamage>();
        HealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<healthSystem>();

    }

    public void AddDmg()
    {
        PlayerDamage.damage += damageToAddFromChest;
    }
    public void AddHP()
    {
        HealthSystem.currentRedHearths += hpToAddFromChest;
    }






}
