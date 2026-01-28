Medo.SigInfo
============

A library that allows for custom handling of SIGINFO (BSD) or SIGUSR1 (Linux)
output.

On BSD this text can be shown using `Ctrl+T`. On Linux, it will require
sending `SIGUSR1` signal to the proces:
~~~sh
kill -SIGUSR1 <PID>
~~~


## Usage

Basic event-driven code would be:
~~~csharp
SigInfo.SignalReceived += (sender, e) => {
    var text = DateTime.Now.ToString("T");  // any progress text
    e.OutputText = text;
};
~~~

Alternatively, text can be updated as it happens. Note that this will still
result in text being shown only once SIGINFO or SIGUSR1 is intercepted:
~~~csharp
var text = DateTime.Now.ToString("T");  // any progress text
SigInfo.SetText(text);
~~~
