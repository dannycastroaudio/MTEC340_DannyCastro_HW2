using UnityEngine;

public class BrickBehaviour : MonoBehaviour //it's mad at my camelcasing??
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _brickHit;
    [SerializeField] private AudioClip _brickBreak;
    
    private SpriteRenderer _spriteRenderer;
    
    public int BrickDestroyed = 3; //hit value needed to destroy brick
    private int _brickDamage = 0; //starter hit value of bricks

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_brickDamage == 1)
        {
            _spriteRenderer.color = Color.cyan;
        }

        if (_brickDamage == 2)
        {
            _spriteRenderer.color = Color.yellow;
        }
    }
    private void OnCollisionEnter2D (Collision2D collision) //must be OnCollision2D bc this is a 2D game
    {
        if (collision.gameObject.CompareTag("Ball")) 
            //if the game object with this script collides with something with the tag ball,
            //then it will destroy itself
        {
            _brickDamage++;

            if (_brickDamage >= BrickDestroyed)
            {
                _spriteRenderer.color = Color.darkRed;
                _audioSource.PlayOneShot(_brickBreak);
                Destroy(gameObject, 0.4f); //destroy the game object duh
            }
            else
            {
                _audioSource.PlayOneShot(_brickHit);
            }
            
        }
        
    }
}
