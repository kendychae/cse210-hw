using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) 
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Using the GetStudentName() method to access the private _studentName from base class
        return $"{_title} by {GetStudentName()}";
    }
}
