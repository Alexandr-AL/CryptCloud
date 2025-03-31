using System;

namespace CryptCloud.Models;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
}