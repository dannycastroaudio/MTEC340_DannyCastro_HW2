using UnityEngine;

public class BrickBehaviour : MonoBehaviour //it's mad at my camelcasing??
{
    private void OnCollisionEnter2D (Collision2D collision) //must be OnCollision2D bc this is a 2D game
    {
        if (collision.gameObject.CompareTag("Ball")) 
            //if the game object with this script collides with something with the tag ball,
            //then it will destroy itself
        { 
            Destroy(gameObject); //destroy the game object duh
        }
    }
}
