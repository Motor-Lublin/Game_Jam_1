using UnityEngine;

public class healthSystem : MonoBehaviour
{

    public SpriteRenderer[] hearthIcons;
    public int currentRedHearths;
    public int currentGoldHearths;
    public int maxRedHearths;
    public int maxGoldHearths;
    private int _hardLimitOfRedHearts;

    public Sprite S_BrokenHeart;
    public Sprite S_DeadHeart;
    public Sprite S_NormalHeart;
    public Sprite S_PremiumBrokenHEart;
    public Sprite S_PremiumHeart;


    [SerializeField] Light playerLight;
    private void Start()
    {
        IsHealthHalf();
        maxRedHearths = 8;

    }

    private void IsHealthHalf()
    {
        switch (currentRedHearths)
        {
            case 0:
                hearthIcons[0].sprite = S_DeadHeart;
                hearthIcons[1].sprite = S_DeadHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 1500;
                return;
            case 1:
                hearthIcons[0].sprite = S_BrokenHeart;
                hearthIcons[1].sprite = S_DeadHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 3000;
                return;
            case 2:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_DeadHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 5000;
                return;
            case 3:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_BrokenHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 7500;
                return;
            case 4:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 10000;
                return;
            
            case 5:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_BrokenHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 12500;
                return;
            case 6:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                playerLight.colorTemperature = 15000;
                return;
            case 7:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_BrokenHeart;
                playerLight.colorTemperature = 17500;
                return;
            case 8:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_NormalHeart;
                playerLight.colorTemperature = 20000;
                return;
        }
    }

    public void HealUp(int amountToHeal)
    {
        currentRedHearths += amountToHeal;
        if (currentRedHearths > maxRedHearths) currentRedHearths = maxRedHearths;
    }


    public void HeartStstus()
    {
        int redHearts = currentRedHearths;
        int goldHearts = currentGoldHearths;

    }
    private void Update()
    {
        IsHealthHalf();
    }
    private void AddHP()
    {
        currentRedHearths++;
        IsHealthHalf();
    }
    private void RemoveHP()
    {
        currentRedHearths--;
        IsHealthHalf();
    }

    public void AddMaxHealth(int i)
    {
        if(maxRedHearths + i<=_hardLimitOfRedHearts)
            maxRedHearths += i;
    }
}