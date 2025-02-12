using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // La navicella
    public Vector3 offset = new Vector3(0, 2, -5); // Offset per mantenere la distanza

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target.position); // Mantiene la telecamera orientata verso la navicella
        }
    }
}
