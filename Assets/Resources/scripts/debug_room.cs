using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug_room : MonoBehaviour
{
int itemNum;
int typeNum;
int crystelNum;
[SerializeField] private Transform itemSpawnPoint;
[SerializeField] private Transform blobSpawnPoint;
[SerializeField] private Transform crystelSpawnPoint;
[SerializeField] private Transform itemStorePoint;
[SerializeField] private Transform blobStorePoint;
[SerializeField] private Transform crystelStorePoint;

    // Start is called before the first frame update
    void Start()
    {
      itemNum = ItemDatabase.instance.items.Count;
      for(int i=0; i<itemNum; i++){
        GameObject item = ItemDatabase.instance.SpawnItem(i, itemSpawnPoint);
        item.GetComponent<Transform>().parent = itemStorePoint;
        itemSpawnPoint.position = new Vector2(itemSpawnPoint.position.x , itemSpawnPoint.position.y+2);
      }
      typeNum = type_database.instance.Elements.Count;
      for(int i=0; i<typeNum; i++){
        GameObject blob = enemy_database.instance.SpawnEnemy("blob", i, blobSpawnPoint);
        blob.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        blob.GetComponent<Transform>().parent = blobStorePoint;
        blobSpawnPoint.position = new Vector2(blobSpawnPoint.position.x , blobSpawnPoint.position.y+2);
      }
      for(int i=0; i<typeNum; i++){
        GameObject crystel = magic_controler.instance.SpawnCrystel(i, crystelSpawnPoint);
        crystel.GetComponent<Transform>().parent = crystelStorePoint;
        crystelSpawnPoint.position = new Vector2(crystelSpawnPoint.position.x , crystelSpawnPoint.position.y+2);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
