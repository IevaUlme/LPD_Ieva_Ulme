using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFrontToBack : MonoBehaviour
{
    public Transform laserPos;
    private Vector3 startPos;
    private Vector3 endPos;

    [SerializeField] float distance;
    [SerializeField] float speed;

    private bool inRoutine = false;
    private float timePassed = 0;

    private void Start()
    {
        startPos = new Vector3(laserPos.position.x, laserPos.position.y, laserPos.position.z);
        endPos = new Vector3(laserPos.position.x, laserPos.position.y, laserPos.position.z - distance);
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        float t = Mathf.Clamp01(timePassed / speed);


        Vector3 newPosition = Vector3.Lerp(startPos, endPos, t);

        transform.position = newPosition;

        if (timePassed >= speed && !inRoutine)
        {
            StartCoroutine(DirectionChange());
        }
    }

    private IEnumerator DirectionChange()
    {
        inRoutine = true;
        yield return new WaitForSeconds(1.5f);
        
        startPos = endPos;
        distance *= -1;
        endPos = new Vector3(laserPos.position.x, laserPos.position.y, laserPos.position.z - distance);
        
        timePassed = 0;
        inRoutine = false;
    }
}
