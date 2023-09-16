using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Script ini dipasang di Joystick Back

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject ObjectYangDigerakkan;
    public GameObject ObjectYangDiputar;

    public Vector2 ArahGerak;

    public float offset = 2f;
    public float speedMax = 5f;
    public float Zaxis;

    private Image LingkaranBesar;
    private Image LingkaranKecil;


    // Start is called before the first frame update
    void Start()
    {
        LingkaranBesar = GetComponent<Image>();
        LingkaranKecil = transform.GetChild(0).GetComponent<Image>();
        ArahGerak = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        float BigCircleSizeX = LingkaranBesar.rectTransform.sizeDelta.x;
        float BigCircleSizeY = LingkaranBesar.rectTransform.sizeDelta.y;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle (LingkaranBesar.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= BigCircleSizeX;
            pos.y /= BigCircleSizeY;

            ArahGerak = new Vector2(pos.x, pos.y);
            ArahGerak = ArahGerak.magnitude > 1 ? ArahGerak.normalized : ArahGerak;

            LingkaranKecil.rectTransform.anchoredPosition = new Vector2(ArahGerak.x * (BigCircleSizeX / offset), ArahGerak.y * (BigCircleSizeY / offset));

            // Putaran Object
            //Zaxis = Mathf.Atan2(ArahGerak.x, ArahGerak.y) * Mathf.Rad2Deg;
            //ObjectYangDiputar.transform.eulerAngles = new Vector3(0, Zaxis, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ArahGerak = Vector2.zero;
        LingkaranKecil.rectTransform.anchoredPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectYangDigerakkan.transform.Translate(ArahGerak.x * speedMax * Time.deltaTime, 0, ArahGerak.y * speedMax* Time.deltaTime);
    }
}
