using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Button : MonoBehaviour, IApribile
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

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag.Equals("Card"))
        {
            Apri();

        }


    }

    public void Apri()
    {
        door.transform.position = new Vector3(0, -10, 0);
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
