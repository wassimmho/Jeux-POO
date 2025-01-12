using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100; // Max health of the character
        private int currentHealth;
        [SerializeField] private Text healthText; // Text element to display the health

        void Start()
        {
            currentHealth = maxHealth; // Initialize health
            UpdateHealthUI(); // Update UI
        }

        // Function to handle taking damage
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0) currentHealth = 0; // Prevent health from going negative
            UpdateHealthUI(); // Update the UI after damage

            if (currentHealth == 0)
            {
                // Optionally add logic for death, like triggering a death animation
                Debug.Log($"{gameObject.name} has died.");
            }
        }

        // Update health UI (Display current health on the screen)
        private void UpdateHealthUI()
        {
            if (healthText != null)
            {
                healthText.text = "Health: " + currentHealth.ToString(); // Update the text component with current health
            }
        }

        // Function to heal (e.g., for healing potions or skills)
        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth) currentHealth = maxHealth; // Prevent health from exceeding maxHealth
            UpdateHealthUI(); // Update the UI after healing
        }

        // Getter for current health
        public int GetCurrentHealth()
        {
            return currentHealth;
        }

        // Check if the character is alive
        public bool IsAlive()
        {
            return currentHealth > 0;
        }
    }
}
