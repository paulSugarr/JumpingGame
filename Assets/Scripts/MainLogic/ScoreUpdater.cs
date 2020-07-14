using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public bool Updating = true;
    [SerializeField] private float _speedToScoreMultiplier;
    private BackgroundController _backgroundController;
    private float _subScore;
    private int _score;
    private void Start()
    {
        _backgroundController = GetComponent<BackgroundController>();
    }
    private void Update()
    {
        if (Updating)
        {
            _subScore += _backgroundController.Speed * Time.deltaTime * _speedToScoreMultiplier;
            if ((int)_subScore > _score)
            {
                _score = (int)_subScore;
                UIController.Score.text = _score.ToString();
            }
        }

    }
}
