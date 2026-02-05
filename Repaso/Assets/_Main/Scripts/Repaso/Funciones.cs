using Unity.VisualScripting;
using UnityEngine;

public class Funciones : MonoBehaviour
{

    private ListaEstudiantes _listaEstudiantes = new ListaEstudiantes();

    [SerializeField]
    private int _suma;

    BoxCollider _boxCollider;

    private void Awake() 
    {
        _boxCollider = GetComponent<BoxCollider>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Myfuncion();
        _suma = SumaDeEnteros(5, 10);
        Debug.Log(_listaEstudiantes.Obtener(EstudiantesId.Juan));

        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Myfuncion()
    {
        Debug.Log("Mi primera funcion");
    }

    public int SumaDeEnteros(int a, int b)
    {
        return a + b;
    }

}
