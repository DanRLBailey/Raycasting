using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    //Public
    public float dist;
    public Vector3 rotation;
    public float duration;
    public GameObject child;
    public float lineRendererWidth;
    public Material lineRendererMaterial;
    public int noOfLineRenderers;
    public Color lineRendererColour;

    //Private
    List<GameObject> childList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < noOfLineRenderers; i++)
        {
            GameObject temp = Instantiate(child);
            temp.AddComponent<LineRenderer>();
            temp.transform.parent = transform;
            temp.GetComponent<LineRenderer>().useWorldSpace = true;
            temp.GetComponent<LineRenderer>().startWidth = lineRendererWidth;
            temp.GetComponent<LineRenderer>().endWidth = lineRendererWidth;
            temp.GetComponent<LineRenderer>().startColor = Color.white;
            temp.GetComponent<LineRenderer>().endColor = Color.white;

            temp.GetComponent<LineRenderer>().material = lineRendererMaterial;

            Color col = lineRendererColour;

            float number = noOfLineRenderers;

            float alpha = 1 - (i / number);

            col.a = alpha;

            temp.GetComponent<LineRenderer>().material.SetColor("_Color", col);

            childList.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawCast();
    }

    void DrawCast()
    {
        RaycastHit hit;

        childList[0].GetComponent<LineRenderer>().SetPosition(0, transform.position);

        for (int i = childList.Count; i > 0 ; i--)
        {
            if (i < childList.Count)
            {
                childList[i].GetComponent<LineRenderer>().SetPosition(0, transform.position);

                if (i > 0)
                    childList[i].GetComponent<LineRenderer>().SetPosition(1, childList[i - 1].GetComponent<LineRenderer>().GetPosition(1));
            }
        }

        //ineRenderer.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            //Debug.Log("Hit!");

            childList[0].GetComponent<LineRenderer>().SetPosition(1, hit.point);
        }
        else
        {
            childList[0].GetComponent<LineRenderer>().SetPosition(1, transform.transform.forward * 100);
        }

        transform.Rotate(rotation);
    }
}
