using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementColonnes : MonoBehaviour
{
    public float vitesse;
    public float sortie;
    public float entree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacer les colonnes
        transform.Translate(vitesse, 0, 0);

        // Lorsque les colonnes sortent de l'écran à gauche, elles réaparaissent à droite
        if(transform.position.x <= sortie)
        {
            transform.position = new Vector2(entree, Random.Range(-2.5f, 2.5f));
        }
    }
}
