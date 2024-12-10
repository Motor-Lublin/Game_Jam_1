using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _hbSprite; // Tu musi być FG healthbara
    private Quaternion fixedRotation;
    private Camera _cam;                    
    private Transform cTransform;
    void Start()
    {
        _cam = Camera.main;
        cTransform = transform.parent;
        fixedRotation = Quaternion.Euler(0, 0, 0); 
    }

    void Update()
    {
        //transform.position =  cTransform.position + offset;
        transform.rotation = fixedRotation;
    }
    
    // przy ataku gracza trzeba przywołać tą metode
    public void UpdateHealth(float maxHealth, float currentHealth ){
        _hbSprite.fillAmount = currentHealth / maxHealth;
    }
}
