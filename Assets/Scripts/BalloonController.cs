using UnityEngine;

public class BalloonController : MonoBehaviour
{
    private GameManager gameManager;
    private ParticleSystem popEffect;
    private Rigidbody balloonRb;

    public float minSpeed;
    public float maxSpeed;
    public float xSpawnRange;
    public float ySpawnPos;

    void Start()
    {
        balloonRb = GetComponent<Rigidbody>();
        popEffect = GetComponent<ParticleSystem>();

        transform.position = RandomSpawnPos();
        balloonRb.AddForce(RandomForce(), ForceMode.Impulse);
        var main = popEffect.main;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyBalloon()
    {
        GetComponent<Renderer>().enabled = false;
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
