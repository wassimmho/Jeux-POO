using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Gameplay : MonoBehaviour
    {
        private List<Personnage> characters; // All characters, including the player and enemies
        public Button normalAttackButton;
        public Button specialAttackButton;
        public Button warriorbutton;
        public Button wizzardbutton;
        public Button assassinbutton;
        public Button theifbutton;

        public Personnage player; // The player's character
        public Text actionText; // Reference to the Text UI component
        public Text playerHealthText; // Reference to the Text UI component to display player's health

        private string selectedAction = ""; // Stores selected action
        private bool isPlayerTurn = true;
        private bool isEnemyTurn = false;

        private void Start()
        {
            InitializeCharacters();
            SetupUI();
            StartPlayerTurn();
            UpdatePlayerHealthText(); // Update the health text at the start
        }

        private void InitializeCharacters()
        {
            // Create and initialize characters using the Personnage class
            var warrior = new Warrior("Warrior");
            var assassin = new Assassin("Assassin");
            var wizard = new Wizard("Wizard");
            var thief = new Theif("Thief");

            characters = new List<Personnage> { warrior, assassin, wizard, thief };

            // Get the selected character from PlayerPrefs, default to 0 (Warrior) if not set
            int selectedCharacterIndex = PlayerPrefs.GetInt("warrior", 0);

            switch (selectedCharacterIndex)
            {
                case 0: // Warrior
                    player = new Warrior("Warrior");
                    break;
                case 1: // Wizard
                    player = new Wizard("Wizard");
                    break;
                case 2: // Assassin
                    player = new Assassin("Assassin");
                    break;
                case 3: // Thief
                    player = new Theif("Thief");
                    break;
                default:
                    player = new Warrior("Warrior"); // Default to Warrior
                    break;
            }

            Debug.Log($"[Initialization] Player selected: {player.Nom}");
        }

        private void SetupUI()
        {
            // Set up the action buttons (Attack, Special)
            normalAttackButton.onClick.AddListener(() => SelectAction("attack"));
            specialAttackButton.onClick.AddListener(() => SelectAction("special"));
            warriorbutton.onClick.AddListener(() => SelectTarget(0));
            wizzardbutton.onClick.AddListener(() => SelectTarget(1));
            assassinbutton.onClick.AddListener(() => SelectTarget(2));
            theifbutton.onClick.AddListener(() => SelectTarget(3));
        }

        private void UpdatePlayerHealthText()
        {
            // Update the health text UI with the current health of the player
            playerHealthText.text = $"Health: {player.pointsDeVie}"; // Assuming 'pointsDeVie' is the player's health variable
        }

        private void StartPlayerTurn()
        {
            isPlayerTurn = true;
            isEnemyTurn = false;
            actionText.text = "[Turn Start] Player's turn! Choose an action."; // Show player's turn message
            Debug.Log("[Turn Start] Player's turn! Choose an action.");
        }

        private void SelectAction(string action)
        {
            selectedAction = action;
            actionText.text = $"Action Selected: {action}. Now select your target."; // Show action selected message
            Debug.Log($"[Action Selected] Action: {action}. Now select your target.");
        }

        private void SelectTarget(int target)
        {
            if (string.IsNullOrEmpty(selectedAction))
            {
                actionText.text = "[Action Error] Select an action before choosing a target.";
                Debug.Log("[Action Error] Select an action before choosing a target.");
                return;
            }

            if (!characters[target].EstVivant())
            {
                actionText.text = "[Target Error] Invalid target. Choose another enemy.";
                Debug.Log("[Target Error] Invalid target. Choose another enemy.");
                return;
            }

            if (selectedAction == "attack")
            {
                player.Attaquer(characters[target]);
                actionText.text = $"{player.Nom} attacked {characters[target].Nom}!"; // Show attack message
                Debug.Log($"[Attack] {player.Nom} attacked {characters[target].Nom}!");
            }
            else if (selectedAction == "special")
            {
                player.UtiliserCompetence(characters[target]);
                actionText.text = $"{player.Nom} used a special attack on {characters[target].Nom}!"; // Show special attack message
                Debug.Log($"[Special Attack] {player.Nom} used a special attack on {characters[target].Nom}!");
            }

            selectedAction = "";
            UpdatePlayerHealthText(); // Update the player's health after any change
            EndTurn();
        }

        private void EndTurn()
        {
            isPlayerTurn = false;
            isEnemyTurn = true;
            actionText.text = "Player's turn ended. Enemies' turn begins."; // Show end of player's turn
            Debug.Log("[Turn End] Player's turn ended. Enemies' turn begins.");
            StartCoroutine(EnemyTurns());
        }

        private IEnumerator EnemyTurns()
        {
            int selectedCharacterIndex = PlayerPrefs.GetInt("warrior", 0);

            for (int i = 0; i < characters.Count; i++)
            {
                // Skip the player's turn and already-dead enemies
                if (i == selectedCharacterIndex || !characters[i].EstVivant())
                {
                    continue;
                }

                var enemy = characters[i]; // Current enemy whose turn it is
                actionText.text = $"Enemy's turn: {enemy.Nom}."; // Show enemy's turn message
                Debug.Log($"[Enemy Turn] {enemy.Nom}'s turn!");

                // Create a list of all alive enemies excluding the current enemy and the player
                List<Personnage> aliveEnemies = new List<Personnage>();

                for (int j = 0; j < characters.Count; j++)
                {
                    if (i != j && characters[j].EstVivant())
                    {
                        aliveEnemies.Add(characters[j]);
                    }
                }

                // Debugging the list of alive enemies
                if (aliveEnemies.Count == 0)
                {
                    Debug.Log($"[Enemy Action] {enemy.Nom} has no valid targets.");
                }
                else
                {
                    // Randomly select a target from the alive enemies list
                    var target = aliveEnemies[UnityEngine.Random.Range(0, aliveEnemies.Count)];

                    // Randomly decide between normal attack and special attack
                    int actionChoice = UnityEngine.Random.Range(0, 2); // 0 = normal attack, 1 = special attack
                    if (actionChoice == 0)
                    {
                        enemy.Attaquer(target);
                        actionText.text = $"{enemy.Nom} attacked {target.Nom}!"; // Show enemy's attack message
                        Debug.Log($"[Enemy Attack] {enemy.Nom} attacked {target.Nom}!");
                    }
                    else
                    {
                        enemy.UtiliserCompetence(target);
                        actionText.text = $"{enemy.Nom} used a special attack on {target.Nom}!"; // Show enemy's special attack message
                        Debug.Log($"[Enemy Special Attack] {enemy.Nom} used a special attack on {target.Nom}!");
                    }

                    // Print target health after the attack
                    Debug.Log($"[Health Update] {target.Nom} health: {target.pointsDeVie}");
                }

                yield return new WaitForSeconds(1.5f); // Add a delay between enemy turns
            }

            // End enemy turns and return to player turn
            actionText.text = ""; // Clear text after enemy's turn
            isEnemyTurn = false;
            CheckGameOver();
            StartPlayerTurn();
        }

        private void CheckGameOver()
        {
            int aliveEnemies = 0;
            int selectedCharacterIndex = PlayerPrefs.GetInt("warrior", 0);

            // Count the number of alive enemies
            for (int i = 0; i < characters.Count; i++)
            {
                if (i == selectedCharacterIndex) { continue; }
                if (characters[i].EstVivant())
                {
                    aliveEnemies++;
                }
            }

            // Check if the player is alive
            if (!player.EstVivant())
            {
                actionText.text = "[Game Over] You have been defeated. Game over!"; // Show game over message
                Debug.Log("[Game Over] You have been defeated. Game over!");
                GameOver();
            }
            else if (aliveEnemies == 0)
            {
                actionText.text = "[Victory] You win! All enemies are defeated."; // Show victory message
                Debug.Log("[Victory] You win! All enemies are defeated.");
                GameOver();
            }
        }

        private void GameOver()
        {
            // Disable gameplay and UI interactions when the game ends
            enabled = false;
            // Optionally, show a game over UI or display a message to the player
            Debug.Log("[Game Over] Final state reached.");
        }
    }

}
