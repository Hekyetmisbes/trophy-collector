using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FenerbahceLogo : MonoBehaviour
{
    const float ImpulseForceMagnitude = 2.0f;

    bool collecting = false;
    GameObject targetTrophy;

    Rigidbody2D rb2d;
    FenerTheCollector fenerTheCollector;

    TextMeshProUGUI scoreText;

    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;

        rb2d = GetComponent<Rigidbody2D>();
        fenerTheCollector = Camera.main.GetComponent<FenerTheCollector>();

    }

    void OnMouseDown()
    {
        if (!collecting)
        {
            GoToNextPickUp();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == targetTrophy)
        {
            fenerTheCollector.RemovePickup(targetTrophy);
            score++;
            scoreText.text = "Score: " + score;
            rb2d.velocity = Vector2.zero;
            GoToNextPickUp();
        }
    }

    void GoToNextPickUp()
    {
        targetTrophy = fenerTheCollector.TargetPickup;
        if (targetTrophy != null)
        {
            Vector2 direction = new Vector2(
                targetTrophy.transform.position.x - transform.position.x,
                targetTrophy.transform.position.y - transform.position.y);
            direction.Normalize();
            rb2d.AddForce(direction * ImpulseForceMagnitude, ForceMode2D.Impulse);
        }
    }
}
