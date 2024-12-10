using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject main;
    public void PauseGame ()
    {
        if(Time.timeScale == 1){
                Time.timeScale = 0;
                
        } else {
                Time.timeScale = 1;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && main.GetComponent<mainMenuMgr>().levelOpen)
        {
            PauseGame();
        }
    }   
}