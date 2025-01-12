using System.Collections;
using UnityEngine;

namespace Game
{
    public class Theif : Personnage
    {
        private static System.Random random = new System.Random();

        // Constructor correctly calling base class constructor
        public Theif(string nom) : base(nom, 70, 12) // Adjusted health and damage
        {
        }

        // Override Attaquer to add specific behavior for Theif's attack
        public override void Attaquer(Personnage cible)
        {
            if (cible == null) return;

            Debug.Log($"{Nom} attacks {cible.Nom} by surprise!");
            cible.RecevoirDegats(Degats); // Apply regular damage

            // 20% chance for a critical hit
            if (random.Next(0, 100) < 20)
            {
                Debug.Log($"{Nom} lands a critical hit!");
                cible.RecevoirDegats(Degats); // Apply additional damage for critical hit
            }
        }

        // Override UtiliserCompetence to apply Theif's special skill
        public override void UtiliserCompetence(Personnage cible)
        {
            if (!competenceUtilisee) // Check if special ability has been used
            {
                Debug.Log($"{Nom} uses his special skill: Quick attack from behind!");
                cible.RecevoirDegats(Degats * 3); // Triple damage for special skill
                competenceUtilisee = true; // Mark competence as used
            }
            else
            {
                Debug.Log($"{Nom} has already used his special skill!");
            }
        }
    }
}
