using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;
    private bool _isGameOver = false;
    void Start()
    {
        AudioManager.Instance.PlayMusic(0);
    }
    public static void PauseGame ()
    {
        if(_isGameOver)
            return;

        if(Time.timeScale == 1){
                Time.timeScale = 0;
        } else {
                Time.timeScale = 1;
        }
    }
    
    public static void GameOver(){

        _isGameOver = true;
        Time.timeScale = 0;


    }
    public static void Restart(){
        SceneManager.LoadScene("GunplayTestML");
    }
    public static void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


    void Update()
    {
        // TESTOWE
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }
        
    }
}
