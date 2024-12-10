using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerDamage : MonoBehaviour
{
    [SerializeField] InputAction playerShot;

    public int maxNumberOfBullets;
    int numberOfBullets;


    public float reloadSpeed;
    bool canShootAgain = true;

    public float damage;
    public float bulletPenetration;

    GameObject[] inRange;

    private void Start()
    {
        playerShot.Enable();
        numberOfBullets = maxNumberOfBullets;
    }

    private void Update()
    {
        if (playerShot.WasPressedThisFrame() && numberOfBullets != 0 && canShootAgain)
        {
            canShootAgain = false;
            Invoke("waitToShoot", 1);
            //PLay particles AND Animation
            inRange = GameObject.FindGameObjectsWithTag("Enemy/InRange");
            foreach (GameObject canBeKilled in inRange)
            {
                canBeKilled.GetComponent<healthOfEnemy>().enemyLoseHP();
            }
        }
        if(numberOfBullets == 0)
        {
            //Reload animation
            Invoke("reload", reloadSpeed);
        }
    }

    private void waitToShoot()
    {
        canShootAgain = true;
        numberOfBullets--;
    }
    void reload()
    {
        numberOfBullets = maxNumberOfBullets;
    }
}
