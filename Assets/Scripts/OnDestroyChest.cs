using System.Windows;
using Unity.VisualScripting;
using UnityEngine;

public class OnDestroyChest : MonoBehaviour
{
    [SerializeField] GameObject uiElement;
    [SerializeField] GameObject LevelUpCards;
    private void Start()
    {
        
        
    }

    private void OnDestroy()
    {
        if(uiElement != null)
        {
            uiElement.SetActive(true);
            GameManager.Instance.PauseGame();
        }
        //if(uiElement == null)
        //{
        //    GameManager.Instance.PauseGame();
        //}
        

    }

}
