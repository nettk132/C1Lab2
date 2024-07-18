using UnityEngine;

public class CircleSpawner2 : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10;
    public float radius = 10f;
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

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
            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            
            // Rotate the object around the circle
            float rotationAngle = angle + 90f; // Adjust 90 degrees to start the rotation from the top
            obj.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}
