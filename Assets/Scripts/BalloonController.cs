using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private Rigidbody balloonRb;
    public float minSpeed;
    public float maxSpeed;
    public float xSpawnRange;
    public float ySpawnPos;

    void Start()
    {
        balloonRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        balloonRb.AddForce(RandomForce(), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        Destroy(gameObject);
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
