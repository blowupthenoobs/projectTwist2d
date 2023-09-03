using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControler : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;

    public GameObject Sniper;
    public Transform ScopePoint;
    public bool Scoping;
    public float scopeSmooth;

    private void FixedUpdate()
    {
        if(!Scoping)
        {
            if(transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
        else
        {
            Vector3 targetPos = new Vector3(ScopePoint.position.x, ScopePoint.position.y, transform.position.z);
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }

        if(MoonTimer.Instance.isday)
            Scoping=false;
        if(Sniper.activeInHierarchy)
            Scoping=false;
        
    }




}
