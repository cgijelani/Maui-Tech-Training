using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Services
{
    public class LocalStorageService
    {
        public LocalStorageService()
        {
                
        }

        public async Task<string> Get(string key)
        {
            return await SecureStorage.Default.GetAsync(key);
        }

        public async Task Save(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }
    }
}
