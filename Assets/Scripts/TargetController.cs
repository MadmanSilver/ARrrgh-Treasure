using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Projectile")
            return;

        (transform.parent.GetComponent(typeof(FightManager)) as FightManager).OnTargetHit();
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
