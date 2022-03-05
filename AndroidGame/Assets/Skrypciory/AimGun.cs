using UnityEngine;
public class AimGun : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject magicWand;
    public GameObject magicBulletSheet;
    public GameObject fireWand;
    public GameObject fireBulletSheet;
    public GameObject fireBulletStart;
    public GameObject magicBulletStart;
    public bool magicWandinHands = false;
    public bool fireWandOninHands = false;
    public int activefireWand;
    public int activemagicWand;
    public bool activeBoolWand;
    public float bulletSpeed;
    private Vector3 target;
    void Start()
    {
        Cursor.visible = true;
        magicWand.gameObject.SetActive(false);
        fireWand.gameObject.SetActive(false);
    }

    void Update()
    {
    


        magicWandOnHand();
        fireWandOnHand();
        void magicWandOnHand()
        {
            if (!fireWandOninHands)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    this.fireWandOninHands = false;
                    fireWand.gameObject.SetActive(false);
                    this.magicWandinHands = true;
                    activemagicWand++;
                    Debug.Log("Button Pressed" + activemagicWand);
                }
                if (activemagicWand % 2 == 0)
                {
                    this.magicWandinHands = false;
                    activeBoolWand = false;
                    magicWand.gameObject.SetActive(false);
                    crosshairs.SetActive(false);
                }
                else
                {
                    activeBoolWand = true;
                    magicWand.gameObject.SetActive(true);
                    crosshairs.SetActive(true);
                    Cursor.visible = false;
                    crosshairs.SetActive(true);

                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
                    crosshairs.transform.position = new Vector2(target.x, target.y);

                    Vector3 difference = target - magicWand.transform.position;
                    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    magicWand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

                    if (Input.GetMouseButtonUp(0) && Time.timeScale == 1 && activeBoolWand == true)
                    {
                        float distance = difference.magnitude;
                        Vector2 direction = difference / distance;
                        direction.Normalize();
                        fireBullet(direction, rotationZ);
                    }

                    void fireBullet(Vector2 direction, float rotationZ)
                    {
                        for(int i = 0; i<5; i++)
                        {
                            GameObject BULLET = Instantiate(magicBulletSheet);
                            BULLET.transform.position = magicBulletStart.transform.position;
                            BULLET.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                            BULLET.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                            Destroy(BULLET, 2f);
                        }
                    }
                }
            }
        }
           

        void fireWandOnHand()
        {
            if (!magicWandinHands)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    magicWand.gameObject.SetActive(false);
                    this.magicWandinHands = false;
                    this.fireWandOninHands = true;
                    activefireWand++;
                    Debug.Log("Button Pressed" + activefireWand);
                }
                if (activefireWand % 2 == 0)
                {
                    this.fireWandOninHands = false;
                    activeBoolWand = false;
                    fireWand.gameObject.SetActive(false);
                    crosshairs.SetActive(false);
                }
                else
                {
                    activeBoolWand = true;
                    fireWand.gameObject.SetActive(true);
                    crosshairs.SetActive(true);
                    Cursor.visible = false;
                    crosshairs.SetActive(true);

                    target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
                    crosshairs.transform.position = new Vector2(target.x, target.y);

                    Vector3 difference = target - fireWand.transform.position;
                    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    fireWand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

                    if (Input.GetMouseButtonUp(0) && Time.timeScale == 1 && activeBoolWand == true)
                    {
                        float distance = difference.magnitude;
                        Vector2 direction = difference / distance;
                        direction.Normalize();
                        fireBullet(direction, rotationZ);
                    }

                    void fireBullet(Vector2 direction, float rotationZ)
                    {
                        GameObject BULLET = Instantiate(fireBulletSheet);
                        BULLET.transform.position = fireBulletStart.transform.position;
                        BULLET.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                        BULLET.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                        Destroy(BULLET, 2f);
                    }
                }
            }
        }
    }
}