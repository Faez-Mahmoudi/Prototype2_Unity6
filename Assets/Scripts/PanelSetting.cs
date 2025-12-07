using UnityEngine;
using UnityEngine.UI;

public class PanelSetting : MonoBehaviour
{
    private Image panelImage;

    [SerializeField] private float minAlpha = 0f;
    [SerializeField] private float maxAlpha = 0.15f;
    [SerializeField] private float speed = 1f;

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
