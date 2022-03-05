using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider EnHP;
    public Color Low;
    public Color High;
    public Vector3 Offset;


    public void SetHealth(float health, float maxHealth)
    {
        EnHP.gameObject.SetActive(health < maxHealth);
        EnHP.value = health;
        EnHP.maxValue = maxHealth;

        EnHP.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, EnHP.normalizedValue);
    }

    void Update()
    {
        Offset = new Vector3(0, 1, 0);
        EnHP.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
