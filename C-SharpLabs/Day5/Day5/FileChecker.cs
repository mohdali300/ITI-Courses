using System;
using System.IO;
using System.Text;

namespace Day5
{
    public static class FileChecker
    {
        public static string ReadAndThrowIfContainsError(string path)
        {
            if (path is null) throw new ArgumentNullException(nameof(path));

            FileStream? fs = null;
            StreamReader? sr = null;
            var sb = new StringBuilder();

            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(fs, Encoding.UTF8);

                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);

                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        throw new InvalidDataException($"File '{path}' contains the word 'error'.");
                    }
                }

                return sb.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception caught in ReadAndThrowIfContainsError: {ex.Message}");
                throw;
            }
            finally
            {
                sr?.Close();
                sr?.Dispose();
            }
        }
    }
}