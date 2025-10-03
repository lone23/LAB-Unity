using UnityEngine;

public class Esercizio2 : MonoBehaviour
{
    public GameObject moneta;
    





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3[] posMoneta = new Vector3[5];

        for (int i = 0; i < 5; i++)
        {

            Vector3 tempPostMoneta = new Vector3(Random.Range(-7f, 2f), 2.5f, Random.Range(-1f, 8f));

            for (int j = 0; j < posMoneta.Length; j++)
            {
                while(posMoneta[j] == tempPostMoneta)
                {
                    tempPostMoneta = new Vector3(Random.Range(-7f, 2f), 2.5f, Random.Range(-1f, 8f));
                }
            }

            Instantiate(moneta, tempPostMoneta, Quaternion.identity);
            posMoneta[i] = tempPostMoneta;


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
