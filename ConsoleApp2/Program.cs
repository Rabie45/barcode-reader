using IronBarCode;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Correctly formatted file path
        string filePath = @"C:\Users\Rabi3\Desktop\ConsoleApp2\barcode.gif";

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found at: " + filePath);
            return;
        }

        try
        {
            // Read barcodes from the image
            BarcodeResults results = BarcodeReader.Read(filePath);

            // Check if any barcodes were found
            if (results != null && results.Count > 0)
            {
                Console.WriteLine($"Scanned Barcode: {results.First().Text}");
            }
            else
            {
                Console.WriteLine("No barcodes found.");
            }
        }
        catch (IronBarCode.Exceptions.IronBarCodeFileException ex)
        {
            Console.WriteLine($"IronBarCode Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Hello, World!");
    }
}