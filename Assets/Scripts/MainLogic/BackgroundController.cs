using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float Speed = 1f;
    public ObstaclesContainer[] Backgrounds;
    private Vector3 _endPosition;
    private Vector3 _step;
    void Start()
    {
        _endPosition = Backgrounds[0].transform.position;
        _step = Backgrounds[1].transform.position - _endPosition;
    }

    void FixedUpdate()
    {

        for (int i = 0; i < Backgrounds.Length; i++)
        {
            if (Backgrounds[i].transform.position.y <= _endPosition.y)
            {
                var roadsCount = Backgrounds.GetLength(0);
                Backgrounds[i].transform.position = Backgrounds[(i + roadsCount - 1) % Backgrounds.GetLength(0)].transform.position + _step;

                var posY = Backgrounds[i].transform.position.y;
                var setCurrent = posY >= _endPosition.y && posY <= _endPosition.y + 2 * _step.y;
                Backgrounds[i].Current = setCurrent;
            }
        }
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            Backgrounds[i].transform.Translate(0, -Speed * Time.fixedDeltaTime, 0);
        }
    }
}
