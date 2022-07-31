using System.Globalization;
using CsvHelper;
using Seed;

class Program
{
    static void Main(string[] args)
    {
        using (var streamWriter = new StreamWriter("worker.csv"))

        using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("pt-BR", true)))
        {
            var keys = GetKeys();
            FillColumnName(csvWriter, keys);

            foreach( var item in WorkerMock.ObterWorkers())
            {
                csvWriter.WriteField(item.Period);
                var dict = item.CustomerField;

                foreach (var key in keys)
                {
                    csvWriter.WriteField(dict[key]);
                }
                csvWriter.NextRecord();
            }
        }
    }

    public static void FillColumnName(CsvWriter csvWriter, List<string> keys)
    {
        var headers = new []{ "Month/Year"}.Concat(keys).ToList();

        foreach(var header in headers)
            csvWriter.WriteField(header);

        csvWriter.NextRecord();
    }

    public static List<string> GetKeys()
    {
        var firstWorker = WorkerMock.ObterWorkers().First();
        return firstWorker.CustomerField.Keys.ToList();
    }
}