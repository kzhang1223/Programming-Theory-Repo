using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int penguinIndex = 0;

    public bool onIntro = true;

    public int numTimesOpened = 0;

    public List<int> collectedPenguins = new List<int>();

    public AudioSource buttonSound;

    public AudioSource penguinSound;

    public AudioSource eggSound;

    public AudioSource walkingSound;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public List<int> collectedPenguins;
        public bool onIntro;
    }

    public void SavePenguins()
    {
        SaveData data = new SaveData();
        data.collectedPenguins = collectedPenguins;
        data.onIntro = onIntro;

        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("Save", json);
        PlayerPrefs.Save();

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPenguins()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            string json = PlayerPrefs.GetString("Save");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            collectedPenguins = data.collectedPenguins;
            onIntro = data.onIntro;
        }
    }
}
