using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading.Interface
{
    public interface IFolderSpaceCounter : ISpaceCounter
    {
        Task<int> CountSpacesInFolderAsync(string folderPath);
    }
}
