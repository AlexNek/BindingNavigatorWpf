using System;

namespace BindingNavigator
{
    /// <summary>
    /// Interface IDataChanger
    /// Must implement add, delete and save operation for data context
    /// </summary>
    public interface IDataChanger
    {
        /// <summary>
        /// Adds the new item to the display collection
        /// Return item is not used in library now
        /// </summary>
        /// <returns>new created item or null</returns>
        object AddNew();

        /// <summary>
        /// Deletes the item from specified view position.
        /// </summary>
        /// <param name="viewPosition">The view position.</param>
        void Delete(int viewPosition);

        /// <summary>
        /// Saves changed view data.
        /// As we use immediate storing after changing it is planned for special use cases only
        /// </summary>
        void Save();
    }
}