using UnityEngine;

public class AffectedSpawner : AffectedObject
{
    [SerializeField] private GameObject spawnPrefab = null;
    [SerializeField] private Transform spawnLocation = null;
    
    private GameObject spawnObject;

    public override void ExecuteAction()
    {
        if(spawnObject == null)
        {
            spawnObject = (GameObject)Instantiate(spawnPrefab, spawnLocation.position, spawnLocation.rotation * Quaternion.Euler(0, 90, 0));
            spawnObject.GetComponent<Rigidbody>().velocity = spawnLocation.forward * 2;
        }
    }
}
