/* Josip Medved <jmedved@jmedved.com> * www.medo64.com * MIT License */

namespace Medo;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Class for handling SIGINFO or SIGUSR1 signals.
/// </summary>
public static class SigInfo {

    /// <summary>
    /// Attaches to SIGINFO (or SIGUSR1 on non-BSD systems) signal.
    /// </summary>
    static SigInfo() {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {  //
            Console.CancelKeyPress += (sender, e) => {
                e.Cancel = true;
                OnSignalReceived();
            };
        } else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
            PosixSignalRegistration.Create((PosixSignal)29, context => {
                OnSignalReceived();
                context.Cancel = true;
            });
        } else {
            PosixSignalRegistration.Create((PosixSignal)10, context => {
                OnSignalReceived();
                context.Cancel = true;
            });
        }
    }

    /// <summary>
    /// Sets a static text to be printed when the signal is received.
    /// This text will be used as default in SignalReceived event.
    /// </summary>
    /// <param name="outputText">The text to be displayed when the signal is received.</param>
    public static void SetText(string outputText) {
        LastOutputText = outputText;
    }

    /// <summary>
    /// Raised when SIGINFO (or SIGUSR1 on non-BSD systems) signal is received.
    /// </summary>
    public static event EventHandler<SigInfoEventArgs>? SignalReceived;


    private static string LastOutputText = string.Empty;

    private static void OnSignalReceived() {
        var e = new SigInfoEventArgs(LastOutputText);
        SignalReceived?.Invoke(null, e);
        if (e.Cancel) { return; }  // cancelled in event
        if (string.IsNullOrEmpty(e.OutputText)) { return; }  // ignore empty text

        Console.Error.WriteLine(e.OutputText);
    }

}
