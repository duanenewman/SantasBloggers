﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableMvvm
{
    public static class IListExtensions
    {
        public static void UpdateItems<T1, T2>(this IList<T1> targetCollection, IList<T2> updateCollection,
            Func<T1, T2, bool> comparer, Func<T2, T1> mapper)
        {
            UpdateItems(targetCollection, updateCollection, comparer, mapper, null, (t) => true, t => false);
        }

        public static void UpdateItems<T1, T2>(this IList<T1> targetCollection, IList<T2> updateCollection,
            Func<T1, T2, bool> comparer, Func<T2, T1> mapper, Action<T1, T2> updater)
        {
            UpdateItems(targetCollection, updateCollection, comparer, mapper, updater, (t) => true, t => false);
        }

        public static void UpdateItems<T1, T2>(this IList<T1> targetCollection, IList<T2> updateCollection,
            Func<T1, T2, bool> comparer, Func<T2, T1> mapper, Action<T1, T2> updater, Func<T1, bool> targetFilter)
        {
            UpdateItems(targetCollection, updateCollection, comparer, mapper, updater, targetFilter, t => false);
        }

        public static void UpdateItems<T1, T2>(this IList<T1> targetCollection, IList<T2> updateCollection,
            Func<T1, T2, bool> comparer, Func<T2, T1> mapper, Action<T1, T2> updater, Func<T1, bool> targetFilter, Func<T1, bool> ignoreItem)
        {
            if (updateCollection == null) return;

            var itemsToRemove = new List<T1>();

            UpdateExistingItemsAndIdentifyRemovedItems(targetCollection, updateCollection, comparer, updater, itemsToRemove, targetFilter, ignoreItem);

            RemoveOldItemsFromTarget(targetCollection, itemsToRemove);

            AddNewItemsToTarget(targetCollection, updateCollection, comparer, mapper);
        }

        private static void UpdateExistingItemsAndIdentifyRemovedItems<T1, T2>(
            IList<T1> targetCollection,
            IList<T2> updateCollection,
            Func<T1, T2, bool> comparer,
            Action<T1, T2> updater,
            List<T1> itemsToRemove,
            Func<T1, bool> targetFilter,
            Func<T1, bool> ignoreItem)
        {
            foreach (var targetItem in targetCollection.Where(targetFilter).ToArray())
            {
                var updateItem = updateCollection.FirstOrDefault(u => comparer(targetItem, u));
                if (updateItem == null && !ignoreItem(targetItem))
                {
                    itemsToRemove.Add(targetItem);
                    continue;
                }
                updater?.Invoke(targetItem, updateItem);
            }
        }

        private static void RemoveOldItemsFromTarget<T1>(ICollection<T1> targetCollection, IEnumerable<T1> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                targetCollection.Remove(item);
            }
        }

        private static void AddNewItemsToTarget<T1, T2>(IList<T1> targetCollection, IList<T2> updateCollection, Func<T1, T2, bool> comparer,
            Func<T2, T1> mapper)
        {
            var itemsToAdd = updateCollection.Where(updateItem
                => !targetCollection.Any(existingITem => comparer(existingITem, updateItem))).ToList();

            foreach (var item in itemsToAdd)
            {
                targetCollection.Add(mapper(item));
            }
        }

    }

}
