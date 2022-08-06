using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float parallaxAmount; //The amount of parallax! 1 simulates being close to the camera, -1 simulates being very far from the camera!
    [System.NonSerialized] public Vector3 newPosition;
    private bool adjusted = false;

    private float length;
    private float startPos;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public void MoveLayer(float positionChangeX, float positionChangeY)
    {
        newPosition = transform.localPosition;
        newPosition.x -= positionChangeX * (-parallaxAmount * 40) * (Time.deltaTime);
        var tempX = newPosition.x;
        newPosition.y -= positionChangeY * (-parallaxAmount * 40) * (Time.deltaTime);
        transform.localPosition = newPosition;

        //if (tempX > startPos + length)
        //{
        //    startPos += length;
        //}
        //else if (tempX < startPos - length)
        //{
        //    startPos -= length;
        //}
    }
}
