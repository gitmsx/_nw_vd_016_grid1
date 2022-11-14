using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class scale001 : MonoBehaviour
{
    [Header("Sling Attributes")]
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve curveSling;
    [SerializeField][Range(-1, 1)] float Sling = -1.0f;
    [SerializeField][Range(-1, 1)] float SlingMin = -1.0f;
    [SerializeField][Range(-1, 1)] float SlingMax = 1.0f;

    Vector3 transformlocalScale;

    [Header("Other Attributes")]
    [ColorUsage(false, true)] public Color hdrColorWithoutAlpha = Color.white;

    // [NonSerialized] 
    //[HideInInspector]
    // [HideInInspector]


    [SerializeField] float timeSling = 7.0f;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 finishPosition;


    public Text Text1;
    public GameObject Text2;

    private Text Text12;


    [Header("elapsedTime Attributes")]

    private float elapsedTimeX;
    private float elapsedTimeY;
    private float elapsedTimeZ;

    // Start is called before the first frame update
    void Start()
    {


        Text2 = GameObject.Find("Text");
        //  Text2.transform.Translate(1,1,1);
        Text12 = Text2.GetComponent<Text>();
        Text12.text = "111111111";
    



    transformlocalScale = transform.localScale;
        Text12 = Text2.GetComponent<Text>();
        Text12.text = "111111111";

        Reset();
    }
    void Reset()
    {
        elapsedTimeX = 0;
        elapsedTimeY = 2;
        elapsedTimeZ = 3;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeX += Time.deltaTime;
        elapsedTimeY += Time.deltaTime;
        elapsedTimeZ += Time.deltaTime;
//        transform.position = Vector3.Lerp(startPosition, finishPosition, curve.Evaluate(elapsedTime1 / timeSling));


        float VolumeX = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeX / timeSling));
        float VolumeY = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeY / timeSling));
        float VolumeZ = Mathf.Lerp(SlingMin, SlingMax, curve.Evaluate(elapsedTimeZ / timeSling));
        
        Text12.text = "X " + Math.Round(elapsedTimeX, digits: 3).ToString() + "  Y " + Math.Round(VolumeY, digits: 3).ToString() + "  Z " + Math.Round(VolumeZ, digits: 3).ToString();

        transform.localScale = new Vector3(transformlocalScale.x + VolumeX, transformlocalScale.y + VolumeX, transformlocalScale.z + VolumeX);

    }
}
