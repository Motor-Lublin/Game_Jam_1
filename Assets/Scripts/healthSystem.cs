using UnityEngine;

public class healthSystem : MonoBehaviour
{

    public SpriteRenderer[] hearthIcons;
    public int currentRedHearths;
    public int currentGoldHearths;
    public int maxRedHearths;
    public int maxGoldHearths;

    public Sprite S_BrokenHeart;
    public Sprite S_DeadHeart;
    public Sprite S_NormalHeart;
    public Sprite S_PremiumBrokenHEart;
    public Sprite S_PremiumHeart;





    private void Start()
    {
        IsHealthHalf();

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
                return;
            case 1:
                hearthIcons[0].sprite = S_BrokenHeart;
                hearthIcons[1].sprite = S_DeadHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            case 2:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_DeadHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            case 3:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_BrokenHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            case 4:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_DeadHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            
            case 5:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_BrokenHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            case 6:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_DeadHeart;
                return;
            case 7:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_BrokenHeart;
                return;
            case 8:
                hearthIcons[0].sprite = S_NormalHeart;
                hearthIcons[1].sprite = S_NormalHeart;
                hearthIcons[2].sprite = S_NormalHeart;
                hearthIcons[3].sprite = S_NormalHeart;
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
}