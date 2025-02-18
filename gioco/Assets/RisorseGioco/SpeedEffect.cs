using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public float baseSpeed = 50f;
    public float maxSpeed = 200f;
    public float acceleration = 2f;
    
    private ParticleSystem ps;
    private ParticleSystem.MainModule main;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        main = ps.main;
    }

    void Update()
    {
        float speed = Mathf.Lerp(baseSpeed, maxSpeed, acceleration * Time.deltaTime);
        main.startSpeed = speed;
    }
}
