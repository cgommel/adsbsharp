using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSBSharp
{
    public interface IFrameSink
    {

        void Start(string hostName, int port);
        void Stop();

        void FrameReady(byte[] frame, int actualLength);
    }
}
