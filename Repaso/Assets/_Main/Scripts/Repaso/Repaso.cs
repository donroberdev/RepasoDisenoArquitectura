using UnityEngine;

public class Repaso : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _collider ; 

    public int entero = 1;

    void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entero = 5;
        Debug.Log(entero);
        //_collider.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        entero = 10;
        Debug.Log(entero);
    }

    void FixUpdate()
    {
        
    }
}
