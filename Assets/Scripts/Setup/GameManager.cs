using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager _instance;
    public static GameManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField] private GameObject _player;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    public static GameObject Player { get => GetInstance()._player; private set => GetInstance()._player = value; }
    private static ScoreUpdater ScoreUpdater { get => GetInstance()._scoreUpdater; set => GetInstance()._scoreUpdater = value; }

    public static void StopScore()
    {
        ScoreUpdater.Updating = false;
    }
    public static void AddScore(int amount)
    {
        ScoreUpdater.AddScore(amount);
    }
    public static void RunCoroutine(IEnumerator enumerator)
    {
        GetInstance().StartCoroutine(enumerator);
    }

    public static void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
