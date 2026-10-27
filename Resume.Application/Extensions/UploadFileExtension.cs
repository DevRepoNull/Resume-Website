using Microsoft.AspNetCore.Http;

namespace Resume.Application.Extensions;

public static class UploadFileExtension
{
    // Allowed extensions for safe images and document uploads
    private static readonly HashSet<string> DefaultAllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".webp", ".pdf", ".docx"
    };

    // Default maximum file size: 5 MB (5 * 1024 * 1024 bytes)
    private const long DefaultMaxFileSize = 5 * 1024 * 1024;

    /// <summary>
    /// Validates and securely saves an uploaded IFormFile to the specified server directory.
    /// Protects against directory traversal, path tampering, executable file uploads, and oversized files.
    /// </summary>
    public static async Task<bool> AddImageAjaxToServer(
        this IFormFile file,
        string fileName,
        string targetDirectory,
        long maxFileSizeInBytes = DefaultMaxFileSize,
        IEnumerable<string> allowedExtensions = null)
    {
        if (file == null || file.Length == 0)
            return false;

        // 1. File Size Validation
        if (file.Length > maxFileSizeInBytes)
            return false;

        // 2. File Extension Validation
        var extension = Path.GetExtension(fileName);
        if (string.IsNullOrWhiteSpace(extension))
            return false;

        var allowed = allowedExtensions != null
            ? new HashSet<string>(allowedExtensions, StringComparer.OrdinalIgnoreCase)
            : DefaultAllowedExtensions;

        if (!allowed.Contains(extension))
            return false;

        // Check original uploaded file extension as well
        var originalExtension = Path.GetExtension(file.FileName);
        if (!string.IsNullOrWhiteSpace(originalExtension) && !allowed.Contains(originalExtension))
            return false;

        // 3. Mitigate Directory Traversal Attacks
        // Extract only the file name (strips any ../ or path navigation components)
        var safeFileName = Path.GetFileName(fileName);
        if (string.IsNullOrWhiteSpace(safeFileName))
            return false;

        // Normalize target directory and full destination path
        var normalizedDirectory = Path.GetFullPath(targetDirectory);
        var fullDestinationPath = Path.GetFullPath(Path.Combine(normalizedDirectory, safeFileName));

        // Ensure the destination path stays strictly within the intended directory
        if (!fullDestinationPath.StartsWith(normalizedDirectory, StringComparison.OrdinalIgnoreCase))
            return false;

        // Ensure target directory exists on disk
        if (!Directory.Exists(normalizedDirectory))
        {
            Directory.CreateDirectory(normalizedDirectory);
        }

        // 4. Save file to disk securely
        await using var stream = new FileStream(fullDestinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await file.CopyToAsync(stream);

        return true;
    }

    /// <summary>
    /// Helper method to validate file extension and size before processing.
    /// </summary>
    public static bool IsValidUpload(this IFormFile file, long maxFileSize = DefaultMaxFileSize, IEnumerable<string> allowedExtensions = null)
    {
        if (file == null || file.Length == 0 || file.Length > maxFileSize)
            return false;

        var ext = Path.GetExtension(file.FileName);
        if (string.IsNullOrWhiteSpace(ext))
            return false;

        var allowed = allowedExtensions != null
            ? new HashSet<string>(allowedExtensions, StringComparer.OrdinalIgnoreCase)
            : DefaultAllowedExtensions;

        return allowed.Contains(ext);
    }
}
