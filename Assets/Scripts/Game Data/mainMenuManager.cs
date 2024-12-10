using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] InputAction settings;
    [SerializeField] GameObject SaveManager;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject level1;

    bool settingsOpen;

    public void Start()
    {
        settings.Enable();
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
        SaveManager.GetComponent<playerDataManager>().NewGame();
        mainMenu.SetActive(false);
        level1.SetActive(true);

    }
    public void loadGame()
    {
        SaveManager.GetComponent<playerDataManager>().LoadGame();
        mainMenu.SetActive(false);
        level1.SetActive(true);
    }
    public void saveGame()
    {
        SaveManager.GetComponent<playerDataManager>().SaveGame();
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
        SaveManager.GetComponent<playerDataManager>().SaveGame();
        mainMenu.SetActive(true);
        level1.SetActive(false);
        canvas.SetActive(false);
    }

    public void muteMusic()
    {
        GameObject music = GameObject.FindWithTag("MusicVolume");
        AudioListener.volume = music.GetComponent<Slider>().value;
    }
}
