using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ControleFlappy : MonoBehaviour
{
    public Sprite imgFlappyNormal;
    public Sprite imgFlappyBlesse;

    public GameObject piece;
    public GameObject packVie;
    public GameObject champignon;

    float vitesseX;
    float vitesseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si d ou la fl�che de droite est enfonc�e, faire avancer Flappy
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            vitesseX = 1.5f;
        }
        //Si a ou la fl�che de gauche est enfonc�e, faire reculer Flappy
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            vitesseX = -4f;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }

        //Lorsque w est enfonc�e, faire sauter Flappy une fois
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            vitesseY = 5f;
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }

        //Appliquer les d�placements
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Flappy touche une colonne
        if (collision.gameObject.name == "Colonne")
        {
            //Il devient bless�
            GetComponent<SpriteRenderer>().sprite = imgFlappyBlesse;
        }

        //Flappy touche une pi�ce
        if (collision.gameObject.name == "PieceOr")
        {
            //La pi�ce disparait pendant un instant
            collision.gameObject.SetActive(false);
            Invoke("ReaparitionPiece", 2f);
        }

        //Flappy touche un pack de vie
        if (collision.gameObject.name == "PackVie")
        {
            //Flappy est gu�ri
            GetComponent<SpriteRenderer>().sprite = imgFlappyNormal;

            //Le pack disparait pendant un instant
            collision.gameObject.SetActive(false);
            Invoke("ReaparitionPackVie", 2f);
        }

        //Flappy touche un champignon
        if (collision.gameObject.name == "Champigon")
        {
            //Flappy grossi
            transform.localScale *= 1.3f;

            //Le champignon disparait pendant un instant
            collision.gameObject.SetActive(false);
            Invoke("ReaparitionChampignon", 2f);
        }

    }

    //R�aparition de la pi�ce
    void ReaparitionPiece()
    {
        //La pi�ce r�aparait avec une position verticale al�atoire
        float positionYAlea = Random.Range(-1.5f, 1.5f);
        piece.transform.position = new Vector2(piece.transform.position.x, positionYAlea);

        piece.SetActive(true);
    }

    //R�aparition du pack de vie
    void ReaparitionPackVie()
    {
        packVie.SetActive(true);
    }

    //R�aparition du champignon
    void ReaparitionChampignon()
    {
        //Flappy reprend sa taille normale
        transform.localScale /= 1.3f;

        champignon.SetActive(true);
    }
}
