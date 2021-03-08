
using UnityEngine;
using UnityEngine.EventSystems;

public class FlyingBirdLogoController : MonoBehaviour,  IPointerClickHandler
{

    public GameObject mainMenu;
    public GameObject instructionPage;


    public void OnPointerClick(PointerEventData eventData)
        {
             mainMenu.SetActive(false);
             instructionPage.SetActive(true);
        }


}
