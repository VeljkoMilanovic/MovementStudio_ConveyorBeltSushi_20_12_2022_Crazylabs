using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bilboard : MonoBehaviour
{
    private int price;
    private float Timer = 0.0f;
    private TextMeshPro bilboardText;
    private SpriteRenderer bilboardIcon;

    // Start is called before the first frame update
    void Start()
    {
        bilboardText = gameObject.GetComponent<TextMeshPro>();
        bilboardIcon = GetComponentInChildren<SpriteRenderer>();

        bilboardText.text = price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 2.0f)
        {
            Destroy(gameObject);
        }
        gameObject.transform.position += Vector3.up * Time.deltaTime;
        Color tmp = bilboardIcon.color;
        tmp.a = (2.0f - Timer) / 2.0f;
        bilboardText.alpha = (2.0f - Timer) / 2.0f;
        bilboardIcon.color = tmp;
    }

    //orient towards camera
    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    public void setPrice(int x)
    {
        price = x;
    }
}
