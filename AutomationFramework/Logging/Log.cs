using System;
using System.IO;

namespace EasyAutomation.AutomationFramework.Logging
{
    /// <summary>
    /// This class is responsible for logging to a file and to the console.
    /// </summary>
    public static class Log
    {
        private static string fileName = "log";
        private static string fileType = ".txt";
        private static string previousText = "";

        static Log()
        {
            NewFile();
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

            using (StreamWriter streamWriter = new StreamWriter(fileName + fileType, true))
            {
                streamWriter.WriteLine(indentation + text);
            }
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
                case TextType.Error:
                case TextType.FatalError:
                case TextType.SuccessfulArrangement:
                case TextType.SuccessfulAct:
                case TextType.SuccessfulAssertion:
                    return 3;
                case TextType.Passed:
                case TextType.TestName:
                case TextType.Warning:
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
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case TextType.SuccessfulAssertion:
                case TextType.Passed:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TextType.TestName:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case TextType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TextType.Default:
                default:
                    Console.ResetColor();
                    break;
            }
        }

        private static void NewFile()
        {
            MakeFileNameUnique();

            using (StreamWriter streamWriter = new StreamWriter(fileName + fileType))
            {
                streamWriter.Write("");
            }
        }

        private static void MakeFileNameUnique()
        {
            uint id = 0;
            string newFileName = fileName;

            while (File.Exists(newFileName + fileType))
            {
                id++;
                newFileName = fileName;
                newFileName += id;
            }

            fileName = newFileName;
        }
    }
}
