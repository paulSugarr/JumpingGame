
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int MAX_HEALTH = 3;


    [SerializeField] private int _healthCount;
    [SerializeField] private GameObject _deadPrefab;
    [SerializeField] private GameObject _hitPrefab;
    private CameraFollow _camera;


    public int Health
    {
        get
        {
            return _healthCount;
        }
        set
        {
            if (value > 0)
            {
                if (value < _healthCount)
                {
                    GetHit();
                }
                if (value > MAX_HEALTH)
                {
                    _healthCount = MAX_HEALTH;
                }
                _healthCount = value;
                UIController.SetHealth(_healthCount);
            }
            else
            {
                UIController.SetHealth(0);
                Death();
            }
        }
    }
    private void Start()
    {
        _camera = Camera.main.GetComponent<CameraFollow>();
    }

    private void GetHit()
    {
        if (_hitPrefab != null)
        {
            Debug.Log("hit");
            Instantiate(_hitPrefab, transform.position, transform.rotation);
        }
    }

    private void Death()
    {
        if (_deadPrefab != null)
        {
            Instantiate(_deadPrefab, transform.position, transform.rotation);
        }
        _camera.Following = false;
        Destroy(gameObject);
        GameManager.RunCoroutine(LoadSceneWait());
        GameManager.StopScore();
    }
    private IEnumerator LoadSceneWait()
    {
        yield return new WaitForSeconds(2f);
        GameManager.LoadScene(0);
    }
}
