using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player = GameObject.FindWithTag("Player");
    
    public static GetPlayer(){
        return player;
    }
        
    void Start()
    {
        
    }
    public static void PauseGame ()
    {
        if(Time.timeScale == 1){
                Time.timeScale = 0;
        } else {
                Time.timeScale = 1;
        }
    }


    void Update()
    {
        // TESTOWE
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }
        
    }
}
