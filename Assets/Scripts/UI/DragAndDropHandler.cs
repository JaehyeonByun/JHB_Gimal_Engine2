using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragAndDropHandler : MonoBehaviour
{
    [SerializeField] private UIItemSlot cursorSlot = null;      //SerializeField일 경우 갚을 안주면 경고창 뜸!
    private ItemSlot cursorItemSlot;

    [SerializeField] private GraphicRaycaster m_Raycaster = null;
    private PointerEventData m_PointerEventData;
    [SerializeField] private EventSystem m_EventSystem = null;

    World world;

    private void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();

        cursorItemSlot = new ItemSlot(cursorSlot);
    }

    private void Update()
    {
        if(!world.inUI)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (CheckForSlot() != null)
                Debug.Log("Item Slot Clicked");
        }


    }

    private UIItemSlot CheckForSlot()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag == "UIItemSlot")
                return result.gameObject.GetComponent<UIItemSlot>();


        }
        return null;
    }
}
