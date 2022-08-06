using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image HealthIcon;
    private float offset = 40;

    public void SetHealth(int health)
    {
        for (int i = 1; i <= health; i++)
        {
            Debug.Log("tu sam");
            var pos = new Vector3(this.transform.position.x + (i * offset), this.transform.position.y, this.transform.position.z);
            Instantiate(HealthIcon, pos, Quaternion.identity);
        }
    }
}
