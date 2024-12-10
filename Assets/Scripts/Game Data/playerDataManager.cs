using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDataManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    //gun
    public int maxNumberOfBullets;
    public int numberOfBullets;
    public float reloadSpeed;
    public float damage;
    public float bulletPenetration;
    //player
    public float rotationSpeed;
    public float playerSpeed;
    //health
    public int currentRedHearths;
    public int maxRedHearths;
    private void Start()
    {
        GameData gameData = new GameData();
        string json = JsonUtility.ToJson(gameData);
        string path = Application.persistentDataPath + "/playerDefaultData.json";
        File.WriteAllText(path, json);
    }
    public void SaveGame()
    {
        GameData gameData = new GameData();
        pushData(gameData);
        string json = JsonUtility.ToJson(gameData);
        string path = Application.persistentDataPath + "/playerData.json";
        File.WriteAllText(path, json);
    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);
            loadData(loadedData);
        }
        else
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        string path = Application.persistentDataPath + "/playerDefaultData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);
            loadData(loadedData);
        }
    }
    void loadData(GameData loadedData)
    {
        player.GetComponent<playerDamage>().damage = loadedData.damage;
        player.GetComponent<playerDamage>().maxNumberOfBullets = loadedData.maxNumberOfBullets;
        player.GetComponent<playerDamage>().reloadSpeed = loadedData.reloadSpeed;
        player.GetComponent<playerDamage>().bulletPenetration = loadedData.bulletPenetration;
        player.GetComponent<healthSystem>().currentRedHearths = loadedData.currentRedHearths;
        player.GetComponent<healthSystem>().maxRedHearths = loadedData.maxRedHearths;
    }
    void pushData(GameData loadedData)
    {
        loadedData.damage = player.GetComponent<playerDamage>().damage;
        loadedData.maxNumberOfBullets = player.GetComponent<playerDamage>().maxNumberOfBullets;
        loadedData.reloadSpeed = player.GetComponent<playerDamage>().reloadSpeed;
        loadedData.bulletPenetration = player.GetComponent<playerDamage>().bulletPenetration;
        loadedData.currentRedHearths = player.GetComponent<healthSystem>().currentRedHearths;
        loadedData.maxRedHearths = player.GetComponent<healthSystem>().maxRedHearths;
    }
}
