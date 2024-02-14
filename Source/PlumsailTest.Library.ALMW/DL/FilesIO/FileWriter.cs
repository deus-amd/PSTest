using System.Text;

namespace PlumsailTest.Library.ALMW.FilesIO;

public sealed class FileWriter : IFileWriter
{
    /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.
    ///  -or-
    ///  <paramref name="path" /> specified a read-only file or directory.</exception>
    /// <exception cref="ArgumentException">.NET Framework and .NET Core versions older than 2.1: <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters. You can query for invalid characters by using the <see cref="M:System.IO.Path.GetInvalidPathChars" /> method.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="NotSupportedException"><paramref name="path" /> is in an invalid format.</exception>
    /// <exception cref="EncoderFallbackException">A fallback occurred (for more information, see Character Encoding in .NET)
    ///  -and-
    ///  <see cref="EncoderFallback" /> is set to <see cref="EncoderExceptionFallback" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset" /> or <paramref name="count" /> is negative.</exception>
    /// <exception cref="ObjectDisposedException">The stream has been disposed.</exception>
    /// <exception cref="InvalidOperationException">The stream is currently in use by a previous write operation.</exception>
    /// <exception cref="OverflowException">The array is multidimensional and contains more than <see cref="int.MaxValue">Int32.MaxValue</see> elements.</exception>
    /// <exception cref="IOException">The specified file is in use.
    ///  -or-
    ///  There is an open handle on the file, and the operating system is Windows XP or earlier. This open handle can result from enumerating directories and files. For more information, see How to: Enumerate Directories and Files.</exception>
    public async Task WriteAsync(string filePath, string data)
    {
        EnsureFileNotExists(filePath);

        await using var fileStream = File.OpenWrite(filePath);

        var buffer = Encoding.UTF8.GetBytes(data);

        await fileStream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
        fileStream.Close();
    }

    private static void EnsureFileNotExists(string filePath)
    {
        if (File.Exists(filePath)) File.Delete(filePath);
    }
}