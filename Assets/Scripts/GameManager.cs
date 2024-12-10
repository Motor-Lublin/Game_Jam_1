using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public GameObject UIForUpgradeOfStats;
    [SerializeField] public GameObject GameOverCanvas;
    [SerializeField] public GameObject WinCanvas;
    public Transform wheretospawnboss;
    public GameObject bossPrefab;

    public float HowMuchWeKilled = 0;

    public bool CanWeUnPauseGame = true;

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

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        PauseGame();
        CanWeUnPauseGame=false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GunplayTestML");
        PauseGame();
        AudioManager.Instance.PlayMusic(0);
    }

    public void WinGame()
    {
        WinCanvas.SetActive(true);
        PauseGame() ;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    bool bossjuzzespawnowanyxd = false;
    void Update()
    {
        if (CanWeUnPauseGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        
        if(HowMuchWeKilled >= 1)
        {
            Generator.Instance.AddBossToSpawnPool(true);
            
            var boss_spawn_point = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(5, 0, 5);
            
            if(!bossjuzzespawnowanyxd)
                Instantiate(bossPrefab, wheretospawnboss);
            bossjuzzespawnowanyxd = true;
        }
    }
}


