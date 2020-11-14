using System;

namespace QuadraticEquationSolver.Infrastructure
{
    /// <summary>Зависимость от</summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class DependencyOnAttribute : Attribute
    {
        /// <summary>Имя свойства, от которого зависит текущее свойство</summary>
        public string Name { get; set; }

        public DependencyOnAttribute() { }

        public DependencyOnAttribute(string Name) => this.Name = Name;
    }
}
