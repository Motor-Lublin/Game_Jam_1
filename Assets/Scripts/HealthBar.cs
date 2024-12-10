using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _hbSprite; // Tu musi być FG healthbara
    private Camera _cam;                    
    void Start()
    {
        _cam = Camera.main;
        
    }

    void Update()
    {
        
    }
    
    // przy ataku gracza trzeba przywołać tą metode
    public void UpdateHealth(float maxHealth, float currentHealth ){
        _hbSprite.fillAmount = currentHealth / maxHealth;
    }
}
