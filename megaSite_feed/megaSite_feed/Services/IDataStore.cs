using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace megaSite_feed.Services
{
    public interface IDataStore
    {
        string GetArchiveData(string DataName);
    }
}
