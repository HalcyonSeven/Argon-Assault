using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // destroy instatiated deathVFX
        Destroy(gameObject,timeToDestroy);
    }
}
