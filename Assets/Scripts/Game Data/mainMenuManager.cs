using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] InputAction settings;
    [SerializeField] GameObject canvas;
    bool settingsOpen;

    public void Start()
    {
        settings.Enable();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (settings.WasPerformedThisFrame() && !settingsOpen)
        {
            canvas.SetActive(true);
            settingsOpen = true;
        }
        else if (settings.WasPerformedThisFrame() && settingsOpen)
        {
            canvas.SetActive(false);
            settingsOpen = false;
        }
    }
    public void newGame()
    {
        SceneManager.LoadScene(1);
    }
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void saveGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HideSettings()
    {
        canvas.SetActive(false);
        settingsOpen = false;
    }
    public void MainMenu()
    {

    }



}
