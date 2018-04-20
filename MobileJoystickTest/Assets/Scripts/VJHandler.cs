using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VJHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickContainer;
    private Image joystick;
    public float angle;
    public Vector3 InputDirection;

    void Start()
    {

        joystickContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickContainer.rectTransform,ped.position,ped.pressEventCamera,out position);


        // FIXAR SÅ ATT MAN KAN STYRA HASTIGHETEN
        position.x = (position.x / joystickContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / joystickContainer.rectTransform.sizeDelta.y);

        float x = (joystickContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (joystickContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (joystickContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (joystickContainer.rectTransform.sizeDelta.y) / 3);

    }

    public void OnPointerDown(PointerEventData ped)
    {

        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        
    }
}