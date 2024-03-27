using JsonExample2024.Models;
using JsonExample2024.Service;
using System.Text.Json;


namespace JsonExample2024
{
    internal class Program
    {
        public static string BasicSerializtionExmaple(Student student)
        {
            string json = JsonSerializer.Serialize(student);
            Console.WriteLine(json);
            return json;
        }

        public static string SerializeWithOptions(Student student)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreReadOnlyProperties = true,
                IncludeFields = true,
                
            };
            string json = JsonSerializer.Serialize(student,options);
            Console.WriteLine("With indented option:"  );
            Console.WriteLine(json);
            return json;
        }

        public static void BasicDeserializtion(string str)
        {
            Student student = JsonSerializer.Deserialize<Student>(str);
            Console.WriteLine($@"Basic Deserializtion:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Grades:");
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }
        }

        

       
        public static void DeserializtionWithOptions(string str)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
               // PropertyNameCaseInsensitive = true

            };
            Student student = JsonSerializer.Deserialize<Student>(str,options);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Grades:");
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }

        }
        public static void DeserializationWithPropertyNaming(string jsonStr2)
        {
           MyStudent student=JsonSerializer.Deserialize<MyStudent>(jsonStr2);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")} 
    Student KushKush:{student.KushKush}");
            Console.WriteLine("Grades:"  );
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }
        }
        static void Main(string[] args)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() {WriteIndented=true };
            MonkeyService monkeyService = new MonkeyService();
            Console.WriteLine(JsonSerializer.Serialize(monkeyService.Monkeys,options));
        }

    

    }
}