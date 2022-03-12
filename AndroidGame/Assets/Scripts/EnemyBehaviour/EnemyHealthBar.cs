using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float offX = 0;
    public float offY = 1;
    public float offZ = 0;
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
        Offset = new Vector3(offX, offY, offZ);
        EnHP.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
