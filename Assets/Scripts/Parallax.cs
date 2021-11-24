using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.05f;
    private void Awake ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // moving the material
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
