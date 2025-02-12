using UnityEngine;

public class NavicellaController : MonoBehaviour
{
    public float velocitaBase = 5f;      // Velocità normale della navicella
    public float velocitaBoost = 10f;    // Velocità aumentata col tasto destro
    public float durataBoost = 3f;       // Durata del boost
    public float velocitaVerticale = 3f; // Velocità di movimento su/giù
    public float velocitaLaterale = 3f;  // Velocità di movimento laterale
    public float limiteLaterale = 5f;    // Limite massimo per il movimento a destra/sinistra

    public float smoothTime = 0.1f;  // Tempo di interpolazione per movimento fluido

    private float velocitaAttuale;
    private float tempoBoost = 0f;
    private float targetX;           // Posizione target per il movimento laterale
    private float velocitaX;         // Per la funzione SmoothDamp

    public Transform cameraFollowPoint; // Punto di riferimento per la camera

    void Start()
    {
        velocitaAttuale = velocitaBase;
        targetX = transform.position.x; // Inizializza la posizione target
    }

    void Update()
    {
        // Movimento in avanti costante
        transform.position += transform.forward * velocitaAttuale * Time.deltaTime;

        // Movimento verticale (su/giù)
        float movimentoVerticale = Input.GetAxis("Vertical"); // W/S o Frecce su/giù
        transform.position += transform.up * movimentoVerticale * velocitaVerticale * Time.deltaTime;

        // Movimento laterale fluido
        float inputLaterale = Input.GetAxis("Horizontal");
        if (Mathf.Abs(inputLaterale) > 0.1f) // Controlla se c'è input
        {
            targetX += inputLaterale * velocitaLaterale * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, -limiteLaterale, limiteLaterale);
        }

        // Interpolazione fluida tra la posizione attuale e la posizione target
        float nuovaX = Mathf.SmoothDamp(transform.position.x, targetX, ref velocitaX, smoothTime);
        transform.position = new Vector3(nuovaX, transform.position.y, transform.position.z);

        // Boost con tasto destro del mouse
        if (Input.GetMouseButtonDown(1)) // 1 = Tasto destro del mouse
        {
            velocitaAttuale = velocitaBoost;
            tempoBoost = Time.time + durataBoost;
        }

        // Ripristino della velocità dopo il boost
        if (Time.time >= tempoBoost && velocitaAttuale == velocitaBoost)
        {
            velocitaAttuale = velocitaBase;
        }
    }
}
