using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using Unity.VectorGraphics;
using UnityEngine.UI;
using TMPro;


public class ColorControl : MonoBehaviour
{
    private Image img;
    private SVGImage svgimg;
    private TMP_Text tmp;
    
    public ProjectColors projectsColor;
    void Start()
    {
        //Debug.Log($"chosen color on {gameObject.name} is {projectsColor}");
        if (GetComponent<Image>() != null)
        {
            //Debug.Log("found component Image on " + gameObject.name);
            img = GetComponent<Image>();
            ChangeImgColor();
        } else if (GetComponent<SVGImage>() != null)
        {
            //Debug.Log("found component SVGImage on " + gameObject.name);
            svgimg = GetComponent<SVGImage>();
            ChangeSvgColor();
        } else if (GetComponent<TMP_Text>() != null)
        {
            //Debug.Log("found component TMP_Text on " + gameObject.name);
            tmp = GetComponent<TMP_Text>();
            ChangeTextColor();
        }
        else
        {
            Debug.LogWarning("Couldn't find any graphic component on this object");
        }
    }

    public void ChangeTextColor()
    {
        tmp.color = ColorManager.Instance.MyColorsList[(int)projectsColor];
    }

    public void ChangeSvgColor()
    {
        svgimg.color = ColorManager.Instance.MyColorsList[(int)projectsColor];
    }

    public void ChangeImgColor()
    {
        img.color = ColorManager.Instance.MyColorsList[(int)projectsColor];
    }
    
}
