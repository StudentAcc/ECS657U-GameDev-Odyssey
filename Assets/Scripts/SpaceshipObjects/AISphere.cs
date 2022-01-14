using UnityEngine;

public class AISphere : MonoBehaviour {

    public GameObject sphere;

    // AI sphere rotates and moves up and down
    void Update()
    {
        sphere.transform.Rotate(0f, 25f * Time.deltaTime, 0f);
        sphere.transform.Translate(0f, Mathf.Sin(Time.time)/100f, 0f);
    }
}
