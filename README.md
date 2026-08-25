# BatchPad
A lightweight and simple Batch script editor and runner for Windows.
<img width="1233" height="842" alt="image" src="https://github.com/user-attachments/assets/7dd61113-902d-42ec-8e59-d2e1dd651b04" />

## Features

Write and edit Batch scripts directly in the app.

Run scripts with the **Run** button or `F5`.

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

To build it yourself, open the project in **Visual Studio 2022** with the .NET Desktop Development workload installed.

## Security

BatchPad runs the code entered into the editor through Windows Command Prompt.

Only run Batch scripts you trust.
