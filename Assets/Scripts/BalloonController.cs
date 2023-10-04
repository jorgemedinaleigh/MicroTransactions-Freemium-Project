using UnityEngine;

public class BalloonController : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem popEffect;
    private Rigidbody balloonRb;

    public float minSpeed;
    public float maxSpeed;
    public float xSpawnRange;
    public float ySpawnPos;
    public float zSpawnRange;

    void Start()
    {
        balloonRb = GetComponent<Rigidbody>();

        transform.position = RandomSpawnPos();
        balloonRb.AddForce(RandomForce(), ForceMode.Impulse);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void PopBalloon() 
    {
        Destroy(gameObject);
        Instantiate(popEffect, transform.position, popEffect.transform.rotation);
        gameManager.UpdateScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, Random.Range(0,-zSpawnRange));
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
}
