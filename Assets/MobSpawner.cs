using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyBeatSpawner : MonoBehaviour
{
    [Header("🎵 Musica")]
    public AudioSource musica;

    [Header("🕒 Beat settings")]
    public float beatDuration = 1.1f;          // Durata di un beat in secondi
    public float[] tempiSpawn;                 // Tempi in secondi in cui spawnare i nemici

   [Header("👾 Mostri")]
    public List<GameObject> Mostri;      // Tutti i prefab dei nemici nel progetto
   // public string tagNelNome = "Goblin";       // Filtra solo prefab con questo tag nel nome
  //  public Transform[] puntiSpawn;             // Punti della mappa dove possono apparire i nemici

private int index = 0;

    void Start()
    {
        Mostri = new List<GameObject>(Resources.LoadAll<GameObject>("Mostri/Lv1"));
        musica.Play();
        StartCoroutine(SpawnNemici());
    }

    IEnumerator SpawnNemici()
{
    while (index < tempiSpawn.Length)
    {
        float attesa = tempiSpawn[index] - musica.time;

        if (attesa > 0f)
            yield return new WaitForSeconds(attesa);

        Instantiate(Mostri[Random.Range(0, Mostri.Count)], transform.position, Quaternion.identity);
        index++;
    }
}


   // void SpawnMostroFiltrato()
   // {
   //     List<GameObject> filtrati = new List<GameObject>();

      //  foreach (GameObject mostro in Mostri)
       // {
     //       if (mostro.name.Contains(tagNelNome))
      //          filtrati.Add(mostro);
      //  }

    //    if (filtrati.Count == 0)
    //    {
           // Debug.LogWarning("Nessun prefab trovato con tag \"" + tagNelNome + "\" nel nome.");
    //        return;
    //    }

    //    int rndMostro = Random.Range(0, filtrati.Count);
      //  int rndPos = Random.Range(0, puntiSpawn.Length);

       // Instantiate(filtrati[rndMostro], Quaternion.identity);
    //}
}