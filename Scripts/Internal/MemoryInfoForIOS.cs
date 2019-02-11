#if UNITY_IOS
using System;
using System.Runtime.InteropServices;

namespace MemoryInfo.Internal
{
    public sealed class MemoryInfoForIOS : IPlatform
    {
        [DllImport("__Internal")]
        private static extern uint _GetUsedMemorySize();

        [DllImport("__Internal")]
        private static extern uint _GetFreeMemorySize();

        [DllImport("__Internal")]
        private static extern uint _GetTotalMemorySize();

        void IDisposable.Dispose()
        {
            
        }

        MemoryInfo IPlatform.GetMemoryInfo()
        {;
            return new MemoryInfo() {
                UsedSize = (int)(_GetUsedMemorySize() / 1024),
                TotalSize = (int)(_GetTotalMemorySize() / 1024),
            };
        }
    }
}
#endif
