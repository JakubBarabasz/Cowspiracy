using UnityEngine;

public class SuperDuperFrickingChest: MonoBehaviour {
  public int howManyBullets {
    get;
  } = 6;
  public int howManyDiscs {
    get;
  } = 6;

  void OnCollisionEnter2D(Collision2D collision) {

    var player = collision.collider.GetComponent < PlayerBehaviour > ();
    if (player) {
      player.GetHealth(10);
    }
  }

}