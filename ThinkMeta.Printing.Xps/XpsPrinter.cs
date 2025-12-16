using System.IO;
using System.Printing;
using System.Printing.Interop;
using System.Windows.Xps.Packaging;

namespace ThinkMeta.Printing.Xps;

/// <summary>
/// 
/// </summary>
public static class XpsPrinter
{
    /// <summary>
    /// Prints an XPS file to the specified printer using WPF XpsDocumentWriter.
    /// </summary>
    /// <param name="xpsFileName">Path to the XPS file.</param>
    /// <param name="printerName">Name of the printer.</param>
    /// <param name="devMode">Optional DEVMODE structure as a byte array for printer settings.</param>
    public static void Print(string xpsFileName, string printerName, byte[]? devMode = null)
    {
        if (string.IsNullOrWhiteSpace(xpsFileName))
            throw new ArgumentException("XPS file name must be provided.", nameof(xpsFileName));
        if (string.IsNullOrWhiteSpace(printerName))
            throw new ArgumentException("Printer name must be provided.", nameof(printerName));
        if (!File.Exists(xpsFileName))
            throw new FileNotFoundException($"XPS file not found: {xpsFileName}", xpsFileName);

        var server = new LocalPrintServer();
        var queue = server.GetPrintQueues()
            .FirstOrDefault(pq => string.Equals(pq.Name, printerName, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException($"Printer not found: {printerName}");

        PrintTicket? ticket = null;
        if (devMode is not null && devMode.Length > 0) {
            var converter = new PrintTicketConverter(queue.FullName, queue.ClientPrintSchemaVersion);
            ticket = converter.ConvertDevModeToPrintTicket(devMode);
        }

        var writer = PrintQueue.CreateXpsDocumentWriter(queue);
        using var xpsDoc = new XpsDocument(xpsFileName, FileAccess.Read);
        var fixedDocSeq = xpsDoc.GetFixedDocumentSequence();
        if (ticket is not null)
            writer.Write(fixedDocSeq, ticket);
        else
            writer.Write(fixedDocSeq);
    }
}
