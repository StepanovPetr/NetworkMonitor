using System.Diagnostics;
using System.Net;
using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Implementation;

public class WindowsCmdManager
{
    private List<string> _tracertTable;
    private List<Host> _tracertArp;
    private int _tracertInteration = 0;
    private int _arpInteration = 0;

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
                .LastOrDefault( i => i != "");

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

            if (arpString.Any() && arpString.Count() == 3 && IPAddress.TryParse(arpString.FirstOrDefault(), out var address))
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
}