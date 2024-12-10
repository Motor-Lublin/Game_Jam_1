using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerDamage : MonoBehaviour
{
    [SerializeField] GameObject coneOfDamage;
    [SerializeField] InputAction playerShot;

    [SerializeField] int maxNumberOfBullets;
    int numberOfBullets;


    [SerializeField] float reloadSpeed;
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
            AudioManager.Instance.PlaySFX(0);
            Invoke("waitToShoot", 1);
            //PLay particles AND Animation
            inRange = GameObject.FindGameObjectsWithTag("Movable/Enemy/InRange");
            foreach (GameObject canBeKilled in inRange)
            {
                canBeKilled.GetComponent<healthOfEnemy>().enemyLoseHP();
            }
        }
        if(numberOfBullets == 0)
        {
            Debug.Log("ITS RELOAD TIME!");
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
