using System;
using System.Diagnostics;
using System.Threading;
using Medo;

Console.WriteLine($"Show progress using 'kill -10 {Process.GetCurrentProcess().Id}' (or Ctrl+T on BSD/Mac).");
Console.WriteLine();


// Always attach this text
SigInfo.SignalReceived += (sender, e) => {
    e.AppendOutputText(DateTime.Now.ToString("T"));
};

Console.WriteLine("Starting work...");
for (var i = 0; i < 60; i++) {

    // Set base text for the signal output
    SigInfo.SetText($"Processing data ({i + 1})");

    Thread.Sleep(1000);  // Simulate work
}
Console.WriteLine("Work completed.");
