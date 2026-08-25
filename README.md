# BatchPad

<img width="1233" height="842" alt="image" src="https://github.com/user-attachments/assets/7dd61113-902d-42ec-8e59-d2e1dd651b04" />

A lightweight and simple Batch script editor and runner for Windows.

BatchPad lets you quickly write, edit, and execute Windows Batch commands without creating .bat files manually. Write your script, press Run, and BatchPad opens it in Command Prompt.

Features
✏️ Simple built-in Batch editor
▶️ Run Batch scripts instantly
⏹️ Stop running scripts
🖥️ Opens scripts in a standard Command Prompt window
⌨️ F5 to run and F6 to stop
📦 Portable — no installation required
🚀 Lightweight and fast
🔒 No internet connection required
🗑️ Temporary Batch files are automatically cleaned up
Requirements
Windows 10 or Windows 11
64-bit Windows

The standalone release includes the required .NET runtime, so .NET does not need to be installed separately.

Usage
Download the latest BatchPadV1.exe from the Releases section.
Open BatchPad.
Enter or paste your Batch code into the editor.
Click Run or press F5.
The script will open in Command Prompt.
Click Stop or press F6 to terminate the running script.

Building from Source
Requirements
Visual Studio 2022
.NET 8 SDK
Windows Desktop Development workload

Clone the repository and open the project in Visual Studio:

git clone <repository-url>

Build the project using the Release configuration.

To create the standalone executable, publish using:

Deployment mode: Self-contained
Target runtime: win-x64
Produce single file: Enabled
ReadyToRun: Disabled
Security

BatchPad executes the Batch code entered into the editor using Windows Command Prompt.

Only run scripts you understand and trust. Batch scripts can modify files, execute programs, change system settings, and perform other operations with the permissions of the current user.

BatchPad does not analyze or sandbox scripts before execution.

License

See the LICENSE file for license information.
