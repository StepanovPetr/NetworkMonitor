using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation.Windows;

/// <summary> Работа с Windows Api. </summary>
public class WindowsApiManager : IWindowsManager
{
    private List<string> _tracertTable;
    private List<Host> _tracertArp;
    private int _tracertInteration = 0;
    private int _arpInteration = 0;

    /// <summary> Получение таблицы маршрутизации через cmd. </summary>
    /// <param name="gateway"> IP адрес шлюза по-умолчанию. </param>
    /// <returns> таблицы прассеровки. </returns>
    public IEnumerable<string> GetTracertTable(string gateway)
    {
        _tracertInteration = 0;
        _tracertTable = new List<string>();
        Process cmdProcess = new Process();
        cmdProcess.StartInfo = CreateProcessStartInfo("tracert", gateway);
        cmdProcess.OutputDataReceived += ParseTracert;
        cmdProcess.EnableRaisingEvents = true;
        cmdProcess.Start();
        cmdProcess.BeginOutputReadLine();
        cmdProcess.WaitForExit();

        return _tracertTable;
    }

    /// <summary> Получение arp таблицы через cmd. </summary>
    /// <returns> arp таблица. </returns>
    public IEnumerable<Host> GetArpTable()
    {
        _arpInteration = 0;
        _tracertArp = new List<Host>();
        Process cmdProcess = new Process();
        cmdProcess.StartInfo = CreateProcessStartInfo("arp", "-a");
        cmdProcess.OutputDataReceived += ParseArp;
        cmdProcess.EnableRaisingEvents = true;
        cmdProcess.Start();
        cmdProcess.BeginOutputReadLine();
        cmdProcess.WaitForExit();

        return _tracertArp;
    }

    private ProcessStartInfo CreateProcessStartInfo(string fileName, string arguments)
    {
        var cmdStartInfo = new ProcessStartInfo();
        //_cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
        cmdStartInfo.FileName = fileName;
        cmdStartInfo.Arguments = arguments;
        cmdStartInfo.RedirectStandardOutput = true;
        cmdStartInfo.RedirectStandardError = true;
        cmdStartInfo.RedirectStandardInput = true;
        cmdStartInfo.UseShellExecute = false;
        cmdStartInfo.CreateNoWindow = true;

        return cmdStartInfo;
    }

    private void ParseTracert(object sender, DataReceivedEventArgs e)
    {
        if (_tracertInteration > 3 && !string.IsNullOrEmpty(e.Data))
        {
            var tracertString = e.Data
                .Replace("[", "")
                .Replace("]", "")
                .Split(" ")
                .LastOrDefault(i => i != "");

            if (!string.IsNullOrEmpty(tracertString) && IPAddress.TryParse(tracertString, out var address))
            {
                _tracertTable.Add(address.ToString());
            }
        }

        _tracertInteration++;
    }

    private void ParseArp(object sender, DataReceivedEventArgs e)
    {
        if (_arpInteration > 2 && !string.IsNullOrEmpty(e.Data))
        {
            var arpString = e.Data
                .Split(" ")
                .Where(i => !string.IsNullOrEmpty(i))
                .ToList();

            if (arpString.Any() && arpString.Count() == 3 
                                && IPAddress.TryParse(arpString.FirstOrDefault(), out var address)
                                && arpString.LastOrDefault() == "dynamic")
            {
                _tracertArp.Add(new Host()
                {
                    IpAddress = arpString[0],
                    MacAddress = arpString[1]
                });
            }
        }

        _arpInteration++;
    }

    #region Move
    // The max number of physical addresses.
    const int MAXLEN_PHYSADDR = 8;

    // Define the MIB_IPNETROW structure.
    [StructLayout(LayoutKind.Sequential)]
    struct MIB_IPNETROW
    {
        [MarshalAs(UnmanagedType.U4)]
        public int dwIndex;
        [MarshalAs(UnmanagedType.U4)]
        public int dwPhysAddrLen;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac0;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac1;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac2;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac3;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac4;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac5;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac6;
        [MarshalAs(UnmanagedType.U1)]
        public byte mac7;
        [MarshalAs(UnmanagedType.U4)]
        public int dwAddr;
        [MarshalAs(UnmanagedType.U4)]
        public int dwType;
    }

    // Declare the GetIpNetTable function.
    [DllImport("IpHlpApi.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    static extern int GetIpNetTable(IntPtr pIpNetTable, [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);

    [DllImport("IpHlpApi.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern int FreeMibTable(IntPtr plpNetTable);

    // The insufficient buffer error.
    const int ERROR_INSUFFICIENT_BUFFER = 122;

    static void Main(string[] args)
    {
        // The number of bytes needed.
        int bytesNeeded = 0;
        // The result from the API call.
        int result = GetIpNetTable(IntPtr.Zero, ref bytesNeeded, false);

        // Call the function, expecting an insufficient buffer.
        if (result != ERROR_INSUFFICIENT_BUFFER)
        {
            // Throw an exception.
            throw new Win32Exception(result);
        }

        // Allocate the memory, do it in a try/finally block, to ensure
        // that it is released.
        IntPtr buffer = IntPtr.Zero;

        // Try/finally.
        try
        {
            // Allocate the memory.
            buffer = Marshal.AllocCoTaskMem(bytesNeeded);

            // Make the call again. If it did not succeed, then
            // raise an error.
            result = GetIpNetTable(buffer, ref bytesNeeded, false);

            // If the result is not 0 (no error), then throw an exception.
            if (result != 0)
            {
                // Throw an exception.
                throw new Win32Exception(result);
            }

            // Now we have the buffer, we have to marshal it. We can read
            // the first 4 bytes to get the length of the buffer.
            int entries = Marshal.ReadInt32(buffer);

            // Increment the memory pointer by the size of the int.
            IntPtr currentBuffer = new IntPtr(buffer.ToInt64() + Marshal.SizeOf(typeof(int)));

            // Allocate an array of entries.
            MIB_IPNETROW[] table = new MIB_IPNETROW[entries];

            // Cycle through the entries.
            for (int index = 0; index < entries; index++)
            {
                // Call PtrToStructure, getting the structure information.
                table[index] = (MIB_IPNETROW)Marshal.PtrToStructure(new IntPtr(currentBuffer.ToInt64() + (index * Marshal.SizeOf(typeof(MIB_IPNETROW)))), typeof(MIB_IPNETROW));
            }

            for (int index = 0; index < entries; index++)
            {
                MIB_IPNETROW row = table[index];
                IPAddress ip = new IPAddress(BitConverter.GetBytes(row.dwAddr));
                Console.WriteLine("IP:" + ip + "\t\tMAC: " + GetMac(row));
            }
        }
        finally
        {
            // Release the memory.
            FreeMibTable(buffer);
        }
    }

    private static string GetMac(MIB_IPNETROW row)
    {
        return $"{row.mac0.ToString("X2")}-{row.mac1.ToString("X2")}-{row.mac2.ToString("X2")}-"
               + $"{row.mac3.ToString("X2")}-{row.mac3.ToString("X2")}-{row.mac4.ToString("X2")}";
    }

    #endregion
}