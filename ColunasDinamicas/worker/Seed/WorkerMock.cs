using Bogus;
using Model;

namespace Seed
{
    public static class WorkerMock
    {
        static Faker faker = new Faker();

        public static List<WorkerModel> ObterWorkers()
        {
            return new List<WorkerModel>()
            {
                new WorkerModel()
                {
                    Period =  String.Concat(faker.Date.Month().ToString(), "/", DateTime.Now.Year),
                    CustomerField = new Dictionary<string, string>() 
                    { 
                        ["Ativo"] = "10",
                        ["Ativo - Porcentagem(%)"] = "10%",
                        ["Inativo"] = "20",
                        ["Inativo - Porcentagem(%)"] = "20%",
                    }
                },
                new WorkerModel()
                {
                    Period =  String.Concat(faker.Date.Month().ToString(), "/" ,DateTime.Now.Year),
                    CustomerField = new Dictionary<string, string>() 
                    { 
                        ["Ativo"] = "10",
                        ["Ativo - Porcentagem(%)"] = "10%",
                        ["Inativo"] = "20",
                        ["Inativo - Porcentagem(%)"] = "20%",
                    }
                }
            };
        }
    }
}