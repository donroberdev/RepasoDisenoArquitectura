    public enum EstudiantesId
    {
        Rober,
        Ana,
        Luis,
        Maria,
        Carlos,
        Juan
    }
public class ListaEstudiantes 
{
    public string[] estudiantes = new string[]
    {
        "Rober",
        "Ana",
        "Luis",
        "Maria",
        "Carlos",
        "Juan"
    };



    public string Obtener(EstudiantesId id)
    {
        return estudiantes[(int)id];
    }
}
