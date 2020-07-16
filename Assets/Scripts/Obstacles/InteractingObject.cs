using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingObject : MonoBehaviour
{
    [SerializeField] protected float _replaceDispersion;
    public void Replace()
    {
        var randX = Random.Range(-_replaceDispersion, _replaceDispersion);
        var randY = Random.Range(-_replaceDispersion, _replaceDispersion);
        transform.position += new Vector3(randX, randY, 0);
    }
    protected void Destroy()
    {
        GameManager.RunCoroutine(ReplaceWait());
        gameObject.SetActive(false);
    }
    protected IEnumerator ReplaceWait()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);
    }
}
