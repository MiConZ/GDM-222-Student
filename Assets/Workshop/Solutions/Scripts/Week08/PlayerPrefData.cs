using UnityEngine;

public class PlayerPrefData : MonoBehaviour
{
    public string playerName = "Unknow";
    public int highscore = 0;
    public float Volume = 0.5f;

    public void Start()
    {
        SaveDataPlayer();
    }
    public void SaveDataPlayer()
        {
        PlayerPrefs.SetString("PlayerName", playerName); 
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetFloat("Volume", Volume);

        PlayerPrefs.Save();
        Debug.Log("Save PLayer Data");
    }
    public void LoadDataPlayer()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName", "No Name");
            highscore = PlayerPrefs.GetInt("HighScore", 0);
            Volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            Debug.Log("Load Player Data Successful");
        }
        else
        {
            Debug.Log("not found data");
        }
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear All Save");
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.J)) { SaveDataPlayer(); }
        if (Input.GetKeyUp(KeyCode.K)) { LoadDataPlayer(); }
        if (Input.GetKeyUp(KeyCode.L)) { ResetData(); }
    }
}
