using UnityEngine;
using System;

public class healthOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemyHealthNumber;
    public float distanceDamageLose;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void distanceParameter()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float pen = player.GetComponent<playerDamage>().bulletPenetration;
        distanceDamageLose = ((distance / 10)+10) / pen;
    }
    public void enemyLoseHP()
    {
        distanceParameter();
        enemyHealthNumber = enemyHealthNumber - player.GetComponent<playerDamage>().damage / distanceDamageLose;
        if (enemyHealthNumber <= 0)
        {
            Destroy(gameObject);
        }
    }
}
