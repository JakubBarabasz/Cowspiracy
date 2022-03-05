using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Bulletammo;
    public GameObject[] Discammo;
    public GameObject bulletOne;
    public GameObject bulletTwo;
    public Transform LaunchOffSet;
    public Transform LaunchDisk;
    public GameObject chest;

    public int ammoAmout;
    public int discAmout;
    void Start()
    {
        for (int i = 0; i <= 14; i++)
        {
            Bulletammo[i].gameObject.SetActive(false);
            Discammo[i].gameObject.SetActive(false);
        }

    }
    void Update()
    {
        /**Pierwszy rodzaj pocisków naboje
         * 
         */
        if (Input.GetKeyDown(KeyCode.E) && ammoAmout > 0)
        {
            var newBulletOne = Instantiate(bulletOne) as GameObject;
            newBulletOne.transform.position = LaunchOffSet.position;
            newBulletOne.transform.rotation = transform.rotation;
            ammoAmout -= 1;
            Bulletammo[ammoAmout].gameObject.SetActive(false);
            Destroy(newBulletOne, 1);
        }
        /**Drugi rodzaj pocisków dyski
         * 
         */
        if (Input.GetMouseButtonDown(1) && discAmout > 0)
        {
            var newBulletTwo = Instantiate(bulletTwo) as GameObject;
            newBulletTwo.transform.position = LaunchDisk.position;
            newBulletTwo.transform.rotation = transform.rotation;
            discAmout -= 1;
            Discammo[discAmout].gameObject.SetActive(false);
            Destroy(newBulletTwo, 6);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoAmout = 12;
            discAmout = 12;
            for (int i = 0; i <= 12; i++)
            {
                Bulletammo[i].gameObject.SetActive(true);
                Discammo[i].gameObject.SetActive(true);
            }
        }
    }
    NormalChest nC = new NormalChest();
    RareChest rC = new RareChest();
    SuperDuperFrickingChest sC = new SuperDuperFrickingChest();

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "NormalChest")
        {
            ammoAmout += nC.howManyBullets;
            discAmout += nC.howManyDiscs;
            for (int i = 0; i <= ammoAmout - 1; i++)
            {
                Bulletammo[i].gameObject.SetActive(true);
            }
            for (int i = 0; i <= discAmout - 1; i++)
            {
                Discammo[i].gameObject.SetActive(true);
            }
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "RareChest")
        {
            ammoAmout += rC.howManyBullets;
            discAmout += rC.howManyDiscs;
            for (int i = 0; i <= ammoAmout - 1; i++)
            {
                Bulletammo[i].gameObject.SetActive(true);
            }
            for (int i = 0; i <= discAmout - 1; i++)
            {
                Discammo[i].gameObject.SetActive(true);
            }
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "SuperDuperFrickingChest")
        {

            ammoAmout += sC.howManyBullets;
            discAmout += sC.howManyDiscs;
            for (int i = 0; i <= ammoAmout - 1; i++)
            {
                Bulletammo[i].gameObject.SetActive(true);
            }
            for (int i = 0; i <= discAmout - 1; i++)
            {
                Discammo[i].gameObject.SetActive(true);
            }
            Destroy(coll.gameObject);
        }
    }

}