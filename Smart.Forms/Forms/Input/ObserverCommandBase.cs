﻿namespace Smart.Forms.Input
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;

    using System.Windows.Input;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObserveCommandBase<T> : ICommand
        where T : ObserveCommandBase<T>
    {
        private Dictionary<INotifyPropertyChanged, HashSet<string>> observeProperties;

        private HashSet<INotifyCollectionChanged> observeCollections;

        /// <summary>
        ///
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Ignore")]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        private void PrepareObserveProperties()
        {
            if (observeProperties == null)
            {
                observeProperties = new Dictionary<INotifyPropertyChanged, HashSet<string>>();
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void PrepareObserveCollections()
        {
            if (observeCollections == null)
            {
                observeCollections = new HashSet<INotifyCollectionChanged>();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public T Observe(INotifyPropertyChanged target, string propertyName)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PrepareObserveProperties();

            if (!observeProperties.TryGetValue(target, out var properties))
            {
                properties = new HashSet<string>();
                observeProperties[target] = properties;
                target.PropertyChanged += HandlePropertyChanged;
            }

            properties.Add(propertyName);

            return (T)this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public T Observe(INotifyCollectionChanged target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            PrepareObserveCollections();

            if (!observeCollections.Contains(target))
            {
                observeCollections.Add(target);
                target.CollectionChanged += HandleCollectionChanged;
            }

            return (T)this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public T RemoveObserver(INotifyPropertyChanged target, string propertyName)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (observeProperties != null)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public T RemoveObserver(INotifyPropertyChanged target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (observeProperties != null)
            {
                if (observeProperties.Remove(target))
                {
                    target.PropertyChanged -= HandlePropertyChanged;
                }
            }

            return (T)this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public T RemoveObserver(INotifyCollectionChanged target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (observeCollections != null)
            {
                if (observeCollections.Contains(target))
                {
                    target.CollectionChanged -= HandleCollectionChanged;
                    observeCollections.Remove(target);
                }
            }

            return (T)this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public T RemoveObserver()
        {
            if (observeProperties != null)
            {
                foreach (var target in observeProperties.Keys)
                {
                    target.PropertyChanged -= HandlePropertyChanged;
                }

                observeProperties.Clear();
            }

            if (observeCollections != null)
            {
                foreach (var target in observeCollections)
                {
                    target.CollectionChanged -= HandleCollectionChanged;
                }

                observeCollections.Clear();
            }

            return (T)this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var properties = observeProperties[(INotifyPropertyChanged)sender];
            if (properties.Contains(e.PropertyName))
            {
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCanExecuteChanged();
        }
    }
}
