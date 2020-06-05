// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Common.Adapters
{
    public class ItemAddedEventArgs
    {
        public ItemAddedEventArgs(object item)
        {
            Item = item;
        }

        public object Item { get; }
    }

    public class AddingItemEventArgs
    {
        public AddingItemEventArgs(object item)
        {
            Item = item;
        }

        public object Item { get; }

        public bool Cancel { get; set; }
    }

    public delegate void AddingItemEventHandler(object sender, AddingItemEventArgs e);

    public delegate void ItemAddedEventHandler(object sender, ItemAddedEventArgs e);

    public class CollectionAdapterWithAddNotifications<T> : ICollection<T>
    {
        protected readonly ICollection<T> Source;

        public CollectionAdapterWithAddNotifications(ICollection<T> source)
            : this(source, null) { }

        public CollectionAdapterWithAddNotifications(ICollection<T> source, ItemAddedEventHandler addedEventHandler)
            : this(source, addedEventHandler, null) { }

        public CollectionAdapterWithAddNotifications(
            ICollection<T> source,
            ItemAddedEventHandler addedEventHandler,
            AddingItemEventHandler addingEventHandler)
        {
            Source = source;

            if (addingEventHandler != null)
            {
                AddingItem += addingEventHandler;

                // Fire events for existing source items, removing them as necessary
                source
                   .Where(x => !ShouldIncludeItem(x))
                   .ToList()
                   .ForEach(x => source.Remove(x));
            }

            if (addedEventHandler != null)
            {
                ItemAdded += addedEventHandler;

                // Fire events for existing source items
                foreach (var item in source)
                {
                    OnItemAdded(item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (!ShouldIncludeItem(item))
            {
                return;
            }

            Source.Add(item);

            OnItemAdded(item);
        }

        public void Clear()
        {
            Source.Clear();
        }

        public bool Contains(T item)
        {
            return Source.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in Source)
            {
                array[arrayIndex++] = item;
            }
        }

        public virtual bool Remove(T item)
        {
            return Source.Remove(item);
        }

        public int Count => Source.Count;

        public bool IsReadOnly => Source.IsReadOnly;

        public event ItemAddedEventHandler ItemAdded;

        private void OnItemAdded(T item)
        {
            if (ItemAdded != null)
            {
                var args = new ItemAddedEventArgs(item);
                ItemAdded(this, args);
            }
        }

        public event AddingItemEventHandler AddingItem;

        private void OnAddingItem(T item, out bool cancel)
        {
            if (AddingItem != null)
            {
                var args = new AddingItemEventArgs(item);
                AddingItem(this, args);
                cancel = args.Cancel;
            }
            else
            {
                cancel = false;
            }
        }

        private bool ShouldIncludeItem(T item)
        {
            bool cancel;

            OnAddingItem(item, out cancel);

            return !cancel;
        }
    }

    public class
        CovariantCollectionAdapterWithAddNotifications<TBase, TDerived>
        : CovariantCollectionAdapter<TBase, TDerived> //, INotifyCollectionChanged    //public class ObservableCovariantIListAdapter<TBase, TDerived> : CovariantIListAdapter<TBase, TDerived>, INotifyCollectionChanged
        where TDerived : TBase
    {
        public CovariantCollectionAdapterWithAddNotifications(ICollection<TDerived> source)
            : this(source, null) { }

        public CovariantCollectionAdapterWithAddNotifications(ICollection<TDerived> source, ItemAddedEventHandler addedEventHandler)
            : this(source, addedEventHandler, null) { }

        public CovariantCollectionAdapterWithAddNotifications(
            ICollection<TDerived> source,
            ItemAddedEventHandler addedEventHandler,
            AddingItemEventHandler addingEventHandler)
            : base(source)
        {
            if (addingEventHandler != null)
            {
                AddingItem += addingEventHandler;

                // Fire events for existing source items, removing them as necessary
                source
                   .Where(x => !ShouldIncludeItem(x))
                   .ToList()
                   .ForEach(x => source.Remove(x));
            }

            if (addedEventHandler != null)
            {
                ItemAdded += addedEventHandler;

                // Fire events for existing source items
                foreach (var item in source)
                {
                    OnItemAdded(item);
                }
            }
        }

        public override void Add(TBase item)
        {
            if (!ShouldIncludeItem(item))
            {
                return;
            }

            base.Add(item);

            OnItemAdded(item);
        }

        public event ItemAddedEventHandler ItemAdded;

        private void OnItemAdded(TBase item)
        {
            if (ItemAdded != null)
            {
                var args = new ItemAddedEventArgs(item);
                ItemAdded(this, args);
            }
        }

        public event AddingItemEventHandler AddingItem;

        private void OnAddingItem(TBase item, out bool cancel)
        {
            if (AddingItem != null)
            {
                var args = new AddingItemEventArgs(item);
                AddingItem(this, args);
                cancel = args.Cancel;
            }
            else
            {
                cancel = false;
            }
        }

        private bool ShouldIncludeItem(TBase item)
        {
            bool cancel;

            OnAddingItem(item, out cancel);

            return !cancel;
        }
    }

    public class CovariantCollectionAdapter<TBase, TDerived> : ICollection<TBase>
        where TDerived : TBase
    {
        protected readonly ICollection<TDerived> Source;

        public CovariantCollectionAdapter(ICollection<TDerived> source)
        {
            Source = source;
        }

        public IEnumerator<TBase> GetEnumerator()
        {
            foreach (var item in Source)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(TBase item)
        {
            Source.Add((TDerived) item);
        }

        public virtual void Clear()
        {
            Source.Clear();
        }

        public bool Contains(TBase item)
        {
            return Source.Contains((TDerived) item);
        }

        public void CopyTo(TBase[] array, int arrayIndex)
        {
            foreach (var item in Source)
            {
                array[arrayIndex++] = item;
            }
        }

        public virtual bool Remove(TBase item)
        {
            int initialCount = Source.Count;
            Source.Remove((TDerived) item);
            return initialCount > Source.Count;
        }

        public int Count => Source.Count;

        public bool IsReadOnly => Source.IsReadOnly;
    }

    public class ContravariantCollectionAdapter<TBase, TDerived> : ICollection<TDerived>
        where TDerived : TBase
    {
        protected readonly ICollection<TBase> Source;

        public ContravariantCollectionAdapter(ICollection<TBase> source)
        {
            Source = source;
        }

        public IEnumerator<TDerived> GetEnumerator()
        {
            foreach (var item in Source)
            {
                yield return (TDerived) item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(TDerived item)
        {
            Source.Add(item);
        }

        public virtual void Clear()
        {
            Source.Clear();
        }

        public bool Contains(TDerived item)
        {
            return Source.Contains(item);
        }

        public void CopyTo(TDerived[] array, int arrayIndex)
        {
            foreach (var item in Source)
            {
                array[arrayIndex++] = (TDerived) item;
            }
        }

        public virtual bool Remove(TDerived item)
        {
            int initialCount = Source.Count;
            Source.Remove(item);
            return initialCount > Source.Count;
        }

        public int Count => Source.Count;

        public bool IsReadOnly => Source.IsReadOnly;
    }
}
