using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start ()
    {
        // push the pipes 1 unit further to make the pipes completely vanish before being destroyed
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    private void Update ()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            // destroy the pipes when they moved out of the game screen
            Destroy(gameObject);
        }
    }
}
