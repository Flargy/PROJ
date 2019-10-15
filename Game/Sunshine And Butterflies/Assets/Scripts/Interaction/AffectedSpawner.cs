using UnityEngine;

public class AffectedSpawner : AffectedObject
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Transform spawnLocation;
    
    private GameObject spawnObject;

    public override void ExecuteAction()
    {
        if(spawnObject == null)
        {
            spawnObject = (GameObject)Instantiate(spawnPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}
