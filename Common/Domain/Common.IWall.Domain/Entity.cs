using System.ComponentModel.DataAnnotations;

namespace Common.IWall.Domain;

public abstract class Entity<TKey> where TKey : struct
{
    [Key]
    public virtual TKey Id { get; set; }
}
