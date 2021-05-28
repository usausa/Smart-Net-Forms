namespace Smart.Forms.Input
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class ObserveCommandBase<T>
        where T : ObserveCommandBase<T>
    {
        private HashSet<INotifyPropertyChanged>? observeObjects;

        private Dictionary<INotifyPropertyChanged, HashSet<string>>? observeProperties;

        private HashSet<INotifyCollectionChanged>? observeCollections;

        public event EventHandler? CanExecuteChanged;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Ignore.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private void HandleAllPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaiseCanExecuteChanged();
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var properties = observeProperties![(INotifyPropertyChanged)sender];
            if (properties.Contains(e.PropertyName))
            {
                RaiseCanExecuteChanged();
            }
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCanExecuteChanged();
        }

        public T Observe(INotifyPropertyChanged target)
        {
            observeObjects ??= new HashSet<INotifyPropertyChanged>();
            if (!observeObjects.Contains(target))
            {
                observeObjects.Add(target);
                target.PropertyChanged += HandleAllPropertyChanged;
            }

            return (T)this;
        }

        public T Observe(INotifyPropertyChanged target, string propertyName)
        {
            observeProperties ??= new Dictionary<INotifyPropertyChanged, HashSet<string>>();
            if (!observeProperties.TryGetValue(target, out var properties))
            {
                properties = new HashSet<string>();
                observeProperties[target] = properties;
                target.PropertyChanged += HandlePropertyChanged;
            }

            properties.Add(propertyName);

            return (T)this;
        }

        public T ObserveCollection(INotifyCollectionChanged target)
        {
            observeCollections ??= new HashSet<INotifyCollectionChanged>();
            if (!observeCollections.Contains(target))
            {
                observeCollections.Add(target);
                target.CollectionChanged += HandleCollectionChanged;
            }

            return (T)this;
        }

        public T RemoveObserver(INotifyPropertyChanged target)
        {
            if (observeObjects is not null)
            {
                if (observeObjects.Remove(target))
                {
                    target.PropertyChanged -= HandleAllPropertyChanged;
                }
            }

            return (T)this;
        }

        public T RemoveObserver(INotifyPropertyChanged target, string propertyName)
        {
            if (observeProperties is not null)
            {
                if (observeProperties.TryGetValue(target, out var properties))
                {
                    properties.Remove(propertyName);

                    if (properties.Count == 0)
                    {
                        observeProperties.Remove(target);
                        target.PropertyChanged -= HandlePropertyChanged;
                    }
                }
            }

            return (T)this;
        }

        public T RemoveCollectionObserver(INotifyCollectionChanged target)
        {
            if (observeCollections is not null)
            {
                if (observeCollections.Remove(target))
                {
                    target.CollectionChanged -= HandleCollectionChanged;
                }
            }

            return (T)this;
        }

        public T RemoveObservers()
        {
            if (observeObjects is not null)
            {
                foreach (var target in observeObjects)
                {
                    target.PropertyChanged -= HandleAllPropertyChanged;
                }

                observeObjects.Clear();
            }

            if (observeProperties is not null)
            {
                foreach (var target in observeProperties.Keys)
                {
                    target.PropertyChanged -= HandlePropertyChanged;
                }

                observeProperties.Clear();
            }

            if (observeCollections is not null)
            {
                foreach (var target in observeCollections)
                {
                    target.CollectionChanged -= HandleCollectionChanged;
                }

                observeCollections.Clear();
            }

            return (T)this;
        }
    }
}
