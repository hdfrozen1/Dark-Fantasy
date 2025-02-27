using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimpleSaveSystem : MonoBehaviour
{
    [SerializeField ] private InventorySO inventoryData;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            Save();
        }
    }
    private void Save(){
        EditorUtility.SetDirty(inventoryData);
        Debug.Log("Saving");
    }
}
