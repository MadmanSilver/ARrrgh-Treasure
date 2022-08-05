using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Niantic.ARDK.Utilities.Permissions;

public class MenuController : MonoBehaviour
{
    public GameObject popup;

    private int tut;

    void Start() {
        if (PlayerPrefs.HasKey("tutorial")) {
            tut = PlayerPrefs.GetInt("tutorial");
        } else {
            tut = 0;
            PlayerPrefs.SetInt("tutorial", 0);
        }
    }

    public void Play() {
        PermissionRequester.RequestPermission(ARDKPermission.FineLocation, OnPermissionRequested);
    }

    void OnPermissionRequested(PermissionStatus status) {
        switch (status) {
            case PermissionStatus.Granted:
                if (tut == 1) {
                    SceneManager.LoadScene(1);
                } else {
                    SceneManager.LoadScene(3);
                }
                break;

            case PermissionStatus.Denied:
                popup.SetActive(true);
                break;
            
            default:
                popup.SetActive(true);
                break;
        }
    }

    public void StartLocalize() {
        SceneManager.LoadScene(2);
    }
}
