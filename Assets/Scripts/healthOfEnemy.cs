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
        maxHealth = enemyHealthNumber;
        _healthBar.UpdateHealth(maxHealth, enemyHealthNumber);
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
        _healthBar.UpdateHealth(maxHealth, enemyHealthNumber);
        if (enemyHealthNumber <= 0)
        {
            GameManager.Instance.HowMuchWeKilled += 1;
            Destroy(gameObject);
        }
    }
}
