using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
            door.transform.position = new Vector3(0, -10, 0);
    }



}
