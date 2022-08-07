using TMPro;
using UnityEngine;

public class KillCountUIText : MonoBehaviour
{
    private int killCount;
    private int killRequirment;

    public TMP_Text killText;

    private GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        killCount = gc.killCount;
        killRequirment = gc.killRequirment;
    }

    // Update is called once per frame
    void Update()
    {
        killCount = gc.killCount;
        killText.SetText(killCount + " / " + killRequirment);
    }
}
