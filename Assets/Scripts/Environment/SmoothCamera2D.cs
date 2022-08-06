using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

   public Transform player;

    // Update is called once per frame
    void Update () {
        // transform.position = player.transform.position + new Vector3(0, 1, -5);
        transform.position = new Vector3(player.position.x, this.transform.position.y, player.position.z - 5);
    }
}