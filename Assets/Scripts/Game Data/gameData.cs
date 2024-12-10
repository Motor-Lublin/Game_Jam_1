using UnityEngine;

[System.Serializable]
public class GameData
{
        //gun
    public int maxNumberOfBullets = 5;
    public int numberOfBullets = 5;
    public float reloadSpeed = 5;
    public float damage = 100;
    public float bulletPenetration = 20;
    //player
    public float rotationSpeed = 25f;
    public float playerSpeed = 10f;
    //health
    public int currentRedHearths = 8;
    public int maxRedHearths = 8;
}
