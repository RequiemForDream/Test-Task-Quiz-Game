using Factories.Interfaces;
using UI.Configurations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories
{
    public class CanvasFactory : IFactory<Canvas>
    {
        private readonly CanvasConfiguration _canvasConfiguration;

        public CanvasFactory(CanvasConfiguration canvasConfiguration)
        {
            _canvasConfiguration = canvasConfiguration;
        }

        public Canvas Create()
        {
            var canvas = Object.Instantiate(_canvasConfiguration.Canvas);

            return canvas;
        }

        public void Reclaim(Object obj)
        {
            Object.Destroy(obj);
        }
    }
}
