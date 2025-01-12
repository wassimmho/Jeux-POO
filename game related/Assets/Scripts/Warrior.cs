using System.Collections;
using UnityEngine;

namespace Game
{
    public class Warrior : Personnage
    {
        // Constructor correctly calling base class constructor
        public Warrior(string nom) : base(nom, 100, 20) // Adjusted health and damage
        {
        }

        // Override Attaquer to add specific behavior for Warrior's attack
        public override void Attaquer(Personnage cible)
        {
            if (cible == null) return;

            // Debug: Before attacking, print the health of both characters
            Debug.Log($"{Nom} is attacking {cible.Nom} with {Degats} damage. {cible.Nom} health before: {cible.PointsDeVie}");

            cible.RecevoirDegats(Degats); // Apply damage

            // Debug: After attacking, print the health of the target
            Debug.Log($"{Nom} attacked {cible.Nom} for {Degats} damage. {cible.Nom} health after: {cible.PointsDeVie}");
        }

        public override void UtiliserCompetence(Personnage cible)
        {
            if (!competenceUtilisee) // Check if special ability has been used
            {
                // Debug: Before using special ability, print the health of both characters
                Debug.Log($"{Nom} is using Thunder Bolt on {cible.Nom}, {cible.Nom} health before: {cible.PointsDeVie}");

                cible.RecevoirDegats(Degats * 2); // Double damage for special skill
                competenceUtilisee = true; // Mark competence as used

                // Debug: After using special ability, print the health of the target
                Debug.Log($"{Nom} used Thunder Bolt on {cible.Nom}, dealing {Degats * 2} damage. {cible.Nom} health after: {cible.PointsDeVie}");
            }
            else
            {
                Debug.Log($"{Nom} has already used his special skill!");
            }
        }

    }
}
