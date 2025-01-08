using UnityEngine;

public class TorchSequence : MonoBehaviour
{
    public Torch[] torches;  
    private int currentTorchIndex = 0;  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  
        {
            if (IsNearTorch(torches[currentTorchIndex]))
            {
                torches[currentTorchIndex].LightTorch();
                currentTorchIndex++;  

                if (currentTorchIndex >= torches.Length)
                {
                    Debug.Log("Tutte le torce sono accese");
                }
            }
        }
    }

    private bool IsNearTorch(Torch torch)
    {
        float distance = Vector3.Distance(transform.position, torch.transform.position);
        return distance < 3f;  
    }
}
