using System;
using UnityEngine;

namespace Game
{
    public class Wizard : Personnage
    {
        // Constructor correctly calling base class constructor
        public Wizard(string nom) : base(nom, 90, 15) // Adjusted health and damage
        {
        }

        // Override Attaquer to add specific behavior for Wizard's attack
        public override void Attaquer(Personnage cible)
        {
            if (cible == null) return;

            Debug.Log($"{Nom} casts a fireball at {cible.Nom}!");
            cible.RecevoirDegats(Degats); // Apply damage
        }

        // Override UtiliserCompetence to apply Wizard's special skill
        public override void UtiliserCompetence(Personnage cible)
        {
            if (!competenceUtilisee) // Check if special ability has been used
            {
                Debug.Log($"{Nom} casts a powerful spell on {cible.Nom}!");
                cible.RecevoirDegats(Degats + 10); // Apply additional damage as part of the special skill
                competenceUtilisee = true; // Mark competence as used
            }
            else
            {
                Debug.Log($"{Nom} has already used their special skill!");
            }
        }
    }
}
