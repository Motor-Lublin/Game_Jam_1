using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public GameObject UIForUpgradeOfStats;
    void Start()
    {
        Instance = this;
        AudioManager.Instance.PlayMusic(0);
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
