using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerDamage : MonoBehaviour
{
    [SerializeField] GameObject coneOfDamage;
    [SerializeField] InputAction playerShot;
    public Transform ParticleHolder;

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
            Invoke("waitToShoot", 1);
            //PLay particles AND Animation
            ParticleManager.Instance.ShotgunParticles(0, ParticleHolder);
            AudioManager.Instance.PlaySFX(0);
            inRange = GameObject.FindGameObjectsWithTag("Movable/Enemy/InRange");
            var chestInRange = GameObject.FindGameObjectWithTag("Movable/Chest/InRange");
            Destroy(chestInRange);
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
    private void AddDmg()
    {
        damage++;
    }
}
