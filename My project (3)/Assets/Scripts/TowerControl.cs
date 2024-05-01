using UnityEngine;
using UnityEngine.UI;

public class TowerControl : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Method to take damage
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0); 
        UpdateHealthUI();
        if(currentHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth; 
        }
    }
}
