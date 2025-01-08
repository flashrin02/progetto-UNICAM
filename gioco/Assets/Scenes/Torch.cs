using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isLit = false;  
    public GameObject flame;   

    public void LightTorch()
    {
        if (!isLit)
        {
            isLit = true;
            flame.SetActive(true); 
        }
    }

    public void ExtinguishTorch()
    {
        if (isLit)
        {
            isLit = false;
            flame.SetActive(false);  
        }
    }
}
