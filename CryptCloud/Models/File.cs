﻿using System;

namespace CryptCloud.Models;

public class File
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
}