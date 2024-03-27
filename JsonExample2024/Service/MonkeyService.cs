using JsonExample2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonExample2024.Service
{
    public class MonkeyService
    {
        private MonkeyList monkeyList;
        public List<Monkey> Monkeys { get { return monkeyList.Monkeys; }}
        public MonkeyService()
        {
            monkeyList = new MonkeyList();
            monkeyList.FillList();
        }
        public void AddJsonWayMonkey(Monkey m)
        {
            Monkeys.Add(DeserializeMonkey(SerializeMonkey(m)));
        }
        public string SerializeMonkey(Monkey m)
        {
            return JsonSerializer.Serialize(m);
        }
        public Monkey DeserializeMonkey(string str)
        {
            return JsonSerializer.Deserialize<Monkey>(str);
        }
    }
}
