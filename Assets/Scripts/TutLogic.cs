using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutLogic : MonoBehaviour
{
    public GameObject xMark;
    public GameObject placeButton;
    public GameObject chest;

    private bool marked = false;

    // Update is called once per frame
    void Update()
    {
        if (marked)
            return;

        if (xMark.activeInHierarchy) {
            marked = true;
            placeButton.SetActive(true);
        }
    }

    public void OnPlaced() {
        placeButton.SetActive(false);

        chest.SetActive(true);
        chest.transform.position = xMark.transform.position;
        chest.transform.rotation = xMark.transform.rotation;
        xMark.SetActive(false);

        ChestManager chestMan = chest.GetComponent(typeof(ChestManager)) as ChestManager;
        chestMan.Tutorial();
    }

    public void StartFight() {
        SceneManager.LoadScene(4);
    }
}
