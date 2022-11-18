using OpenIRacingTools.Sdk.Native.Enums;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace OpenIRacingTools.Sdk.Native
{

    public enum TelemCommandModeTypes { Stop = 0, Start, Restart };

    public class Defines
    {
        public const uint DesiredAccess = 2031619;
        public const string DataValidEventName = "Local\\IRSDKDataValidEvent";
        public const string MemMapFileName = "Local\\IRSDKMemMapFileName";
        public const string BroadcastMessageName = "IRSDK_BROADCASTMSG";
        public const string PadCarNumName = "IRSDK_PADCARNUM";
        public const int MaxString = 32;
        public const int MaxDesc = 64;
        public const int MaxVars = 4096;
        public const int MaxBufs = 4;
        public const int StatusConnected = 1;
        public const int SessionStringLength = 0x20000; // 128k
    }

    public class iRacingSDK
    {
        private Encoding encoding;

        //VarHeader offsets
        public const int VarOffsetOffset = 4;
        public const int VarCountOffset = 8;
        public const int VarNameOffset = 16;
        public const int VarDescOffset = 48;
        public const int VarUnitOffset = 112;
        public int VarHeaderSize = 144;

        private MemoryMappedFile iRacingFile;
        private MemoryMappedViewAccessor FileMapView;

        public iRacingSDK()
        {
            // Register CP1252 encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            encoding = Encoding.GetEncoding(1252);
        }

        public CiRSDKHeader Header { get; private set; }

        public bool IsInitialized { get; private set; }

        public Dictionary<string, CVarHeader> VarHeaders { get; } = new Dictionary<string, CVarHeader>();

        public bool Startup()
        {
            if (IsInitialized)
            {
                return true;
            }

            try
            {
#pragma warning disable CA1416 // Validate platform compatibility
                iRacingFile = MemoryMappedFile.OpenExisting(Defines.MemMapFileName);
#pragma warning restore CA1416 // Validate platform compatibility
                FileMapView = iRacingFile.CreateViewAccessor();

                VarHeaderSize = Marshal.SizeOf(typeof(VarHeader));

                var hEvent = OpenEvent(Defines.DesiredAccess, false, Defines.DataValidEventName);
                var are = new AutoResetEvent(false)
                {
                    Handle = hEvent
                };

                var wh = new WaitHandle[1];
                wh[0] = are;

                WaitHandle.WaitAny(wh);

                Header = new CiRSDKHeader(FileMapView);
                GetVarHeaders();

                IsInitialized = true;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void GetVarHeaders()
        {
            VarHeaders.Clear();
            for (int i = 0; i < Header.VarCount; i++)
            {
                int type = FileMapView.ReadInt32(Header.VarHeaderOffset + i * VarHeaderSize);
                int offset = FileMapView.ReadInt32(Header.VarHeaderOffset + i * VarHeaderSize + VarOffsetOffset);
                int count = FileMapView.ReadInt32(Header.VarHeaderOffset + i * VarHeaderSize + VarCountOffset);
                byte[] name = new byte[Defines.MaxString];
                byte[] desc = new byte[Defines.MaxDesc];
                byte[] unit = new byte[Defines.MaxString];
                FileMapView.ReadArray(Header.VarHeaderOffset + i * VarHeaderSize + VarNameOffset, name, 0, Defines.MaxString);
                FileMapView.ReadArray(Header.VarHeaderOffset + i * VarHeaderSize + VarDescOffset, desc, 0, Defines.MaxDesc);
                FileMapView.ReadArray(Header.VarHeaderOffset + i * VarHeaderSize + VarUnitOffset, unit, 0, Defines.MaxString);
                string nameStr = encoding.GetString(name).TrimEnd(new char[] { '\0' });
                string descStr = encoding.GetString(desc).TrimEnd(new char[] { '\0' });
                string unitStr = encoding.GetString(unit).TrimEnd(new char[] { '\0' });
                VarHeaders[nameStr] = new CVarHeader(type, offset, count, nameStr, descStr, unitStr);
            }
        }

        public object GetData(string name)
        {
            if (IsInitialized && Header != null)
            {
                if (VarHeaders.ContainsKey(name))
                {
                    int varOffset = VarHeaders[name].Offset;
                    int count = VarHeaders[name].Count;
                    if (VarHeaders[name].Type == CVarHeader.VarType.irChar)
                    {
                        byte[] data = new byte[count];
                        FileMapView.ReadArray(Header.Buffer + varOffset, data, 0, count);
                        return encoding.GetString(data).TrimEnd(new char[] { '\0' });
                    }
                    else if (VarHeaders[name].Type == CVarHeader.VarType.irBool)
                    {
                        if (count > 1)
                        {
                            bool[] data = new bool[count];
                            FileMapView.ReadArray(Header.Buffer + varOffset, data, 0, count);
                            return data;
                        }
                        else
                        {
                            return FileMapView.ReadBoolean(Header.Buffer + varOffset);
                        }
                    }
                    else if (VarHeaders[name].Type == CVarHeader.VarType.irInt || VarHeaders[name].Type == CVarHeader.VarType.irBitField)
                    {
                        if (count > 1)
                        {
                            int[] data = new int[count];
                            FileMapView.ReadArray(Header.Buffer + varOffset, data, 0, count);
                            return data;
                        }
                        else
                        {
                            return FileMapView.ReadInt32(Header.Buffer + varOffset);
                        }
                    }
                    else if (VarHeaders[name].Type == CVarHeader.VarType.irFloat)
                    {
                        if (count > 1)
                        {
                            float[] data = new float[count];
                            FileMapView.ReadArray(Header.Buffer + varOffset, data, 0, count);
                            return data;
                        }
                        else
                        {
                            return FileMapView.ReadSingle(Header.Buffer + varOffset);
                        }
                    }
                    else if (VarHeaders[name].Type == CVarHeader.VarType.irDouble)
                    {
                        if (count > 1)
                        {
                            double[] data = new double[count];
                            FileMapView.ReadArray(Header.Buffer + varOffset, data, 0, count);
                            return data;
                        }
                        else
                        {
                            return FileMapView.ReadDouble(Header.Buffer + varOffset);
                        }
                    }
                }
            }
            return null;
        }

        public string GetSessionInfo()
        {
            if (IsInitialized && Header != null)
            {
                byte[] data = new byte[Header.SessionInfoLength];
                FileMapView.ReadArray(Header.SessionInfoOffset, data, 0, Header.SessionInfoLength);
                return encoding.GetString(data).TrimEnd(new char[] { '\0' });
            }
            return null;
        }

        public bool IsConnected()
        {
            if (IsInitialized && Header != null)
            {
                return (Header.Status & 1) > 0;
            }
            return false;
        }

        public void Shutdown()
        {
            IsInitialized = false;
            Header = null;
        }

        IntPtr GetBroadcastMessageID()
        {
            return RegisterWindowMessage(Defines.BroadcastMessageName);
        }

        public int BroadcastMessage(BroadcastMessageType msg, int var1, int var2, int var3)
        {
            return BroadcastMessage(msg, var1, MakeLong((short)var2, (short)var3));
        }

        public int BroadcastMessage(BroadcastMessageType msg, int var1, int var2)
        {
            IntPtr msgId = GetBroadcastMessageID();
            IntPtr hwndBroadcast = IntPtr.Add(IntPtr.Zero, 0xffff);
            IntPtr result = IntPtr.Zero;
            if (msgId != IntPtr.Zero)
            {
                result = PostMessage(hwndBroadcast, msgId.ToInt32(), MakeLong((short)msg, (short)var1), var2);
            }
            return result.ToInt32();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr RegisterWindowMessage(string lpProcName);

        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr OpenEvent(uint dwDesiredAccess, bool bInheritHandle, string lpName);

        public int MakeLong(short lowPart, short highPart)
        {
            return (int)((ushort)lowPart | (uint)(highPart << 16));
        }
    }
}
