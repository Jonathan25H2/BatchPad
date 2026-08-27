# BatchPad
A lightweight and simple Batch script editor and runner for Windows.
<img width="1233" height="842" alt="image" src="https://github.com/user-attachments/assets/62982e65-9fc0-4ca2-927a-a08571d8fa02" />

## Features

Write and edit Batch scripts directly in the app.

Run scripts with the **Run** button or `F5`.

Save/Load function

Stop a running script with the **Stop** button or `F6`.

Scripts run in a normal Command Prompt window.

Temporary `.bat` files are deleted automatically.

## Requirements

**Windows 10 or Windows 11**

**64-bit Windows**

The standalone version does not require a separate .NET installation.

## Usage

Open `BatchPad.exe`, write or paste your Batch code and press **Run**.

## Building

BatchPad is built with **C#**, **WPF** and **.NET 8**.

To build it yourself, open the project in **Visual Studio 2022** (or newer) with the .NET Desktop Development workload installed.

## Security

BatchPad runs the code entered into the editor through Windows Command Prompt.

Only run Batch scripts you trust.
