using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDataManager : MonoBehaviour
{
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
        DontDestroyOnLoad(gameObject);
    }
    public void SaveGame()
    {
        GameData gameData = new GameData();
        GameObject playerDamage = GameObject.FindWithTag("Player");
        gameData.damage = playerDamage.GetComponent<playerDamage>().damage;

        string json = JsonUtility.ToJson(gameData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);

            GameObject.FindWithTag("Player").GetComponent<playerDamage>().damage = loadedData.damage;
        }
    }
}
