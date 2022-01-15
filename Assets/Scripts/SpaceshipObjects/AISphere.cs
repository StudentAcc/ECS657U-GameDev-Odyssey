using UnityEngine;

public class AISphere : MonoBehaviour {

    public GameObject sphere;
    public GameObject PauseMenu;
    public GameObject ControlsMenu;
    public GameObject VolumeMenu;
    public GameObject DifficultyMenu;


    // AI sphere rotates and moves up and down
    void Update()
    {
        
        if (!PauseMenu.activeInHierarchy && !ControlsMenu.activeInHierarchy && !VolumeMenu.activeInHierarchy && !DifficultyMenu.activeInHierarchy)
        {
            sphere.transform.Rotate(0f, 25f * Time.deltaTime, 0f);
            sphere.transform.Translate(0f, Mathf.Sin(Time.time) / 100f, 0f);
        }
        
    }
}
