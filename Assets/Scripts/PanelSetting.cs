using UnityEngine;
using UnityEngine.UI;

public class PanelSetting : MonoBehaviour
{
    public Image panelImage;

    private float minAlpha = 0f;
    private float maxAlpha = 0.15f;
    private float speed = 1f;

    private void Start()
    {
        if (panelImage == null)
            panelImage = GetComponent<Image>();
    }

    private void Update()
    {
        Color c = panelImage.color;

        float a = Mathf.PingPong(Time.time * speed, maxAlpha - minAlpha) + minAlpha;

        c.a = a;
        panelImage.color = c;
    }
}
