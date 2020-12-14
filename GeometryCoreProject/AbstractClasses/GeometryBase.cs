using System;
using System.Drawing;

namespace GeometryCoreProject.AbstractClasses
{
    public abstract class GeometryBase : Object, IGeometryBase
    {
        public Guid UUID { get; private set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        protected internal GeometryBase()
        {
            this.UUID = Guid.NewGuid();
        }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}
