using CsvHelper;
using CsvHelper.Configuration;

namespace Model
{
    public class WorkerModel
    {
        public string Period { get; set; }
        public Dictionary<string, string> CustomerField { get; set; }
    }

    public class WorkerModelMap : ClassMap<WorkerModel>
    {
        public WorkerModelMap(List<string> keys)
        {
            Map(m => m.Period).Name("Período");

            Map(m => m.CustomerField)
            .ConvertUsing(row => 
                keys.Select(key => new 
                { 
                    key, 
                    value = row.GetField(key) 
                }).ToDictionary(dic => dic.key, dic => dic.value)
            );
        }
    }
}

