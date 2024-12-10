using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class mainMenuMgr : MonoBehaviour
{
    [SerializeField] InputAction settings;
    [SerializeField] GameObject SaveManager;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject gameMgr;

    bool settingsOpen;
    public bool levelOpen = false;

    public void Start()
    {
        settings.Enable();
    }

    private void Update()
    {
        if (settings.WasPerformedThisFrame() && !settingsOpen && levelOpen)
        {
            canvas.SetActive(true);
            settingsOpen = true;
        }
        else if (settings.WasPerformedThisFrame() && settingsOpen && levelOpen)
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
        levelOpen = true;

    }
    public void loadGame()
    {
        SaveManager.GetComponent<playerDataManager>().LoadGame();
        mainMenu.SetActive(false);
        level1.SetActive(true);
        levelOpen = true;
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
        gameMgr.GetComponent<GameManager>().PauseGame();
    }
    public void MainMenu()
    {
        SaveManager.GetComponent<playerDataManager>().SaveGame();
        mainMenu.SetActive(true);
        level1.SetActive(false);
        canvas.SetActive(false);
        levelOpen = false;
    }
}
