using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _shootingDistance;
    [SerializeField] private Vector3 _projectileSpawnVector3;

    void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.tag.Contains("Player") 
            && Vector3.Distance(
                transform.position, 
                other.transform.position)
            <=_shootingDistance)
        {
            _animator.SetBool("InRange", true);
            SpawnProjectiles();
        }
    }

    private void SpawnProjectiles()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (
            other.gameObject.tag.Contains("Player")
            && Vector3.Distance(
                transform.position,
                other.transform.position)
            > _shootingDistance)
        {
            _animator.SetBool("InRange", false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
