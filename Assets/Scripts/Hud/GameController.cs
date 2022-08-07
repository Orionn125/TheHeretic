using UnityEngine;

public class GameController : MonoBehaviour
{
    public int killCount;

    [SerializeField]
    public int killRequirment;

    void Start()
    {
        killCount = 0;
        killRequirment = 3;
    }

    void Update()
    {
        if (killCount == killRequirment)
        {

            Debug.Log("DONE QUEST");
        }
    }

}
