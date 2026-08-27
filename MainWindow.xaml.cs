using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BatchPadV1
{
    public partial class MainWindow : Window
    {
        private Process? runningProcess;
        private string? temporaryBatchFile;


        public MainWindow()
        {
            InitializeComponent();

            CodeEditor.Focus();
            CodeEditor.CaretIndex = CodeEditor.Text.Length;
        }


        private async void RunButton_Click(object sender, RoutedEventArgs e)
        {
            await RunScriptAsync();
        }


        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopScript();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save Batch File",
                Filter = "Batch Files (*.bat)|*.bat|All Files (*.*)|*.*",
                DefaultExt = ".bat",
                AddExtension = true,
                FileName = "script.bat"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(
                        dialog.FileName,
                        CodeEditor.Text,
                        new UTF8Encoding(false));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "BatchPad could not save the file.\n\n" + ex.Message,
                        "BatchPad",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }


        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Load Batch File",
                Filter = "Batch Files (*.bat;*.cmd)|*.bat;*.cmd|All Files (*.*)|*.*",
                CheckFileExists = true
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    CodeEditor.Text = File.ReadAllText(dialog.FileName);

                    CodeEditor.Focus();
                    CodeEditor.CaretIndex = CodeEditor.Text.Length;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "BatchPad could not load the file.\n\n" + ex.Message,
                        "BatchPad",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }


        private async Task RunScriptAsync()
        {
            if (string.IsNullOrWhiteSpace(CodeEditor.Text))
            {
                MessageBox.Show(
                    "There is no Batch code to run.",
                    "BatchPad",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }


            // Stop previous script if one is still running
            if (runningProcess != null)
            {
                try
                {
                    if (!runningProcess.HasExited)
                    {
                        StopScript();

                        await Task.Delay(200);
                    }
                }
                catch
                {
                    runningProcess = null;
                }
            }


            DeleteTemporaryFile();


            try
            {
                temporaryBatchFile = Path.Combine(
                    Path.GetTempPath(),
                    $"BatchPad_{Guid.NewGuid():N}.bat");


                await File.WriteAllTextAsync(
                    temporaryBatchFile,
                    CodeEditor.Text,
                    new UTF8Encoding(false));


                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    // Keep CMD open after script finishes
                    Arguments = $"/D /K call \"{temporaryBatchFile}\"",

                    UseShellExecute = true,

                    WorkingDirectory =
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.UserProfile),

                    WindowStyle = ProcessWindowStyle.Normal
                };


                runningProcess = Process.Start(startInfo);


                if (runningProcess == null)
                    throw new Exception(
                        "Windows could not start Command Prompt.");


                StopButton.IsEnabled = true;


                _ = WatchProcessAsync(runningProcess);
            }
            catch (Exception ex)
            {
                runningProcess = null;

                StopButton.IsEnabled = false;


                MessageBox.Show(
                    "BatchPad could not start the script.\n\n" +
                    ex.Message,
                    "BatchPad",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);


                DeleteTemporaryFile();
            }
        }


        private async Task WatchProcessAsync(Process process)
        {
            try
            {
                await process.WaitForExitAsync();
            }
            catch
            {
                return;
            }


            await Dispatcher.InvokeAsync(() =>
            {
                if (runningProcess != process)
                    return;


                try
                {
                    runningProcess.Dispose();
                }
                catch
                {
                }


                runningProcess = null;

                StopButton.IsEnabled = false;

                DeleteTemporaryFile();
            });
        }


        private void StopScript()
        {
            if (runningProcess == null)
            {
                StopButton.IsEnabled = false;

                return;
            }


            try
            {
                if (!runningProcess.HasExited)
                {
                    // Kill CMD and anything launched by the script
                    runningProcess.Kill(true);

                    runningProcess.WaitForExit(2000);
                }
            }
            catch
            {
            }


            try
            {
                runningProcess.Dispose();
            }
            catch
            {
            }


            runningProcess = null;

            StopButton.IsEnabled = false;

            DeleteTemporaryFile();
        }


        private void DeleteTemporaryFile()
        {
            if (string.IsNullOrWhiteSpace(temporaryBatchFile))
                return;


            try
            {
                if (File.Exists(temporaryBatchFile))
                {
                    File.Delete(temporaryBatchFile);
                }
            }
            catch
            {
            }


            temporaryBatchFile = null;
        }


        private async void Window_PreviewKeyDown(
            object sender,
            KeyEventArgs e)
        {
            // F5 still works, just isn't shown in the UI
            if (e.Key == Key.F5)
            {
                e.Handled = true;

                await RunScriptAsync();
            }

            // F6 still works, just isn't shown in the UI
            else if (e.Key == Key.F6)
            {
                e.Handled = true;

                StopScript();
            }
        }


        private void Window_Closing(
            object? sender,
            CancelEventArgs e)
        {
            StopScript();

            DeleteTemporaryFile();
        }
    }
}
