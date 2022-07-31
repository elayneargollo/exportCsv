using System.Globalization;
using CsvHelper;
using Model;
using Seed;

class Program
{
    static void Main(string[] args)
    {
        try 
        {
            using (var streamWriter = new StreamWriter("workerFile.csv"))
            using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("pt-BR", true)))
            {
                var keys = GetKeys();
                FillColumnName(csvWriter, keys);

                csvWriter.Configuration.HasHeaderRecord = false;
                csvWriter.Configuration.RegisterClassMap(new WorkerModelMap(GetKeys()));

                csvWriter.WriteRecords(WorkerMock.ObterWorkers());
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred whilst performing the export: " + ex.Message);
        }
    }

    public static void FillColumnName(CsvWriter csvWriter, List<string> keys)
    {
        try 
        {
            var headers = new []{ "Month/Year"}.Concat(keys).ToList();

            headers.ForEach(header => csvWriter.WriteField(header));
            csvWriter.NextRecord();
        }
        catch 
        {
            throw;
        }
    }

    public static List<string> GetKeys()
    {
        var firstWorker = WorkerMock.ObterWorkers().First();
        return firstWorker.CustomerField.Keys.ToList();
    }
}