using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Online.Manager
{
    public class Response: MonoBehaviour
    {
        [SerializeField] private ConnectionProvider _provider;
        public async Task GetResponse()
        {
            var stream = _provider.Server.GetStream();
            var bytesToRead = new byte[_provider.Server.ReceiveBufferSize];
            var response = await stream.ReadAsync(bytesToRead, 0, bytesToRead.Length);
            Debug.Log(response);
        }
    }
}
