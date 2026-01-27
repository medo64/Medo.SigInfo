/* Josip Medved <jmedved@jmedved.com> * www.medo64.com * MIT License */

namespace Medo;
using System;

/// <summary>
/// Event arguments for SigInfo.SignalReceived event.
/// </summary>
public sealed class SigInfoEventArgs : EventArgs {

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public SigInfoEventArgs() {
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="outputText">Default text.</param>
    internal SigInfoEventArgs(string outputText) {
        OutputText = outputText;
    }

    /// <summary>
    /// Gets/sets the text message to be displayed on SIGINFO/SIGUSR1.
    /// </summary>
    public string OutputText { get; set; } = string.Empty;

    /// <summary>
    /// Gets/sets if the operation should be canceled.
    /// </summary>
    public bool Cancel { get; set; }


    /// <summary>
    /// Appends the existing output text with a new line.
    /// </summary>
    /// <param name="outputText">New output text.</param>
    public void AppendOutputText(string outputText) {
        if (string.IsNullOrEmpty(outputText)) { return; }

        if (!string.IsNullOrEmpty(OutputText)) {
            OutputText += Environment.NewLine;
        }
        OutputText += outputText;
    }

}
