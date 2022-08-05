using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using Niantic.ARDK.Utilities.Input.Legacy;

public class FightManager : MonoBehaviour
{
    public GameObject cam;
    public GameObject targetPrefab;
    public GameObject chestPrefab;
    public int targetCount = 3;
    public float targetRange = 5.0f;
    public float targetHeight = 2.0f;
    public UnityEvent OnFightStart = new UnityEvent();
    public UnityEvent OnFightEnd = new UnityEvent();

    private int targetsLeft = 0;

    void Start() {
        StartCoroutine(PlaceChest());
    }

    private IEnumerator PlaceChest() {
        RaycastHit hit;
        while (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, targetRange))
            yield return new WaitForSeconds(1);
        var chest = Instantiate(chestPrefab, hit.point - (Vector3.forward * 0.2f), Quaternion.identity, transform);
    }

    void Update() {
        if (PlatformAgnosticInput.touchCount <= 0)
            return;

        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Vector3 origin = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.GetComponent<Camera>().nearClipPlane));
            if (Physics.Raycast(origin, cam.transform.forward, out hit)) {
                if (hit.collider.gameObject.tag != "Chest")
                    return;

                OnFightStart.Invoke();
            }
        }
    }

    public void StartFight() {
        for (int i = 0; i < targetCount; i++) {
            RaycastHit hit;
            Vector3 direction = Random.rotation.eulerAngles;
            if (Physics.Raycast(cam.transform.position, direction, out hit, targetRange)) {
                var tar = Instantiate(targetPrefab, hit.point - (direction.normalized * 0.3f), Quaternion.identity, transform);
                tar.transform.LookAt(cam.transform);
            } else {
                i--;
                continue;
            }

            targetsLeft++;
        }
    }

    public void OnTargetHit() {
        targetsLeft--;

        if (targetsLeft == 0) {
            OnFightEnd.Invoke();
        }
    }

    public void OpenMap() {
        SceneManager.LoadScene(1);
    }
}
