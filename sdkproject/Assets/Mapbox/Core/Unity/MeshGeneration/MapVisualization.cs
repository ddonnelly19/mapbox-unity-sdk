namespace Mapbox.Unity.MeshGeneration
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Mapbox.Unity.MeshGeneration.Data;
    using Mapbox.Unity.MeshGeneration.Factories;
    using Mapbox.Platform;

    [CreateAssetMenu(menuName = "Mapbox/MapVisualization")]
    public class MapVisualization : ScriptableObject
    {
        [SerializeField]
        [Type(typeof(Factory))]
        public FactoryList Factories;

        /// <summary>
        /// Initializes the factories by passing the file source down, which's necessary for data (web/file) calls
        /// </summary>
        /// <param name="fs"></param>
        public void Initialize(IFileSource fs)
        {
            foreach (Factory fac in Factories.List.Where(x => x != null))
            {
                fac.Initialize(fs);
            }
        }

        /// <summary>
        /// Registers requested tiles to the factories
        /// </summary>
        /// <param name="tile"></param>
        public void ShowTile(UnityTile tile)
        {
            foreach (var fac in Factories.List.Where(x => x != null))
            {
                fac.Register(tile);
            }
        }
    }

    [System.Serializable]
    public class FactoryList
    {
        public List<Factory> List;

        public FactoryList()
        {

        }
    }
}
