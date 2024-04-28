using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public TowerControl towerControl; 
    public Slider healthSlider;

    void Update()
    {
        if (towerControl != null && healthSlider != null)
        {
            float fillValue = (float)towerControl.currentHealth / towerControl.maxHealth;
            healthSlider.value = fillValue;
        }
    }
}
