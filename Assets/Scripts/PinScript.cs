using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Extension;

public class PinScript : MonoBehaviour
{
    public float pinFallThreshold = 0.02f;
    public float toppleLife = 1.5f;
    public int tries = 10;

    private Quaternion defaultRotation;
    private int currentTries;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Awake()
    {
        defaultRotation = transform.localRotation;
    }

    public void CheckTopple()
    {
        CancelToppleCheck();
        CheckRotation();
        InvokeRepeating("CheckRotation", 0f, 1f);
    }

    public void CancelToppleCheck()
    {
        currentTries = 0;
        CancelInvoke("CheckRotation");
        CancelInvoke("HidePin");
    }

    protected void CheckRotation()
    {
        currentTries++;
        if (!Mathf.Abs(Quaternion.Dot(defaultRotation, transform.localRotation)).ApproxEquals(1f, pinFallThreshold))
        {
            Invoke("HidePin", toppleLife);
        }
        else
        {
            if (currentTries > tries)
            {
                CancelToppleCheck();
            }
        }
    }

    protected void HidePin()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
   
}
