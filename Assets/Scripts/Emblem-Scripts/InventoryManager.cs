//using UnityEngine;
//using System.Collections.Generic;
//public class InventoryManager : MonoBehaviour
//{
//    public static InventoryManager Instance;
//    [SerializeField] private List<EmblemScriptableObject> allList;
//    [SerializeField] private Transform emblemGridParent;
//    [SerializeField] private GameObject slotUIPrefab;

//    private HashSet<EmblemScriptableObject> collected = new HashSet<EmblemScriptableObject>();

//    private void Awake()
//    {
//    if (Instance == null) Instance = this;
//        else Destroy(gameObject);

//    foreach (EmblemScriptableObject emblem in allList)
//        {
//        GameObject slotObject = Instantiate(slotUIPrefab, emblemGridParent);
//        SlotUI slot = slotObject.GetComponent<SlotUI>();
//            slot.Initialize(emblem, false);
//        }
//    }
//    public void CollectEmblem(EmblemScriptableObject emblem)
//    {
//        if (!collected.Contains(emblem))
//        {
//            collected.Add(emblem);
//            //UpdateSlotUI(emblem, true);
//        }
//    }
//}
