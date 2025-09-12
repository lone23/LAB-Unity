using UnityEngine;

public class Esercizio2 : MonoBehaviour
{

    public GameObject atomo;
    public GameObject moneta;
    





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3[] posMoneta = new Vector3[5];
        Vector3[] posAtomo = new Vector3[5]; 

        for (int i = 0; i < 5; i++)
        {

            Vector3 tempPostMoneta = new Vector3(Random.Range(-7f, 2f), 2, Random.Range(-1f, 8f));

            for (int j = 0; j < posMoneta.Length; j++)
            {
                while(posMoneta[j] == tempPostMoneta)
                {
                    tempPostMoneta = new Vector3(Random.Range(-7f, 2f), 2, Random.Range(-1f, 8f));
                }
            }

            Instantiate(moneta, tempPostMoneta, Quaternion.identity);
            posMoneta[i] = tempPostMoneta;

            Vector3 tempPostAtomo = new Vector3(Random.Range(-7f, 2f), 2, Random.Range(-1f, 8f));

            for (int j = 0; j < posAtomo.Length; j++)
            {
                while (posAtomo[j] == tempPostAtomo)
                {
                    tempPostAtomo = new Vector3(Random.Range(-7f, 2f), 2, Random.Range(-1f, 8f));
                }
            }


            Instantiate(atomo, new Vector3(Random.Range(-7f, 2f),2,Random.Range(-1f, 8f)), Quaternion.identity);
            posAtomo[i] = tempPostAtomo;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
