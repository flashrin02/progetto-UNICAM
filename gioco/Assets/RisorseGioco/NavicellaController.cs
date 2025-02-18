using UnityEngine;

public class NavicellaController : MonoBehaviour
{
    public float velocitaBase = 5f;      // Velocità normale della navicella
    public float velocitaBoost = 10f;    // Velocità aumentata col tasto destro
    public float durataBoost = 3f;       // Durata del boost
    public float scattoIntensita = 5f;   // Intensità dello scatto in avanti
    public float scattoVelocita = 5f;    // Velocità di transizione allo scatto
    public float velocitaVerticale = 3f; // Velocità di movimento su/giù
    public float velocitaLaterale = 3f;  // Velocità di movimento laterale
    public float limiteLaterale = 5f;    // Limite massimo per il movimento a destra/sinistra

    public float inclinazioneLaterale = 20f; // Inclinazione max a destra/sinistra
    public float inclinazioneVerticale = 15f; // Inclinazione max su/giù
    public float rotazioneVelocita = 5f; // Velocità della rotazione fluida

    public float smoothTime = 0.1f;  // Tempo di interpolazione per movimento fluido

    private float velocitaAttuale;
    private float tempoBoost = 0f;
    private float targetX;
    private float velocitaX;
    private bool inTurbo = false;

    void Start()
    {
        velocitaAttuale = velocitaBase;
        targetX = transform.position.x;
    }

    void Update()
    {
        // Movimento in avanti (se Turbo attivo, aumenta)
        if (inTurbo)
        {
            float nuovaVelocita = Mathf.Lerp(velocitaAttuale, velocitaBoost + scattoIntensita, Time.deltaTime * scattoVelocita);
            transform.position += transform.forward * nuovaVelocita * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * velocitaAttuale * Time.deltaTime;
        }

        // Movimento verticale (su/giù)
        float inputVerticale = Input.GetAxis("Vertical");
        transform.position += transform.up * inputVerticale * velocitaVerticale * Time.deltaTime;

        // Movimento laterale fluido
        float inputLaterale = Input.GetAxis("Horizontal");
        if (Mathf.Abs(inputLaterale) > 0.1f)
        {
            targetX += inputLaterale * velocitaLaterale * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, -limiteLaterale, limiteLaterale);
        }

        // Interpolazione fluida del movimento laterale
        float nuovaX = Mathf.SmoothDamp(transform.position.x, targetX, ref velocitaX, smoothTime);
        transform.position = new Vector3(nuovaX, transform.position.y, transform.position.z);

        // 🔹 ROTAZIONE: Calcola l'inclinazione in base ai movimenti
        float inclinazioneX = -inputVerticale * inclinazioneVerticale;
        float inclinazioneZ = -inputLaterale * inclinazioneLaterale;

        // Applica una rotazione fluida
        Quaternion rotazioneTarget = Quaternion.Euler(inclinazioneX, 0, inclinazioneZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotazioneTarget, Time.deltaTime * rotazioneVelocita);

        // Attiva Turbo con il tasto destro
        if (Input.GetMouseButtonDown(1) && !inTurbo)
        {
            inTurbo = true;
            velocitaAttuale = velocitaBoost;
            tempoBoost = Time.time + durataBoost;
        }

        // Disattiva Turbo dopo il tempo massimo
        if (Time.time >= tempoBoost && inTurbo)
        {
            inTurbo = false;
            velocitaAttuale = velocitaBase;
        }


    }

    
}
