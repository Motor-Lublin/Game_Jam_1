using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject player; 
    
    
    public GameObject GetPlayer(){
        return player;
    }
        
    void Start(){
       player = GameObject.FindWithTag("Player");
       Debug.Log("Menager loaded!");
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
