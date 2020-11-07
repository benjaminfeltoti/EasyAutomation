using System;
using System.IO;
using System.Text;

namespace EasyAutomation.AutomationFramework.Logging
{
    /// <summary>
    /// This class is responsible for logging to a file and to the console.
    /// </summary>
    public static class Log
    {
        private static string fileType = ".txt";
        private static string previousText = "";
        private static string latestFileName = "";
        private static StringBuilder stringBuilder = new StringBuilder();

        public static void OpenLog(string fileName)
        {
            var uniqueFileName = MakeFileNameUnique(fileName);
            latestFileName = uniqueFileName + fileType;
            stringBuilder = new StringBuilder();

            using (StreamWriter streamWriter = new StreamWriter(latestFileName))
            {
                streamWriter.Write("");
            }
        }

        public static void CloseLog()
        {
            using (StreamWriter streamWriter = new StreamWriter(latestFileName, true) { AutoFlush = true })
            {
                streamWriter.WriteLine(stringBuilder.ToString());
            }
        }

        public static void Write(string text, TextType textType = 0, bool ignoreDuplicateLogs = false)
        {
            if (ignoreDuplicateLogs && previousText == text)
            {
                return;
            }

            previousText = text;

            string indentation = GetIndentationString(DefineIndentationLevel(textType));

            SetConsoleColor(textType);
            Console.WriteLine(indentation + text);

            stringBuilder.AppendLine(indentation + text);
        }

        private static string GetIndentationString(ushort indentLevel)
        {
            string indentation = "";

            for (int i = 0; i <= indentLevel; i++)
            {
                indentation += "  ";
            }

            return indentation;
        }

        private static ushort DefineIndentationLevel(TextType textType = 0)
        {
            switch (textType)
            {
                case TextType.SuccessfulArrangement:
                case TextType.SuccessfulAct:
                case TextType.SuccessfulAssertion:
                    return 5;
                case TextType.ActStarted:
                case TextType.ActEnded:
                case TextType.Error:
                case TextType.FatalError:
                case TextType.Warning:
                    return 4;
                case TextType.Passed:
                case TextType.TestName:
                    return 3;
                case TextType.TestClassName:
                    return 1;
                case TextType.Default:
                default:
                    return 0;
            }
        }

        private static void SetConsoleColor(TextType textType = 0)
        {
            switch (textType)
            {
                case TextType.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case TextType.Failed:
                case TextType.FatalError:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TextType.SuccessfulArrangement:
                case TextType.SuccessfulAct:
                case TextType.SuccessfulAssertion:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case TextType.Passed:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TextType.ActStarted:
                case TextType.ActEnded:
                case TextType.TestName:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case TextType.Warning:
                case TextType.TestClassName:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TextType.Default:
                default:
                    Console.ResetColor();
                    break;
            }
        }

        private static string MakeFileNameUnique(string fileName)
        {
            uint id = 0;
            string newFileName = fileName;

            while (File.Exists(newFileName + fileType))
            {
                id++;
                newFileName = fileName;
                newFileName += id;
            }

            return newFileName;
        }
    }
}
