﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading.Interface
{
    public interface IFileSpaceCounter : ISpaceCounter
    {
        Task<int> CountSpacesInFileAsync(string filePath);
        Task<int> CountSpacesInFilesAsync(IEnumerable<string> filePaths);
    }
}
