using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraFollow : MonoBehaviour
{
    public GameObject avater1, avater2, avater3, avater4, avater5;

    public CinemachineFreeLook m_change;
    // Start is called before the first frame update
    void Start()
    {
        m_change = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (avater1.activeSelf)
        {
            m_change.Follow = avater1.transform;
            m_change.LookAt = avater1.transform.GetChild(9).gameObject.transform;
        }
        else if(avater2.activeSelf)
        {
            m_change.Follow = avater2.transform;
            m_change.LookAt = avater2.transform.GetChild(11).gameObject.transform;
        }

        else if (avater3.activeSelf)
        {
            m_change.Follow = avater3.transform;
            m_change.LookAt = avater3.transform.GetChild(10).gameObject.transform;
        }
        else if (avater4.activeSelf)
        {
            m_change.Follow = avater4.transform;
            m_change.LookAt = avater4.transform.GetChild(11).gameObject.transform;
        }
        else if (avater5.activeSelf)
        {
            m_change.Follow = avater5.transform;
            m_change.LookAt = avater5.transform.GetChild(16).gameObject.transform;
        }
        //else
        //{
        //    m_change.Follow = avater6.transform;
        //    m_change.LookAt = avater6.transform.GetChild(9).gameObject.transform;
        //}
    }
}
