using UnityEngine;
using System;

public class healthOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemyHealthNumber;
    [SerializeField] HealthBar _healthBar;
    [SerializeField] float _reduceSpeed = 2f;
    public float distanceDamageLose;
    private float maxHealth;

    private void Start()
    {
        if (gameObject.tag.Contains("Enemy"))
        {
            maxHealth = enemyHealthNumber;
            _healthBar.UpdateHealth(maxHealth, enemyHealthNumber);
        }
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
        if (gameObject.tag.Contains("Enemy"))
        {
            enemyHealthNumber = enemyHealthNumber - player.GetComponent<playerDamage>().damage / distanceDamageLose;
            _healthBar.UpdateHealth(maxHealth, enemyHealthNumber);
        } else if (gameObject.tag.Contains("Destroyable"))
        {
            Destroy(gameObject);
        }
        if (enemyHealthNumber <= 0)
        {
            Destroy(gameObject);
        }
    }
}
