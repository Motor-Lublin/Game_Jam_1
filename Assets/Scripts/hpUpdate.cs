using UnityEngine;

public class hpUpdate : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool canBeDamaged = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Contains("Enemy") && canBeDamaged)
        {
            player.GetComponent<healthSystem>().RemoveHP();
            canBeDamaged = false;
            Invoke("damageCooldown", 1);
        }
    }

    public void damageCooldown()
    {
        canBeDamaged = true;
    }
}
