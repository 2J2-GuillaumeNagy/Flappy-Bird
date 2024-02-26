using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementObjet : MonoBehaviour
{
    public float vitesse;
    public float positioinFin;
    public float positionDebut;
    public float deplacementAleatoire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // D�placer le gameObject � une certaine vitesse
        transform.Translate(vitesse, 0, 0);

        // On v�rifie si le gameObject sort de l'�cran du c�t� gauche
        if(transform.position.x <= positioinFin)
        {
            // Si oui, on le replace du c�t� droit
            float valeurAleatoireY = Random.Range(-deplacementAleatoire, deplacementAleatoire);
            transform.position = new Vector2(positionDebut, valeurAleatoireY);
        }
    }
}
