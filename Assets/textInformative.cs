using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textInformative : MonoBehaviour {

    public GameObject texto;
    GameObject myLine = null;
    // Use this for initialization
    RectTransform rt;
    void Start () {
        GameObject.Instantiate(texto);
        texto.GetComponentInChildren<TextMesh>().color = Color.black;
        texto.SetActive(true);
        rt = (RectTransform)texto.transform;
        DrawLine(new Vector3(texto.transform.position.x, texto.transform.position.y - rt.rect.height/2, texto.transform.position.z), transform.position, texto.GetComponentInChildren<Image>().color);
    }
	
	// Update is called once per frame
	void Update () {
        if (myLine == null)
        {
            rt = (RectTransform)texto.transform;
            DrawLine(new Vector3(texto.transform.position.x, texto.transform.position.y - rt.rect.height / 2, texto.transform.position.z), transform.position, texto.GetComponentInChildren<Image>().color);
        }
           // DrawLine(texto.transform.position, transform.position, texto.GetComponentInChildren<Image>().color);//new Color(194 / 255.0f, 194 / 255.0f, 194 / 255.0f, 110 / 255.0f)
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.05f)
    {
        myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.01f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        //Destroy(myLine, duration);
    }

    public void createMessage(string text, Color color)
    {
        if (color == null)
        {
            color = Color.green;
        }
        if (text == null)
        {
            text = "";
        }

        GetComponent<TextMesh>().text = text;
        TextMesh utext = new TextMesh();
        utext.text = text;

        //newText.AddComponent<CanvasRenderer>();

        //Text newText = transform.gameObject.AddComponent<Text>();
        //newTextComp.text = text;
        //newTextComp.font = fontMessage;
        utext.color = color;
        //newTextComp.alignment = TextAnchor.MiddleCenter;
        utext.fontSize = 10;

        utext.transform.SetParent(transform);
       

    }

}
