using UnityEngine;
using System;

public class healthOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemyHealthNumber;
    public float distanceDamageLose;
    void distanceParameter()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float pen = player.GetComponent<playerDamage>().bulletPenetration;
        distanceDamageLose = distance / 10 * pen;
    }
    public void enemyLoseHP()
    {
        distanceParameter();
        enemyHealthNumber = enemyHealthNumber - player.GetComponent<playerDamage>().damage / distanceDamageLose;
        Debug.Log(enemyHealthNumber);
    }
}
