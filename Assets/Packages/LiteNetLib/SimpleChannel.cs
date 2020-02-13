namespace Packages.LiteNetLib
{
    internal sealed class SimpleChannel : BaseChannel
    {
        public SimpleChannel(NetPeer peer) : base(peer)
        {

        }

        public override void SendNextPackets()
        {
            lock (OutgoingQueue)
            {
                while (OutgoingQueue.Count > 0)
                {
                    NetPacket packet = OutgoingQueue.Dequeue();
                    Peer.SendUserData(packet);
                    Peer.NetManager.NetPacketPool.Recycle(packet);
                }
            }
        }

        public override bool ProcessPacket(NetPacket packet)
        {
            return false;
        }
    }
}
