using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private ParticleSystem popEffect;
    private Rigidbody balloonRb;
    private Renderer renderer;

    public float minSpeed;
    public float maxSpeed;
    public float xSpawnRange;
    public float ySpawnPos;

    void Start()
    {
        balloonRb = GetComponent<Rigidbody>();
        popEffect = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();

        transform.position = RandomSpawnPos();
        balloonRb.AddForce(RandomForce(), ForceMode.Impulse);
        var main = popEffect.main;
        main.startColor = renderer.material.color;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(!other.gameObject.CompareTag(gameObject.tag))
        {
            DestroyBalloon();
        }
    }

    private void DestroyBalloon()
    {
        renderer.enabled = false;
        popEffect.Play();
        Destroy(gameObject, popEffect.main.duration);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, 0);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
}
