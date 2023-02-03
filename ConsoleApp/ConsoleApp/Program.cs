

List<Student> stud = new List<Student>()
{
   new Student{id=1,Name="ABC"},
   new Student{id=2,Name="BBC"},
   new Student{id=3,Name="ABC"},
   new Student{id=4,Name="BBC"},
};


var res = stud.Select(x => x.Name).Distinct();
foreach (var item in res)
{
    Console.WriteLine(item);
}
class Student
{
    public int id { get; set; }
    public string Name { get; set; }


}
