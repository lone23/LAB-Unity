using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject atmoPrefab;

    [SerializeField]
    Vector3 initPosAtmo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(atmoPrefab,initPosAtmo,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
