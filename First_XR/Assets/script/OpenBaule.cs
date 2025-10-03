using UnityEngine;

public class OpenBaule : MonoBehaviour
{
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
        GameObject Baule = GameObject.Find("BauleUp");
        Baule.transform.Rotate(0f, 0f, 90f);
    }

}
