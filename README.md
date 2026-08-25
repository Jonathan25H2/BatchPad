# BatchPad
A lightweight and simple Batch script editor and runner for Windows.
<img width="1233" height="842" alt="image" src="https://github.com/user-attachments/assets/7dd61113-902d-42ec-8e59-d2e1dd651b04" />

Write, edit, and execute Batch scripts quickly without manually creating `.bat` files.

## Features

- **Simple Batch editor**
- **Run scripts instantly**
- **Stop running scripts**
- Runs scripts in Windows Command Prompt
- Keyboard shortcuts
- Portable — no installation required
- Lightweight and fast
- No internet connection required
- Automatically cleans up temporary Batch files

## Requirements

- **Windows 10 or Windows 11**
- **64-bit Windows**

The standalone version includes the required **.NET 8 runtime**, so no separate .NET installation is required.

## Usage

1. Download the latest version from **Releases**.
2. Open `BatchPad.exe`.
3. Write or paste your Batch code.
4. Click **Run** to execute the script.
5. Click **Stop** to terminate the running script.

## Keyboard Shortcuts

| Key | Action |
| --- | --- |
| `F5` | Run |
| `F6` | Stop |

## Building from Source

### Requirements

- **Visual Studio 2022**
- **.NET 8 SDK**
- **Windows Desktop Development** workload

Clone or download the repository and open the project in Visual Studio.

Build the project using the **Release** configuration.

For a standalone build:

- **Deployment mode:** Self-contained
- **Target runtime:** `win-x64`
- **Produce single file:** Enabled
- **ReadyToRun:** Disabled

## Security

BatchPad executes Batch scripts through **Windows Command Prompt** with the permissions of the current user.

**Only run scripts you understand and trust.**

BatchPad does not sandbox or analyze scripts before execution.

## License

See the `LICENSE` file for license information.
