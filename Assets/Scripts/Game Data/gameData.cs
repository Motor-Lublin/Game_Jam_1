using UnityEngine;

[System.Serializable]
public class GameData
{
        //gun
    public int maxNumberOfBullets = 5;
    public float reloadSpeed = 5;
    public float damage = 100;
    public float bulletPenetration = 1;
    //health
    public int currentRedHearths = 8;
    public int maxRedHearths = 8;
}
