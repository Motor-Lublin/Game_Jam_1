using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("GunplayTestML");
    }
    
    public void Exit(){
        Application.Quit();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
