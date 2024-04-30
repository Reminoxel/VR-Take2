using UnityEngine;
using UnityEngine.UI;

public class ObjectiveInterfaceController : MonoBehaviour
{
    public Text waveText;
    public Text towerHealthText;

    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        UpdateObjectives();
    }

    void Update()
    {
        UpdateObjectives();
    }

    void UpdateObjectives()
    {
        waveText.text = "Wave: " + gameController.waveNum.ToString();


        if (gameController.Tower != null)
        {
            TowerControl towerControl = gameController.Tower.GetComponent<TowerControl>();
            if (towerControl != null)
            {
                towerHealthText.text = "Tower Health: " + towerControl.currentHealth.ToString();
            }
            else
            {
                towerHealthText.text = "Tower Health: N/A";
            }
        }
        else
        {
            towerHealthText.text = "Tower Health: N/A";
        }
    }
}
