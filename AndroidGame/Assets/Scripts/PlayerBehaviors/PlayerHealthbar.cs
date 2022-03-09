using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider PlayerHP;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        PlayerHP.gameObject.SetActive(health < maxHealth);
        PlayerHP.value = health;
        PlayerHP.maxValue = maxHealth;
        PlayerHP.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, PlayerHP.normalizedValue);
    }

    void Update()
    {
        Offset = new Vector3(0, 1, 0);
        PlayerHP.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}