﻿#nullable enable
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null!)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        private readonly Dictionary<string, object?> _Values = new();

        protected T? Get<T>([CallerMemberName] string PropertyName = null!) => 
            _Values.TryGetValue(PropertyName, out var value) ? (T?)value! : default;

        protected bool Set<T>(T value, [CallerMemberName] string PropertyName = null!)
        {
            if (_Values.TryGetValue(PropertyName, out var old_value) && Equals(old_value, value))
                return false;

            _Values[PropertyName] = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
