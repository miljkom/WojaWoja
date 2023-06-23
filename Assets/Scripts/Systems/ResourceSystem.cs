using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : Singleton<ResourceSystem>
{
    // public List<ScriptableExampleHero> ExampleHeroes { get; private set; }
    // private Dictionary<ExampleHeroType, ScriptableExampleHero> _ExampleHeroesDict;

    protected override void Awake()
    {
        base.Awake();
        // AssembleResources();
    }
    
    public void Start()
    {
        
    }

    // private void AssembleResources()
    // {
    //     ExampleHeroes = Resources.LoadAll<ScriptableExampleHero>("ExampleHeroes").ToList();
    //     _ExampleHeroesDict = ExampleHeroes.ToDictionary(r => r.HeroType, r => r);
    // }

    // public ScriptableExampleHero GetExampleHero(ExampleHeroType t) => _ExampleHeroesDict[t];
    // public ScriptableExampleHero GetRandomHero() => ExampleHeroes[Random.Range(0, ExampleHeroes.Count)];
}   