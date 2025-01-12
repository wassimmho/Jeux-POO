using System.Collections;
using UnityEngine;

namespace Game
{
    public class Assassin : Personnage
    {
        // Constructor with name, using base class to initialize health and damage
        public Assassin(string nom) : base(nom, 70, 20) // Points de vie et dégâts ajustés
        {
        }

        // Override Attaquer to add special behavior (double attack with 25% chance)
        public override void Attaquer(Personnage cible)
        {
            if (cible == null) return;

            Debug.Log($"{Nom} silently approaches and strikes {cible.Nom}!");
            cible.RecevoirDegats(Degats);

            // Special mechanic: Double attack with 25% chance
            if (UnityEngine.Random.Range(0, 100) < 25) // 25% chance
            {
                Debug.Log($"{Nom} performs a second attack!");
                cible.RecevoirDegats(Degats / 2); // Additional damage (50% of initial damage)
            }
        }

        // Override UtiliserCompetence to apply a special ability
        public override void UtiliserCompetence(Personnage cible)
        {
            if (!competenceUtilisee) // Check if competence is already used
            {
                Debug.Log($"{Nom} uses his special skill: Shadow Strike!");
                cible.RecevoirDegats(Degats * 3); // Triple damage as part of special skill
                competenceUtilisee = true; // Mark competence as used
            }
            else
            {
                Debug.Log($"{Nom} has already used his special skill!");
            }
        }
    }
}
