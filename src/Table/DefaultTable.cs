using System;

namespace DefaultLibrary.Table;

/// <summary>
/// Abstract class for Entity objects
/// </summary>
public abstract class DefaultTable
{
    /// <summary>
    /// Id of the entity
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Created at
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Updated at, nullable
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

}