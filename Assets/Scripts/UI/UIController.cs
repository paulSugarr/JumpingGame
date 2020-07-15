using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singletone
    private static UIController _instance;
    public static UIController GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<UIController>();
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

    [SerializeField] private Text _score;
    [SerializeField] private List<Image> _hearts;
    public static Text Score { get => GetInstance()._score; private set => GetInstance()._score = value; }
    public static void SetHealth(int value)
    {
        var hearts = GetInstance()._hearts;
        if (value > hearts.Count || value < 0) { return; }
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].gameObject.SetActive(i < value);
        }
    }
}
