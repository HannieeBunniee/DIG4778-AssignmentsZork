using Newtonsoft.Json.Bson;
using System;

namespace Zork
{
    public interface IInputService
    {
        event EventHandler<string> InputReceived;

    }
}
