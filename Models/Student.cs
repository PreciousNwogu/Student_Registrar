using System.ComponentModel.DataAnnotations;
namespace Registrar;

public class Student
{
  enum MaxWeeklyHours
  {
    FullTime = 16,
    Coop = 4
  }

  enum MaxNumOfCourses
  {
    PartTime = 3,
    Coop = 2
  }

  public int Id { get; set; } = new Random().Next(100000, 1000000);
  [Required(ErrorMessage = "Please provide a first name")]
  public string? FirstName { get; set; }
  [Required(ErrorMessage = "Please provide a last name")] 
  public string? LastName { get; set; }
  [Required(ErrorMessage = "Please select a student type")]
  public string? Type { get; set; }
  public List<int> Courses  { get; set; } = [];

  public int GetMaxWeeklyHours ()
  {
    switch (Type)
    {
      case "Full Time":
        return (int)MaxWeeklyHours.FullTime;
      case "Coop":
        return (int)MaxWeeklyHours.Coop;
      default:
        return 0;
    }
  }

  public int GetMaxNumOfCourses ()
  {
    switch (Type)
    {
      case "Part Time":
        return (int)MaxNumOfCourses.PartTime;
      case "Coop":
        return (int)MaxNumOfCourses.Coop;
      default:
        return 0;
    }
  }
}
