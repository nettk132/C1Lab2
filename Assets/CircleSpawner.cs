using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10;
    public float radius = 5f;

    void Start()
    {
        MakeCircle();
    }

    void MakeCircle()
    {
        float angleIncrement = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = angleIncrement * i;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            Vector3 position = new Vector3(x, 3, z);
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
