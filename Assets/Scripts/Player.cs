using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // call animatesprite every 0.15s
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        // reset player's state when player's enabled
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update() { 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            direction = Vector3.up * strength;
        }
        // getting touch input for mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        // make the bird go forward along the y axis
        // gravity is an acceleration (meter per second squared) so we need to multiply it by deltatime twice
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite ()
    {
        // iterating through the sprites array to make animation
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D (Collider2D other) { 
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Score")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
