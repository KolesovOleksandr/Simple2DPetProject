using UnityEngine;

public class Expirience : MonoBehaviour
{
    [SerializeField] private float exp = 20f;
    
    public float ExpirienceCost
    {
        get
        {
            return exp; 
        }
    }
}
