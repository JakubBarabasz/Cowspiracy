using UnityEngine;
using Random = System.Random;

public class AddKnife : MonoBehaviour
{
    int minValue = 1;
    int maxValue = 6;

    Random rnd = new Random();
    private int knifes;
    void Start()
    {
        knifes = rnd.Next(minValue, maxValue);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerShooting>().GetKnife(knifes);
            Destroy(gameObject);
        }
    }
}
