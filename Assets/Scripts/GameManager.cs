using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Start()
    {
        Instance = this;
    }

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
        // TESTOWE
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    PauseGame();
        //}

    }
}
