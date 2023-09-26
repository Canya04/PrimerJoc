using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text_puntuacio;

    [SerializeField]
    TextMeshProUGUI text_guanyar;

    [SerializeField]
    float speed;

    int points = 0;
    

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        text_guanyar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
        
        if(points == 6) 
        {
            text_guanyar.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
          
        if (collision.tag.Equals("Pickup"))
        {
            points++;    
            text_puntuacio.text = points.ToString();
            Destroy(collision.gameObject);

        }
    }
}
