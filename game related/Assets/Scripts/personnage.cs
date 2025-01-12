using System;
using UnityEngine;

namespace Game
{
    public class Personnage : MonoBehaviour
    {
        [SerializeField] private string nom;
        public int pointsDeVie;
        public int degats;
        [SerializeField] private int niveau;
        [SerializeField] private int experience;
        public bool competenceUtilisee;

        public string Nom => nom;
        public int PointsDeVie => pointsDeVie;
        public int Degats => degats;
        public int Niveau => niveau;
        public int Experience => experience;

        public Personnage(string nom, int pointsDeVie, int degats)
        {
            this.nom = nom;
            this.pointsDeVie = pointsDeVie;
            this.degats = degats;
            this.niveau = 1;
            this.experience = 0;
            this.competenceUtilisee = false;
        }

        public void Init(string nom, int pointsDeVie, int degats)
        {
            this.nom = nom;
            this.pointsDeVie = pointsDeVie;
            this.degats = degats;
            this.niveau = 1;
            this.experience = 0;
            this.competenceUtilisee = false;
        }

        public void RecevoirDegats(int degats)
        {
            pointsDeVie -= degats;
            pointsDeVie = Math.Max(pointsDeVie, 0);
            Debug.Log($"{nom} received {degats} damage. Remaining health: {pointsDeVie}");
        }

        public bool EstVivant() => pointsDeVie > 0;

        public void GagnerExperience(int xp)
        {
            experience += xp;
            if (experience >= 100)
            {
                niveau++;
                experience = 0;
                degats += 5;
                competenceUtilisee = false;
                Debug.Log($"{nom} leveled up to {niveau}!");
            }
        }

        public virtual void Attaquer(Personnage cible)
        {
            if (cible == null) return;
            cible.RecevoirDegats(degats);
            Debug.Log($"{nom} attacked {cible.nom} for {degats} damage.");
        }

        public virtual void UtiliserCompetence(Personnage cible)
        {
            if (competenceUtilisee)
            {
                Debug.Log($"{nom} has already used their special ability.");
                return;
            }

            int specialDamage = degats * 2;
            cible.RecevoirDegats(specialDamage);
            competenceUtilisee = true;

            Debug.Log($"{nom} used their special ability on {cible.nom}, dealing {specialDamage} damage!");
        }

        public void ReinitialiserCompetence() => competenceUtilisee = false;
    }
}
