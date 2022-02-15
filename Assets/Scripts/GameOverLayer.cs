using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameOverLayer : MonoBehaviour
{
    public GameObject ScoresContainer;
    public GameObject ScoreElemPrefab;

    Scores highScores = new Scores();


    void loadScoresPrefab()
    {
        foreach (UserScore score in highScores.scores)
        {
            Instantiate(ScoreElemPrefab, ScoresContainer.transform);
        }
    }

    void saveHighScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/scores.dat");

        bf.Serialize(file, highScores);
        file.Close();
        Debug.Log("Game data saved!");

    }

    void loadHighScores()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/scores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/scores.dat", FileMode.Open);
            Scores data = (Scores)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game data loaded! ");
        }
        else
            Debug.LogError("There is no save data!");
    }

    void addScore(string playerName, int scorePTS, int position)
    {
        highScores.scores.Add(new UserScore(playerName, scorePTS, position));
    }
}

[Serializable]
public class UserScore
{
    public string playerName;
    public int scorePTS;
    public int position;

    public UserScore(string playerName, int scorePTS, int position)
    {
        this.playerName = playerName;
        this.scorePTS = scorePTS;
        this.position = position;
    }
}

[Serializable]
public class Scores
{
    public List<UserScore> scores = new List<UserScore>();
}