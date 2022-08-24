using System;
using System.Linq;
using System.Net;

using SOE.Interfaces;

namespace SOE.Core
{
    public class SOEClient
    {
        // Components
        public SOEServer Server;
        public SOEConnectionManager Manager;
        public SOEDataChannel DataChannel;
        public IPEndPoint Client;

        // Session properties
        private bool SessionStarted;
        private uint SessionID;
        private uint CRCLength;
        private uint BufferSize;
        private uint CRCSeed;
        private bool Encryptable;
        private bool Compressable;

        // Server properties
        private int ClientID = -1;
        private int LastInteraction;
        private bool Encrypted;

        public SOEClient(SOEConnectionManager manager, IPEndPoint client)
        {
            // Manager and server
            Server = manager.Server;
            Manager = manager;
            Client = client;
            DataChannel = new SOEDataChannel(this);
            
            // Session
            SessionStarted = false;
            Encryptable = false;
            Compressable = true;

            Encrypted = false;

            // This client is new
            Interact();
        }

        public int GetClientID()
        {
            return ClientID;
        }

        public void SetClientID(int clientId)
        {
            // New client ID
            ClientID = clientId;

            // This client is still alive
            Interact();
        }

        public IPAddress GetClientAddress()
        {
            return Client.Address;
        }

        public void StartSession(uint crcLength, uint sessionId, uint udpBufferSize)
        {
            // Generate a CRC Seed for this session
            // CRCSeed = (uint)(new Random().Next(int.MaxValue));
            CRCSeed = 1884358976;

            // Session variables
            CRCLength = crcLength;
            SessionID = sessionId;
            BufferSize = udpBufferSize;
            SessionStarted = true;

            // By default, all sessions start compressable..
            Compressable = true;

            // By default, all sessions start un-encryptable..
            Encryptable = false;
            Encrypted = false;
        }

        public bool HasSession()
        {
            return SessionStarted;
        }

        public uint GetCRCLength()
        {
            return CRCLength;
        }

        public uint GetSessionID()
        {
            return SessionID;
        }

        public uint GetBufferSize()
        {
            return BufferSize;
        }

        public uint GetCRCSeed()
        {
            return CRCSeed;
        }

        public bool IsEncrypted()
        {
            return Encrypted;
        }

        public void SetEncryptable(bool encryptable)
        {
            Encryptable = encryptable;
        }

        public void ToggleEncryption()
        {
            if (Encryptable)
            {
                Encrypted = !Encrypted;
            }
        }

        public bool IsCompressable()
        {
            return Compressable;
        }

        public void SetCompressable(bool compressable)
        {
            Compressable = compressable;
        }

        public byte[] Encrypt(byte[] data)
        {
            return Server.Protocol.Encrypt(this, data);
        }

        public byte[] Compress(byte[] data)
        {
            return Server.Protocol.Compress(data);
        }

        public byte[] GetAppendedCRC32(byte[] packet)
        {
            // Used to store the bytes we get
            byte[] finalCRCBytes = new byte[CRCLength];

            // Get the CRC
            uint crc = GetCRC32Checksum(packet);

            // Get the bytes for the CRC, and append the neccasary ones.
            int place = 0;
            byte[] crcBytes = BitConverter.GetBytes(crc).Reverse().ToArray();
            for (int i = 4 - (int)CRCLength; i < crcBytes.Length; i++)
            {
                finalCRCBytes[place] = crcBytes[i];
                place++;
            }
            
            // Return the bytes we need to
            return finalCRCBytes;
        }

        public uint GetCRC32Checksum(byte[] packet)
        {
            // Use the Protocol object to calculate the CRC
            return Server.Protocol.GetCRC32Checksum(CRCSeed, packet);
        }

        public void Disconnect(ushort reason, bool client = false)
        {
            // Dead client or intentional disconnect...
            Manager.DisconnectClient(this, reason, client);
        }

        public void SendPacket(SOEPacket packet)
        {
            // Send the packet
            Server.SendPacket(this, packet);

            // This client is still alive
            Interact();
        }

        public void SendMessage(SOEMessage message)
        {
            // Send the message through the data channel
            DataChannel.Send(message);

            // This client is still alive
            Interact();
        }

        public void ReceiveMessage(byte[] rawMessage)
        {
            // We've received a message! Tell the server!
            Server.ReceiveMessage(this, rawMessage);

            // This client is still alive
            Interact();
        }

        public int GetLastInteraction()
        {
            // Return the last time we were interacted with..
            return LastInteraction;
        }

        public ushort GetNextSequenceNumber()
        {
            // This is kinda dangerous as it assumes that the message is going to be sent.
            return DataChannel.GetNextSequenceNumber();
        }

        private void Interact()
        {
            // Set our last interaction so we don't get destroyed
            LastInteraction = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
