using System.Text;

namespace PlumsailTest.Library.ALMW.FilesIO;

public interface IFileReader
{
    /// <exception cref="NotSupportedException"><see cref="P:System.IO.FileStream.CanSeek" /> for this stream is <see langword="false" />.</exception>
    /// <exception cref="IOException">An I/O error, such as the file being closed, occurred.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset" /> or <paramref name="count" /> is negative.</exception>
    /// <exception cref="ArgumentException">The sum of <paramref name="offset" /> and <paramref name="count" /> is larger than the buffer length.</exception>
    /// <exception cref="ObjectDisposedException">The stream has been disposed.</exception>
    /// <exception cref="InvalidOperationException">The stream is currently in use by a previous read operation.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
    /// <exception cref="UnauthorizedAccessException"><paramref name="path" /> specified a directory.
    ///  -or-
    ///  The caller does not have the required permission.</exception>
    /// <exception cref="FileNotFoundException">The file specified in <paramref name="path" /> was not found.</exception>
    /// <exception cref="DecoderFallbackException">A fallback occurred (for more information, see Character Encoding in .NET)
    ///  -and-
    ///  <see cref="DecoderFallback" /> is set to <see cref="DecoderExceptionFallback" />.</exception>
    Task<string> ReadAsync(string filePath);
}